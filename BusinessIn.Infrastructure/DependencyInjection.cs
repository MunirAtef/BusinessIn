using BusinessIn.Application.AbstractRepositories;
using BusinessIn.Application.Common.Authentication;
using BusinessIn.Infrastructure.Authentication;
using BusinessIn.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessIn.Infrastructure;

public static class DependencyInjection {
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {
        var jwtSection = configuration.GetSection(JwtSettings.SectionName);
        
        services.AddSingleton<ApplicationDbContext>();
        services.AddScoped<IEmployeesRepository, EmployeeRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<ITeamRepository, TeamRepository>();
        services.AddScoped<ILocationRepository, LocationRepository>();
        services.AddScoped<IAuthRepository, AuthRepository>();
        
        services.Configure<JwtSettings>(jwtSection);
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddJwtAuthentication(jwtSection.Get<JwtSettings>()!);

        return services;
    }
}