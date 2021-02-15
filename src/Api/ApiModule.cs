namespace Api
{
    using Autofac;
    using Services;

    public class ApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SampleService>().AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}