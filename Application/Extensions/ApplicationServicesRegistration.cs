using Application.Features.Categories.Rules;
using Application.Features.Products.Profiles;
using Application.Features.Products.Rules;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Validation;
using Core.CrossCuttingConcerns.Logging.Serilog;
using Core.CrossCuttingConcerns.Logging.Serilog.Logger;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<ProductBusinessRules>();
            services.AddScoped<CategoryBusinessRules>();
            //services.AddScoped<MsSqlLogger>();

            //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            //services.AddTransient(typeof(IPipelineBehavior<,>),typeof(RequestValidationBehavior<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>),typeof(LogginBehavior<,>));

            //services.AddSingleton<LoggerServiceBase, MsSqlLogger>();
           // services.AddSingleton<LoggerServiceBase, FileLogger>();

            return services;
        }
    }
}
