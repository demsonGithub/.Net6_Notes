namespace MiddlewareDemo.Middleware
{
    public class MyMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<MyMiddleware> _logger;

        public MyMiddleware(RequestDelegate next, ILogger<MyMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            using (_logger.BeginScope("TraceIdentifier:{TraceIdentifier}", context.TraceIdentifier))
            {
                _logger.LogInformation("开始执行");

                await _next(context);

                _logger.LogInformation("执行结束");
            }
        }
    }
}