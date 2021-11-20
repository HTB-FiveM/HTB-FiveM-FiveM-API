namespace FiveM.Api.Services
{
    using Autofac;
    using Perigee.Framework.Base.Database;

    public class FiveMServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AllAuthorisedRecordAuthority>().As<IRecordAuthority>().InstancePerLifetimeScope();

        }
    }
}
