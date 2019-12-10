using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Security.Authentication;

namespace NarojayBlog.Webapi.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new ValidationFailedResult(context.ModelState);
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Result is ValidationFailedResult)
            {
                var objectResult = context.Result as ObjectResult;
                context.Result = objectResult;
            }
            else
            {
                var objectResult = context.Result as ObjectResult;
             
                context.Result = new OkObjectResult(new BaseResultModel(code: objectResult?.StatusCode, result: objectResult?.Value));
            }
        }



        public class ValidationFailedResult : ObjectResult
        {

            public ValidationFailedResult(ModelStateDictionary modelState)
                : base(new ValidationFailedResultModel(modelState))
            {
                StatusCode = StatusCodes.Status400BadRequest;
            }
        }
        public class ValidationFailedResultModel : BaseResultModel
        {
            public ValidationFailedResultModel(ModelStateDictionary modelState)
            {
                Code = 422;
                Message = "参数不合法";
                Result = modelState.Keys
                    .SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage)))
                    .ToList();
                ReturnStatus = ReturnStatus.Fail;
            }
        }
        public class ValidationError
        {
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public string Field { get; }
            public string Message { get; }
            public ValidationError(string field, string message)
            {
                Field = field != string.Empty ? field : null;
                Message = message;
            }
        }
    }
}
