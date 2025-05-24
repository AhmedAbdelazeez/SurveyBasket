namespace SurveyBasket.Api.Middlwares
{
    public class CustomMiddleWare
    {
        private readonly ILogger<CustomMiddleWare> _logger;
        private readonly RequestDelegate _next;

        public CustomMiddleWare(ILogger<CustomMiddleWare> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            _logger.LogInformation("Processing request");

            await _next(context);

            _logger.LogInformation("Processing request");

        }
    }
}
