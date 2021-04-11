namespace Api
{
    using Autofac;
    using Data.Context;
    using Services;

    public class ApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SampleService>().AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterType<CoreContext>().InstancePerLifetimeScope();
        }
    }
}