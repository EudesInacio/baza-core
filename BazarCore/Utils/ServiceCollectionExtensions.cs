using BazarCore.Services.Interfaces;
using BazarCore.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using BazarCore.Data.Repository.Interfaces;

namespace BazarCore.Utils
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCustomServices<TEntity, TValidator>(this IServiceCollection services)
            where TEntity : class, IEntity
            where TValidator : AbstractValidator<TEntity>
        {
            services.AddScoped<IValidator<TEntity>, TValidator>();
            services.AddScoped<IBaseService<TEntity>, BaseService<TEntity, TValidator>>();

        }
        public static IServiceCollection AddValidator<TValidator>(this IServiceCollection services)
        {
          
            return services;
        }
    }
}
