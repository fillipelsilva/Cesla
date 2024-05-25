using Cesla.Application.Queries.ColaboradorQueries;
using Cesla.Application.Queries.Interfaces;
using Cesla.Application.ViewModels;
using Cesla.Data.Connection;
using Cesla.Data.Context;
using Cesla.Data.Repositorios;
using Cesla.Data.Repositorios.Interfaces;
using Core.Communication.MediatrHandler;
using Core.Data;
using Core.Data.EventSourcing;
using Core.Messages.CommomMessages.Notifications;
using EventSourcing;
using MediatR;
using Microsoft.AspNetCore.DataProtection.Repositories;

namespace Cesla.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            //Service Dependencies
            services.Scan(scan => scan
                      .FromAssemblyOf<ViewModel>()
                      .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Service")))
                      .AsImplementedInterfaces()
                      .WithScopedLifetime());

            //Queries Dependencies
            services.Scan(scan => scan
                      .FromAssemblyOf<ViewModel>()
                      .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Queries")))
                      .AsImplementedInterfaces()
                      .WithScopedLifetime());

            //Repository Dependencies
            services.Scan(scan => scan
                      .FromAssemblyOf<ViewModel>()
                      .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Repository")))
                      .AsImplementedInterfaces()
                      .WithScopedLifetime());

            services.Scan(scan => scan
                      .FromAssemblyOf<CeslaContext>()
                      .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Repository")))
                      .AsImplementedInterfaces()
                      .WithScopedLifetime());

            //Mediatr Dependencies
            services.Scan(scan => scan
                      .FromAssemblyOf<ViewModel>()
                      .AddClasses(classes => classes.AssignableTo(typeof(IRequestHandler<,>)))
                      .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Handler")))
                      .AsImplementedInterfaces()
                      .WithScopedLifetime());

            // Notifications
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            //Mediator
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            //Context
            services.AddScoped<CeslaContext>();
            services.AddScoped<CeslaConnection>();

            // Event Sourcing
            services.AddSingleton<IEventStoreService, EventStoreService>();
            services.AddSingleton<IEventSourcingRepository, EventSourcingRepository>();

            //Repositories
            services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
        }
    }
}
