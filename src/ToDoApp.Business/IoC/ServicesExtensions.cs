using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ToDoApp.Business.Services.Contracts;
using ToDoApp.Business.Services.Implementation;

namespace ToDoApp.Business.IoC
{
    public static class ServicesExtensions
    {
        public static IServiceCollection ConfigureBusinessLayer(this IServiceCollection services)
        {
            services.ConfigureAutoMapper()
                .ConfigureServices()
                .ConfigureFluentValidation();

            return services;
        }

        public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }

        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IAppUserService, AppUserService>()
                .AddScoped<IAuthService, AuthService>()
                .AddScoped<ITaskService, TaskService>();

            return services;
        }

        public static IServiceCollection ConfigureFluentValidation(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
