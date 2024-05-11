using Microsoft.Extensions.DependencyInjection;

namespace BusinessIn.Application;

public static class DependencyInjection {
    public static IServiceCollection AddApplication(this IServiceCollection services) {
        // services.AddScoped<AbstractValidator<CreateEmployeeCommand>, CreateEmployeeCommandValidator>();

        // Registering validators 
        // services.AddScoped<AbstractValidator<EmployeeDto>, EmployeeDtoValidator>();
        // services.AddScoped<AbstractValidator<LocationDto>, LocationDtoValidator>();
        // services.AddScoped<AbstractValidator<TeamDto>, TeamDtoValidator>();
        // services.AddScoped<AbstractValidator<JobDto>, JobDtoValidator>();
        // services.AddScoped<AbstractValidator<DepartmentDto>, DepartmentDtoValidator>();

        return services;
    }
}