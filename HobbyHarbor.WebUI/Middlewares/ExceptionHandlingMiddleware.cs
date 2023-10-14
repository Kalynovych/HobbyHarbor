namespace HobbyHarbor.WebUI.Middlewares
{
	public class ExceptionHandlingMiddleware : IMiddleware
	{
		private readonly ILogger<ExceptionHandlingMiddleware> _logger;

		public ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger)
		{
			_logger = logger;
		}

		public async Task InvokeAsync(HttpContext context, RequestDelegate next)
		{
			try
			{
				await next(context);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);

				context.Response.ContentType = "text/html";
				await context.Response.WriteAsync("<h2>An error occurred while processing your request.</h2>");
			}
		}
	}
}
