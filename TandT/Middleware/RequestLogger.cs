using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TandT.Middleware
{
	public class RequestLogger
	{
		private readonly RequestDelegate _next;
		public RequestLogger(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context, ILoggerFactory loggerFactory)
		{
			var logger = loggerFactory.CreateLogger<ConsoleLogger>();
			logger.LogInformation($"Request method is: {context.Request.Method}");
			await _next.Invoke(context);
		}
	}
}
