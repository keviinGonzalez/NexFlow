using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NexFlow.Application.Exceptions;
using NexFlow.Domain.Exceptions;
using System.Net;

namespace NexFlow.Api.Exceptions;

public static class ExceptionMapper
{
    public static ExceptionMappingResult Map(Exception exception)
    {
        return exception switch
        {
            ValidationException validationException =>
                MapValidation(validationException),

            UnauthorizedException unauthorizedException =>
                new ExceptionMappingResult
                {
                    StatusCode = StatusCodes.Status401Unauthorized,
                    Response = new ProblemDetails
                    {
                        Type = "https://nexflow.dev/errors/unauthorized",
                        Title = "Unauthorized",
                        Detail = unauthorizedException.Message,
                        Status = StatusCodes.Status401Unauthorized
                    }
                },

            ForbiddenException forbiddenException =>
                new ExceptionMappingResult
                {
                    StatusCode = StatusCodes.Status403Forbidden,
                    Response = new ProblemDetails
                    {
                        Type = "https://nexflow.dev/errors/forbidden",
                        Title = "Forbidden",
                        Detail = forbiddenException.Message,
                        Status = StatusCodes.Status403Forbidden
                    }
                },

            DomainException domainException =>
                new ExceptionMappingResult
                {
                    StatusCode = StatusCodes.Status409Conflict,
                    Response = new ProblemDetails
                    {
                        Type = "https://nexflow.dev/errors/business-rule",
                        Title = "Business rule violation",
                        Detail = domainException.Message,
                        Status = StatusCodes.Status409Conflict
                    }
                },

            //NotFoundException notFoundException =>
            //    new ExceptionMappingResult
            //    {
            //        StatusCode = StatusCodes.Status404NotFound,
            //        Response = new ProblemDetails
            //        {
            //            Type = "https://nexflow.dev/errors/not-found",
            //            Title = "Resource not found",
            //            Detail = notFoundException.Message,
            //            Status = StatusCodes.Status404NotFound
            //        }
            //    },

            _ => new ExceptionMappingResult
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                Response = new ProblemDetails
                {
                    Type = "https://nexflow.dev/errors/internal-server-error",
                    Title = "Internal Server Error",
                    Detail = "An unexpected error occurred.",
                    Status = StatusCodes.Status500InternalServerError
                }
            }
        };
    }

    private static ExceptionMappingResult MapValidation(ValidationException exception)
    {
        var problemDetails = new ValidationProblemDetails(
            exception.Errors
                .GroupBy(x => x.PropertyName)
                .ToDictionary(
                    g => g.Key,
                    g => g.Select(e => e.ErrorMessage).ToArray()))
        {
            Type = "https://nexflow.dev/errors/validation",
            Title = "Validation failed.",
            Status = StatusCodes.Status400BadRequest
        };

        return new ExceptionMappingResult
        {
            StatusCode = StatusCodes.Status400BadRequest,
            Response = problemDetails
        };
    }
}