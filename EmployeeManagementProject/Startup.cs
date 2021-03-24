using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagementProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EmployeeManagementProject
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(_config.GetConnectionString("EmployeeDBConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 10;
                options.Password.RequiredUniqueChars = 3;
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<AppDbContext>();


            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                options.Filters.Add(new AuthorizeFilter(policy));


            });
            //services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
            services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();


            services.AddAuthorization(options =>
            {
                options.AddPolicy("DeleteRolePolicy",
                    policy => policy.RequireClaim("Delete Role"));
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");

                //app.UseStatusCodePagesWithRedirects("/Error/{0}");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }

            // Add Default Files Middleware
            //app.UseDefaultFiles();
            // Add Static Files Middleware
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();


            //app.UseRouting();
            app.UseMvcWithDefaultRoute();
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            //});
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hachemxx");
            //});
        }
    }
}
