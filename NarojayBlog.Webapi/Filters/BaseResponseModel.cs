namespace NarojayBlog.Webapi.Filters
{
    public abstract class BaseResponseModel
    {
        /// <summary>
        /// 业务码
        /// </summary>
        public int? Code { get; set; }
        /// <summary>
        /// 提示信息(显示界面)
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 错误信息(开发人员看)
        /// </summary>
        public dynamic ErrorDetail { get; set; }
        /// <summary>
        /// 返回结果
        /// </summary>
        public object Result { get; set; }

    }
}