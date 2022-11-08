using Autofac;
using Autofac.Core;
using Autofac.Extras.DynamicProxy;
using DependencyInjectionAutofac.Aop;
using System.Reflection;

public class AutofacRegisterModule : Autofac.Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<AutofacAop2>();
        builder.RegisterType<AutofacAop>();

        var aopTypes = new List<Type>();
        aopTypes.Add(typeof(AutofacAop2));
        aopTypes.Add(typeof(AutofacAop));

        Assembly assembly = Assembly.GetExecutingAssembly();
        builder.RegisterAssemblyTypes(assembly)
            .AsImplementedInterfaces()
            .InstancePerLifetimeScope()
            .EnableInterfaceInterceptors()  //引用Autofac.Extras.DynamicProxy;
            .InterceptedBy(aopTypes.ToArray());
    }
}