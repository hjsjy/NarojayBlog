﻿using System.IO;
using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NarojayBlog.DatabaseRepository.DbContext;
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
            services.AddDbContext<NarojayContext>(options => options.UseNpgsql(connectionString));
            services.AddManager();
            services.AddMappings();
            services.AddRepositories();
            services.AddCors();     }

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
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod
            ().AllowAnyHeader
            ().AllowAnyHeader
            ());
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
