using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Vulcano.WebApi.Filters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class ValidateModelAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState
                .Where(ms => ms.Value?.Errors.Count > 0)
                .Select(ms => new { Field = ms.Key, Errors = ms.Value!.Errors.Select(e => e.ErrorMessage) });

            context.Result = new BadRequestObjectResult(new { message = "Dados inválidos", errors });
        }
    }
}
