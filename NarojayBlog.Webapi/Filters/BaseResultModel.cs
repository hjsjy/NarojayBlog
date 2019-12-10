namespace NarojayBlog.Webapi.Filters
{
    public class BaseResultModel
    {
        public BaseResultModel(int? code = null, string message = null, object result = null, ReturnStatus returnStatus = ReturnStatus.Success)
        {
            Code = code;
            Result = result;
            Message = message;
            ReturnStatus = returnStatus;
        }
        public int? Code { get; set; }

        public string Message { get; set; }

        public object Result { get; set; }

        public ReturnStatus ReturnStatus { get; set; }
    }
    public enum ReturnStatus
    {
        Success = 1,
        Fail = 0,
        ConfirmIsContinue = 2,
        Error = 3
    }

}
