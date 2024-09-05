using Explorer.API.Middleware.ExceptionModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;

namespace Explorer.API.Middleware;

public class GlobalExceptionHandler
{
    private readonly RequestDelegate _next;

	public GlobalExceptionHandler(RequestDelegate next)
	{
		_next = next;
	}

	public async Task InvokeAsync(HttpContext context)
	{
		try
		{
			await _next(context);
		}catch(Exception ex)
		{
            ExceptionResponse exceptionResponse = new(ex);
			HttpStatusCode httpStatusCode = ex.ExceptionToStatus();
			await Utils.WriteJsonToHttpResponseAsync(context.Response, httpStatusCode, exceptionResponse);
		}
    }
}
