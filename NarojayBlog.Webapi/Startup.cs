using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NarojayBlog.Core;
using NarojayBlog.DatabaseRepository.DbContext;
using NarojayBlog.Webapi.Filters;
using NarojayBlog.Webapi.Helper;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace NarojayBlog.Webapi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            ConfigureRedis();
        }

        private void ConfigureRedis()
        {
            RedisHelper.Instance.Initialize();
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(options =>
            {
                options.Filters.Add<ValidateModelAttribute>();
                options.EnableEndpointRouting = false;
            });
            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "NarojayBlogAPI",
                    Version = "v1",
                    Description = "restful api for narojay blog"
                });


            });
            var connectionString = Configuration.GetConnectionString("pgsql");
            services.AddDbContext<NarojayContext>(options => options.UseNpgsql(connectionString));
            services.AddManager();
            services.AddMappings();
            services.AddRepositories();
            services.AddCors();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseSwaggerUI(swaggerUiOptions =>
            {
                swaggerUiOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "NarojayBlogAPI.1.0");
                swaggerUiOptions.DocExpansion(DocExpansion.None);
            });
            app.UseSwagger();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseHttpsRedirection();
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
