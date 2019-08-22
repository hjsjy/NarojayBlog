using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NarojayBlog.Webapi.Helper;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace NarojayBlog.Webapi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Title = "NarojayBlogAPI",
                    Version = "v1",
                    Description = "restful api for narojay blog"
                });
            });
            var connectionString = Configuration.GetConnectionString("pgsql");
            services.AddDbContext<>()
            services.AddMappings();

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
