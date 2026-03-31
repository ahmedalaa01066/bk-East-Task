using Autofac;
using EasyTask.Common.Endpoints;
using EasyTask.Common.Requests;
using EasyTask.Data;
using EasyTask.Middlewares;

namespace EasyTask.Configurations;
public class AutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterGeneric(typeof(Repository<>)).InstancePerLifetimeScope();
        builder.RegisterType(typeof(Entities)).InstancePerLifetimeScope();
        builder.RegisterGeneric(typeof(EndpointBaseParameters<>)).InstancePerLifetimeScope();
        builder.RegisterGeneric(typeof(RequestHandlerBaseParameters<>)).InstancePerLifetimeScope();
        builder.RegisterType<TransactionMiddleware>().InstancePerLifetimeScope();
        builder.RegisterType<UserState>().InstancePerLifetimeScope();
    }
}