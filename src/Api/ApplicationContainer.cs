namespace Api
{
    using Api.Infrastructure;
    using Api.Services;
    using Api.Services.Contracts;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public static class ApplicationContainer
    {
        public static IServiceCollection RegisterContainers(this IServiceCollection services)
        {
            services.AddScoped<ISampleService, SampleService>();

            return services;
        }
    }
}
