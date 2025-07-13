using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IO;

namespace WebApiDemo.Filters
{
  public class CustomExceptionFilter : IExceptionFilter
  {
    public void OnException(ExceptionContext context)
    {
      var exception = context.Exception;
      var logPath = "Logs/exceptions.txt";
      Directory.CreateDirectory("Logs");
      File.AppendAllText(logPath, $"{DateTime.Now} - {exception.Message}\n");

      context.Result = new ObjectResult("An internal error occurred.")
      {
        StatusCode = 500
      };
    }
  }
}
