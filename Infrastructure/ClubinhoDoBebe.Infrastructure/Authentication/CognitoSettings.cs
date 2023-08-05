using System.Diagnostics.CodeAnalysis;

namespace ClubinhoDoBebe.Infrastructure.Authentication;

[ExcludeFromCodeCoverage]
public class CognitoSettings
{
    public const string SectionName = "CognitoSettings";
    public string Region { get; set; } = null!;
    public string UserPoolId { get; set; } = null!;
    public string ClientId { get; set; } = null!;
    public string ClientSecret { get; set; } = null!;
}
