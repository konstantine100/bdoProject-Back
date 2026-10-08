using bdoProject.Domain.Common.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace bdoProject.Api.Filters;

public sealed class ResultFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Result is ObjectResult objectResult)
        {
            var resultType = objectResult.Value?.GetType();
            if (resultType != null && resultType.IsGenericType)
            {
                var genericType = resultType.GetGenericTypeDefinition();

                if (genericType == typeof(GreenDonut.Result<>))
                {
                    dynamic result = objectResult.Value!;

                    if (!result.Succeeded)
                    {
                        var errorResult = result.Error;

                        ValidationProblemDetails details = new ValidationProblemDetails()
                        {
                            Detail = errorResult.Message,
                            Status = errorResult.Status,
                        };

                        context.Result = new BadRequestObjectResult(details)
                        {
                            StatusCode = errorResult.StatusCode,
                        };
                    }
                    else
                    {
                        context.Result = new OkObjectResult(result.Value);
                    }
                }
            }
            
            else if (resultType == typeof(Result))
            {
                var result = (Result)objectResult.Value!;
                if (!result.IsSuccess)
                {
                    var errorResult = result.Error!;
                    ValidationProblemDetails details = new ValidationProblemDetails()
                    {
                        Detail =  errorResult.Message,
                        Status = errorResult.Status,
                    };

                    context.Result = new BadRequestObjectResult(details)
                    {
                        StatusCode = errorResult.Status
                    };
                    
                }
                else
                {
                    context.Result = new NoContentResult();
                }
            }
        }
    }
}