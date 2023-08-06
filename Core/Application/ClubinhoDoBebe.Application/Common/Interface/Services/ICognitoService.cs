using ClubinhoDoBebe.Application.Common.Models.Request;
using ClubinhoDoBebe.Application.Common.Models.Response;

namespace ClubinhoDoBebe.Application.Common.Interface.Services;

public interface ICognitoService
{
    Task<AuthResponse> AuthenticateAsync(LoginRequest loginRequest);
    Task<bool> DeAuthenticateUserAsync(string username);
    Task<global::Amazon.CognitoIdentityProvider.Model.GetUserResponse?> GetUserByTokenAsync(string token);
    Task<AuthResponse> RefreshTokenAsync(string refreshToken);
}
