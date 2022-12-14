using Castle.DynamicProxy;

namespace DependencyInjectionAutofac.Aop
{
    public class AutofacAop : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("执行前:" + DateTime.Now);

            invocation.Proceed();

            Console.WriteLine("执行后:" + DateTime.Now);
        }
    }
}