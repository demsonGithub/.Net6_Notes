using Castle.DynamicProxy;

namespace DependencyInjectionAutofac.Aop
{
    public class AutofacAop2 : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("2执行前:" + DateTime.Now);

            invocation.Proceed();

            Console.WriteLine("2执行后:" + DateTime.Now);
        }
    }
}