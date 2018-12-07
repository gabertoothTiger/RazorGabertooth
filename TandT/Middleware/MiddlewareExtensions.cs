using Microsoft.AspNetCore.Builder;

namespace TandT.Middleware
{
	public static class MiddlewareExtensions
	{
		public static IApplicationBuilder UseRequestLogging(this IApplicationBuilder app)
		{
			return app.UseMiddleware<RequestLogger>();
		}
	}
}
