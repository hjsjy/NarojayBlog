using System;
using System.Collections.Generic;
using System.Text;

namespace NarojayBlog.Core
{
    public class FriendlyException : Exception
    {
        private bool isSuccess;
        public FriendlyException(string message,bool isSuccess) : base(message)
        {
            this.isSuccess = isSuccess;
        }

    }
}
