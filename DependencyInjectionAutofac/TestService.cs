namespace DependencyInjectionAutofac
{
    public class TestService : ITestService
    {
        public int AddNum(int x, int y)
        {
            Console.WriteLine("aabadsasd");
            return x + y;
        }
    }
}