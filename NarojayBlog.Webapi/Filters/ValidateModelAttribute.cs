using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace NarojayBlog.Webapi.Filters
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 参数校验
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new ValidationFailedResult(context.ModelState);
            }
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            switch (context.Result)
            {
                case ValidationFailedResult _:
                    break;
                case ObjectResult objectResult:
                    objectResult.Value = new NormalResponseModel(code: context?.HttpContext?.Response?.StatusCode, data: objectResult?.Value);
                    context.Result = objectResult;
                    break;
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
        public class ValidationFailedResultModel : BaseResponseModel
        {
            public ValidationFailedResultModel(ModelStateDictionary modelState)
            {
                Code = (int)HttpStatusCode.BadRequest;
                Message = modelState.Keys
                    .SelectMany(key => modelState[key].Errors.Select(x => x.ErrorMessage)).FirstOrDefault();
                ErrorDetail = modelState.Keys
                    .SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage)))
                    .ToList();
                Result = string.Empty;
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
