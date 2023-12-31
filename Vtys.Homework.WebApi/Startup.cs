﻿using Microsoft.AspNetCore.Cors.Infrastructure;
using Vtys.Core.DataAccess;
using Vtys.Core.DependencyManagement;
using Vtys.Homework.DataAccess;
using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;

namespace Vtys.Homework.WebApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddControllers().AddNewtonsoftJson();


            services.AddCors(options =>
            {
                options.AddPolicy("reactwebui", policy =>
                {
                    policy.WithOrigins("http://localhost:3000")
                                       .AllowAnyHeader()
                                       .AllowAnyMethod();
                });
            });

            services.AddScoped(x => new DbConnectionInfo()
            {
                Host = "localhost",
                Port = "5432",
                Username = "postgres",
                Password = "123456",
                Database = "vtyshomework"
            });

            var dataAccessDependencyModule = new DataAccessDependencyModule(services);

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            DependencyResolver.BuildServiceProvider(services);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("reactwebui");
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
