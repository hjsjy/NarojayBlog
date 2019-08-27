using Microsoft.Extensions.DependencyInjection;
using NarojayBlog.Repository.Repository;

namespace NarojayBlog.Webapi.Helper
{
    public static class RepositoryExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ArticleRepository>();
            services.AddScoped<CatalogRepository>();
        }
    }
}
