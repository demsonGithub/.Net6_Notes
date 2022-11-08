using Autofac;
using Autofac.Core;
using Autofac.Extras.DynamicProxy;
using DependencyInjectionAutofac.Aop;
using System.Reflection;

public class AutofacRegisterModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<AutofacAop>();

        Assembly assembly = Assembly.GetExecutingAssembly();
        builder.RegisterAssemblyTypes(assembly)
            .AsImplementedInterfaces()
            .EnableInterfaceInterceptors()
            .InstancePerLifetimeScope();
    }
}