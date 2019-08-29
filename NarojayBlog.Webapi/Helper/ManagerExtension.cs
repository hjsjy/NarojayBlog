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
            services.AddScoped<ICatalogManager, CatalogManager>();
            services.AddScoped<IGuestBookManager, GuestBookManager>();
        }
    }
}
