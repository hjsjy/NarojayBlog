using Microsoft.Extensions.DependencyInjection;
using NarojayBlog.IManager;

namespace NarojayBlog.Manager.Helper
{
    public static class ManagerExtension
    {
        public static void AddManager(this IServiceCollection services)
        {
            services.AddScoped<IArticleManager, ArticleManager>();
            services.AddScoped<ICatalogManager, CatalogManager>();
        }
    }
}
