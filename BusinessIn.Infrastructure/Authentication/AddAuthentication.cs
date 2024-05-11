using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace BusinessIn.Infrastructure.Authentication;

public static class AddAuthentication {
    public static void AddJwtAuthentication(this IServiceCollection services, JwtSettings settings) {
        services.AddAuthentication(options => {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options => {
            options.TokenValidationParameters = new TokenValidationParameters {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = settings.Issuer,
                ValidAudience = settings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.AccessTokenKey))
            };

            options.Events = new JwtBearerEvents {
                OnAuthenticationFailed = context => {
                    var exception = context.Exception;
                    Console.WriteLine($"TokenEx ===> {exception.GetType()}: {exception.Message}");
                    var isExpired = exception is SecurityTokenExpiredException;
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    context.Response.WriteAsync(isExpired ? "Expired token" : "Invalid token");

                    return Task.CompletedTask;
                }
            };
        });
    }
}