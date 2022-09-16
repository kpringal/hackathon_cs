using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters
{
    public class ExceptionFilter : ExceptionFilterAttribute
    {
        public override void  OnException(ExceptionContext context)
        {
            //Handle unhandled exception B
            context.Result = new ContentResult
            {
                Content = context.Exception.ToString()
            };
        }
    }
}
