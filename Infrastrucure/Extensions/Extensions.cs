using MediatR;
using System.Reflection;
using Infrastructure.CQRS.Event;
using Infrastructure.Database.EF;
using FluentValidation.AspNetCore;
using Infrastructure.CQRS.Queries;
using Infrastructure.CQRS.Commands;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Infrastructure.CQRS.FluentValidator;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Database.Repository.Abstractions;
using Infrastructure.Database.UnitOfWork.Abstractions;
using Infrastructure.Database.Repository.Implementations;
using Infrastructure.Database.UnitOfWork.Implementations;

namespace Infrastructure.Extentions
{
    public static class Extensions
    {
        public static void AddEF(this IServiceCollection services
            , IConfiguration configuration
            , string conectionSectionName = "DefaultConnection")
        {
            services.AddDbContext<PersonReferenceContext>(options => 
                options.UseLazyLoadingProxies()
                .UseSqlServer(configuration.GetConnectionString(conectionSectionName)));

            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
        }

        public static IServiceCollection AddCQRS(this IServiceCollection services
            , params Assembly[] assemblies)
        {
            services.AddMediatR(assemblies);

            services.AddScoped<ICommandBus, CommandBus>();
            services.AddScoped<IQueryBus, QueryBus>();
            services.AddScoped<IEventBus, EventBus>();

            return services;
        }

        public static IServiceCollection AddFluentValidation(this IServiceCollection services
            , params Assembly[] assemblies)
        {
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddMvc().AddFluentValidation(cfg =>
            {
                cfg.RegisterValidatorsFromAssemblies(assemblies);
            });

            return services;
        }
    }
}