using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NarojayBlog.IManager;
using NarojayBlog.Manager;

namespace NarojayBlog.Webapi.Helper
{
    public static class ManagerExtension
    {
        public static void AddManager(this IServiceCollection services)
        {
            services.AddScoped<IArticleManager, ArticleManager>();
        }
    }
}
