using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using ClubinhoDoBebe.Application.Common.Models.Request;
using ClubinhoDoBebe.Application.Common.Models.Response;
using Microsoft.Extensions.Options;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace ClubinhoDoBebe.Infrastructure.Authentication;

public class CognitoService
{
    private readonly CognitoSettings _cognitoSettings;

    public CognitoService(IOptions<CognitoSettings> cognitoSettings)
    {
        _cognitoSettings = cognitoSettings.Value;
    }

    public async Task<AuthResponse> AuthenticateAsync(LoginRequest loginRequest)
    {
        AmazonCognitoIdentityProviderClient provider = GetAmazonCognitoIdentityProvider();

        var username = loginRequest.username;

        var secretHash = CalculateSecretHash(username);

        var request = new AdminInitiateAuthRequest
        {
            UserPoolId = _cognitoSettings.UserPoolId,
            ClientId = _cognitoSettings.ClientId,
            AuthFlow = AuthFlowType.ADMIN_NO_SRP_AUTH,
            AuthParameters = new Dictionary<string, string>
            {
                { "USERNAME", username },
                { "PASSWORD", loginRequest.password },
                { "SECRET_HASH", secretHash }
            }
        };

        var response = await provider.AdminInitiateAuthAsync(request);

        if (response.ChallengeName == ChallengeNameType.NEW_PASSWORD_REQUIRED)
        {
            var respondToAuthRequest = new RespondToAuthChallengeRequest
            {
                ClientId = _cognitoSettings.ClientId,
                ChallengeName = ChallengeNameType.NEW_PASSWORD_REQUIRED,
                ChallengeResponses = new Dictionary<string, string>
                {
                    { "USERNAME", username },
                    { "NEW_PASSWORD", loginRequest.password },
                    { "SECRET_HASH", secretHash}
                },
                Session = response.Session
            };

            var responseToAuthChallenge = await provider.RespondToAuthChallengeAsync(respondToAuthRequest);

            return new AuthResponse(responseToAuthChallenge.AuthenticationResult.AccessToken, responseToAuthChallenge.AuthenticationResult.RefreshToken);

        }

        return new AuthResponse(response.AuthenticationResult.AccessToken, response.AuthenticationResult.RefreshToken);
    }

    public async Task<bool> DeAuthenticateUserAsync(string username)
    {
        var provider = GetAmazonCognitoIdentityProvider();
        var request = new AdminUserGlobalSignOutRequest
        {
            Username = username,
            UserPoolId = _cognitoSettings.UserPoolId
        };

        var response = await provider.AdminUserGlobalSignOutAsync(request);

        if (response.HttpStatusCode == HttpStatusCode.OK)
        {
            return true;
        }

        return false;
    }

    public async Task<GetUserResponse?> GetUserByTokenAsync(string token)
    {
        var provider = GetAmazonCognitoIdentityProvider();

        var getUserRequest = new GetUserRequest
        {
            AccessToken = token
        };

        return await provider.GetUserAsync(getUserRequest);
    }

    public async Task<AuthResponse> RefreshTokenAsync(string refreshToken)
    {
        var provider = GetAmazonCognitoIdentityProvider();

        var authRequest = new AdminInitiateAuthRequest
        {
            AuthFlow = AuthFlowType.REFRESH_TOKEN_AUTH,
            UserPoolId = _cognitoSettings.UserPoolId,
            ClientId = _cognitoSettings.ClientId,
            AuthParameters = new Dictionary<string, string>
            {
                { "REFRESH_TOKEN", refreshToken },
                { "SECRET_HASH", CalculateSecretHash(refreshToken)}
            }
        };

        var response = await provider.AdminInitiateAuthAsync(authRequest);

        var authResponse = new AuthResponse(response.AuthenticationResult.AccessToken, response.AuthenticationResult.RefreshToken);

        return authResponse;
    }

    private AmazonCognitoIdentityProviderClient GetAmazonCognitoIdentityProvider()
    {
        return new AmazonCognitoIdentityProviderClient(RegionEndpoint.GetBySystemName(_cognitoSettings.Region));
    }

    private string CalculateSecretHash(string input)
    {
        var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(_cognitoSettings.ClientSecret));
        var message = Encoding.UTF8.GetBytes(input + _cognitoSettings.ClientId);
        var hash = hmac.ComputeHash(message);
        return Convert.ToBase64String(hash);
    }
}
