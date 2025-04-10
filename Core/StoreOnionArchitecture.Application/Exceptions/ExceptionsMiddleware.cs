﻿
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using SendGrid.Helpers.Errors.Model;


namespace StoreOnionArchitecture.Application.Exceptions
{
    public class ExceptionsMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            int statusCode = GetStatusCode(exception);
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode;

            if (exception.GetType() == typeof(ValidationException))
            {
                var validationException = (ValidationException)exception;

                return httpContext.Response.WriteAsync(new ExceptionModel
                {
                    Errors = ((ValidationException)exception).Errors
                        .Select(e => e.ErrorMessage),

                    StatusCode = StatusCodes.Status400BadRequest,
                }.ToString());
            }

            List<string> errors = new()
                {
                    exception.Message,
                };

            List<string> nonNullErrors = errors.Where(e => !string.IsNullOrEmpty(e)).ToList();

            var errorResponse = new ExceptionModel
            {
                Errors = nonNullErrors,
                StatusCode = statusCode
            };
            string jsonResponse = System.Text.Json.JsonSerializer.Serialize(errorResponse);
            return httpContext.Response.WriteAsync(jsonResponse);
        }

        private static int GetStatusCode(Exception exception) =>
            exception switch
            {
                BadRequestException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                ValidationException => StatusCodes.Status422UnprocessableEntity,
                _ => StatusCodes.Status500InternalServerError
            };
    }
}

