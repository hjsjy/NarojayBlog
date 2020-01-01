using NarojayBlog.Core;
using System;

namespace NarojayBlog.Webapi.Filters
{
    public class ExceptionResultModel : BaseResponseModel
    {
        public ExceptionResultModel(int? code, Exception exception)
        {
            Code = code;
            Message = exception is TipsException ? exception.Message : "系统错误";
            if (exception.InnerException == null)
                ErrorDetail = exception is TipsException ? string.Empty : exception.Message;
            else
                ErrorDetail = exception.InnerException.Message;
            Result = string.Empty;
        }
    }
}