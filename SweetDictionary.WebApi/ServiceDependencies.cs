using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using SweetDictionary.Service.Authentications.Services.Abstracts;
using SweetDictionary.Service.Authentications.Services.Concretes;
using SweetDictionary.Service.CacheServices;
using SweetDictionary.Service.Posts.Rules;
using SweetDictionary.Service.Posts.Services.Abstracts;
using SweetDictionary.Service.Posts.Services.Concretes;
using SweetDictionary.Service.Tokens.Services.Abstracts;
using SweetDictionary.Service.Tokens.Services.Concretes;
using SweetDictionary.Service.Users.Services.Abstracts;
using SweetDictionary.Service.Users.Services.Concretes;
using System.Reflection;

namespace SweetDictionary.Service;

public static class ServiceDependencies
{    
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
    {
        services.AddScoped<IPostService, EfPostService>();
        services.AddScoped<IUserService, EfUserService>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddScoped<PostCacheService>();
        services.AddScoped<PostBusinessRules>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddStackExchangeRedisCache(opt =>
        {
            opt.Configuration = "localhost:6379";
            opt.InstanceName = "SweetDictionary";
        });


        return services;
    }
}
