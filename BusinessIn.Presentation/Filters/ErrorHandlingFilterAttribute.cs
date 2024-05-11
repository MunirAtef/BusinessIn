using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BusinessIn.Presentation.Filters;

public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute {
    public override void OnException(ExceptionContext context) {
        var exception = context.Exception;
        context.Result = new ObjectResult(new {
            Title = exception.Source,
            Details = exception.Message,
            StatusCode = exception.GetHashCode(),
            TraceId = "TraceId"
        });
        
        context.ExceptionHandled = true;
    }
}