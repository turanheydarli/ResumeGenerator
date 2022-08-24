using System.Reflection;
using Application.Services.Catalog;
using Application.Services.Catalog.Interfaces;
using Infrastructure.Persistence;
using Infrastructure.Persistence.EntityFramework;
using Infrastructure.Persistence.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SelectPdf;

namespace Application.System;

public static class ServiceCollectionExtension
{
    public static IServiceCollection InjectApplicationServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

        services.AddScoped<ITemplateService, TemplateService>();
        services.AddScoped<IResumeService, ResumeService>();

        //ServiceTool.Create(services, services.BuildServiceProvider());

        return services;
    }

    public static IServiceCollection AddCustomizedDataStore(this IServiceCollection services)
    {
        services.AddDbContext<ProjectDbContext>(ServiceLifetime.Scoped);

        services.AddScoped<DbContext>(provider => provider.GetService<ProjectDbContext>());

        return services;
    }

    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped(typeof(HtmlToPdf));

        return services;
    }
}