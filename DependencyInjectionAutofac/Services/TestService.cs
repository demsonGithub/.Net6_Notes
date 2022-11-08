namespace DependencyInjectionAutofac
{
    public class TestService : ITestService
    {
        public int AddNum(int x, int y)
        {
            Console.WriteLine("被执行的方法:" + DateTime.Now);
            return x + y;
        }
    }
}