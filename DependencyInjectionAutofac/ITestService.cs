using Autofac.Extras.DynamicProxy;
using DependencyInjectionAutofac.Aop;

namespace DependencyInjectionAutofac
{
    [Intercept(typeof(AutofacAop))]
    public interface ITestService
    {
        int AddNum(int x, int y);
    }
}