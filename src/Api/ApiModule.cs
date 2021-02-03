namespace Api
{
    using Api.Services;
    using Api.Services.Contracts;
    using Autofac;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SampleService>().AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
