namespace DependencyInject
{
    public class TestService : ITestService
    {
        public int AddNum(int x, int y)
        {
            return x + y;
        }
    }
}