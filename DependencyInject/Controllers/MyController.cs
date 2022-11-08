using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MyController : ControllerBase
    {
        private readonly ITestService _testService;
        private readonly OrderService _orderService;

        public MyController(ITestService testService, OrderService orderService)
        {
            _testService = testService;
            _orderService = orderService;
        }

        [HttpGet(Name = "Test")]
        public IActionResult Test()
        {
            int result = _testService.AddNum(5, 6);

            return Ok(result);
        }

        [HttpGet]
        public IActionResult Test2()
        {
            int result = _orderService.SubNum(99, 22);
            return Ok(result);
        }

        [HttpGet(Name = "GetService")]
        public IActionResult GetService([FromServices] IEnumerable<ITestService> services)
        {
            foreach (var item in services)
            {
                Console.WriteLine($"{item.ToString()}-----{item.GetHashCode()}");
            }

            return Ok();
        }
    }
}