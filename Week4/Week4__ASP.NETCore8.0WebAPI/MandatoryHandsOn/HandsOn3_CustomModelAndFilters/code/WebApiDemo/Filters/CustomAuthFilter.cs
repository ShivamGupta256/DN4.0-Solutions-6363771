using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApiDemo.Filters
{
  public class CustomAuthFilter : ActionFilterAttribute
  {
    public override void OnActionExecuting(ActionExecutingContext context)
    {
      var hasHeader = context.HttpContext.Request.Headers.TryGetValue("Authorization", out var token);
      if (!hasHeader)
      {
        context.Result = new BadRequestObjectResult("Invalid request - No Auth token");
        return;
      }

      if (!token.ToString().Contains("Bearer"))
      {
        context.Result = new BadRequestObjectResult("Invalid request - Token present but Bearer unavailable");
      }
    }
  }
}
