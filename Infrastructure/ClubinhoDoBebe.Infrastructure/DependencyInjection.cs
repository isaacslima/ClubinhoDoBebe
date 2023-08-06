using ClubinhoDoBebe.Application.Common.Interface;
using ClubinhoDoBebe.Application.Common.Interface.Services;
using ClubinhoDoBebe.Infrastructure.Authentication;
using ClubinhoDoBebe.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace ClubinhoDoBebe.Infrastructure;

[ExcludeFromCodeCoverage]
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddDbContext<IDataBaseContext, DataBaseContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Connection")));

        services.Configure<CognitoSettings>(configuration.GetSection(CognitoSettings.SectionName));

        services.AddTransient<ICognitoService, CognitoService>();

        return services;
    }
}
