using System.Text;
using backend.app.Helpers;
using backend.app.Interfaces;
using backend.app.Interfaces.Services;
using backend.app.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace backend.app
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services,
            string tokenKey)
        {

            services.AddCors(options =>
            {
                options.AddPolicy(name: "_myAllowSpecificOrigins", builder =>
                {
                    builder
                    .AllowAnyHeader()
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowCredentials();
                });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            // services.AddScoped<IEmailService, EmailService>(s =>
            // {
            //     return new EmailService(new EmailSettings()
            //     {
            //         Email = emailSettings.GetSection("Email").Value,
            //         Password = emailSettings.GetSection("Password").Value,
            //     });
            // });

            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddScoped<ITokenService, TokenService>(f =>
                new TokenService(tokenKey));

            return services;
        }
    }
}