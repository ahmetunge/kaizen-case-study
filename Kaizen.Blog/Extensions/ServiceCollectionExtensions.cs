
using Kaizen.Blog.Business;
using Kaizen.Blog.Business.Interfaces;
using Kaizen.Blog.DataAccess.EFCore;
using Kaizen.Blog.DataAccess.Interfaces;
using Kaizen.Blog.Utilities.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Kaizen.Blog.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddJwtOptions(this IServiceCollection services, IConfiguration configuration)
        {
            JwtSettings jwtSettings = new();

            configuration.Bind(nameof(jwtSettings), jwtSettings);

            services.AddSingleton(jwtSettings);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurity(jwtSettings.SecretKey),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        RequireExpirationTime = false,
                        ValidateLifetime = true
                    };
                });

            return services;
        }
        
        public static IServiceCollection AddSwaggerOptions(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Kaizen.Blog", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Jwt Authorization header using bearer scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
            });


            return services;
        }


        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IIdentityService, IdentityBusiness>();
            services.AddScoped<ITokenCreator, JwtTokenCreator>();
            services.AddScoped<IUnitOfWork, EfCoreUnitOfWork>();
            services.AddScoped<IArticleRepository, EfCoreArticleRepository>();
            services.AddScoped<IArticleService, ArticleBusiness>();
            services.AddScoped<IUserRepository, EfCoreUserRepository>();
            return services;
        } 
        
        public static IServiceCollection AddDbOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<KaizenContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MssqlConnection"));
                options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
            });
            return services;
        }
    }
}
