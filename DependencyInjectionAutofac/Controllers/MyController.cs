using Autofac.Extras.DynamicProxy;
using DependencyInjectionAutofac.Aop;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjectionAutofac.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MyController : ControllerBase
    {
        private readonly ITestService _testService;

        public MyController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpGet]
        public IActionResult Test()
        {
            var result = _testService.AddNum(55, 66);
            return Ok(result);
        }
    }
}