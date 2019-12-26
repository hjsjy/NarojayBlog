using System;

namespace NarojayBlog.Core
{
    public class TipsException : Exception
    {

        public TipsException(string message) : base(message)
        {
        }

        public TipsException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}