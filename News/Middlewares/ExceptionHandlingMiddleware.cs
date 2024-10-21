using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using System;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore;


namespace News.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(
        RequestDelegate next,
        ILogger<ExceptionHandlingMiddleware> logger
        )
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(context, exception);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        HttpStatusCode statusCode;
        string message;

        switch (exception)
        {
            case KeyNotFoundException keyNotFoundException:
                statusCode = HttpStatusCode.NotFound;
                message = "Not found";
                _logger.LogError(keyNotFoundException, $"Code: {(int)statusCode} - {message}");
                break;

            case UnauthorizedAccessException unauthorizedAccessException:
                statusCode = HttpStatusCode.Unauthorized;
                message = "Unauthorized";
                _logger.LogError(unauthorizedAccessException, $"Code: {(int)statusCode} - {message}");
                break;
            
            case ArgumentNullException argumentNullException:
                statusCode = HttpStatusCode.BadRequest;
                message = "Parameter cannot be null or empty";
                _logger.LogError(argumentNullException, $"Code: {(int)statusCode} - {message}");
                break;

            case ValidationException validationException:
                statusCode = HttpStatusCode.BadRequest;
                message = validationException.Message;
                _logger.LogError(validationException, $"Code: {(int)statusCode} - {message}");
                break;

            case DbUpdateException dbUpdateException:
                statusCode = HttpStatusCode.InternalServerError;
                message = "Database update failed";
                _logger.LogError(dbUpdateException, $"Code: {(int)statusCode} - {message}");
                break;

            case TimeoutException timeoutException:
                statusCode = HttpStatusCode.RequestTimeout;
                message = "The request timed out";
                _logger.LogError(timeoutException, $"Code: {(int)statusCode} - {message}");
                break;

            case HttpRequestException httpRequestException:
                statusCode = HttpStatusCode.BadGateway;
                message = "Error occurred while making HTTP request";
                _logger.LogError(httpRequestException, $"Code: {(int)statusCode} - {message}");
                break;

            default:
                statusCode = HttpStatusCode.InternalServerError;
                message = "Internal Server Error";
                _logger.LogError($"Code: {(int)statusCode} - {message}");
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)statusCode;

        var result = JsonSerializer.Serialize(new { error = message });
        await context.Response.WriteAsync(result);
    }    
}