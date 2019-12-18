using System;
using System.Net;

namespace NarojayBlog.Webapi.Filters
{
    public class CustomExceptionResultModel : BaseResultModel
    {
        public CustomExceptionResultModel(int? code, Exception exception)
        {
            Code = code;
            Message = exception.InnerException != null ?
                exception.InnerException.Message :
                exception.Message;
            Result = string.Empty;
            ReturnStatus = code == (int)HttpStatusCode.OK ? ReturnStatus.FriendlyError : ReturnStatus.Error;
        }
    }
}
