using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using NarojayBlog.DatabaseRepository.DbContext;
using NarojayBlog.Repository.Repository;

namespace NarojayBlog.Repository.Helper
{
    public static class RepositoryExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ArticleRepository>();
        }
    }
}
