namespace NarojayBlog.Webapi.Filters
{
    public class NormalResponseModel : BaseResponseModel
    {
        public NormalResponseModel(int? code, object data)
        {
            Code = code;
            Message = string.Empty;
            ErrorDetail = string.Empty;
            Result = data;
        }
    }
}