using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ImageAfricaProject.Helpers
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var error = context.ModelState
                    .Where(a => a.Value.Errors.Count > 0)
                    .SelectMany(x => x.Value.Errors).FirstOrDefault();
                    
                context.Result = new BadRequestObjectResult(new
                {
                    status = "fail",
                    message = error.ErrorMessage
                });
                //context.Result = new ValidationFailedResult(context.ModelState);
            }
        }
    }
}
