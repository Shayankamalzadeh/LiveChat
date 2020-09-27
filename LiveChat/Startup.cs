using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

using Infrastructure;

using LiveChat.Application;
using LiveChat.Persistance;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.SwaggerUI;

namespace LiveChat
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<LiveChatDBContext>
            (o => o.UseSqlServer(Configuration.
                GetConnectionString("MasterDbConnection")));

            services.AddCors();

            services.AddSwaggerGen(c =>
            {
                c.UseInlineDefinitionsForEnums();
                c.IgnoreObsoleteActions();
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Live Chat",
                    Version = "v1",
                    Description = @"
                ## Introduction
                Live chat using SignalR "
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            services.AddSignalR();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials());
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Live Chat Version 1");
                c.DocExpansion(DocExpansion.None);
            });
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
             
                endpoints.MapHub<SignalR>("/LiveChat");
            });
        }
    }
}
