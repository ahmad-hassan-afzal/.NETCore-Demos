using EmployeeManagement.Models;
using EmployeeManagement.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement
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
            services.AddIdentity<ApplicationUser, IdentityRole>(options => {
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 3;
                options.SignIn.RequireConfirmedEmail = true;

                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);

            }).AddEntityFrameworkStores<ApplicationDbContext>()
              .AddDefaultTokenProviders();

            services.AddDbContextPool<ApplicationDbContext>(options => options.UseSqlServer(_config.GetConnectionString("EmployeeDB")));
            services.AddMvc(option => option.EnableEndpointRouting = false);//.AddRazorRuntimeCompilation();

            services.AddAuthentication()
                .AddGoogle(options =>
                {
                    options.ClientId = "580907868623-mqooue8dh779i6l5s15koi27ku2u8hmc.apps.googleusercontent.com";
                    options.ClientSecret = "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";
                })
                .AddFacebook(options =>
                {
                    options.AppId = "1073075320169203";
                    options.AppSecret = "83972c97e0f21bb41130febb806e5097";
                });

            // For Custom AccessDenied-Page Path..
            services.ConfigureApplicationCookie(options =>
                options.AccessDeniedPath = new PathString("/Admin/AccessDenied")
            );

            services.AddAuthorization(options =>
            {
                //options.AddPolicy("DeleteRolePolicy",
                //    policy => policy.RequireClaim("Delete Role", "true"));
                //.RequireClaim("Create Role")); // User must have both claims to delete

                //options.AddPolicy("EditRolePolicy",
                //    policy => policy.RequireClaim("Edit Role", "true"));

                options.AddPolicy("DeleteRolePolicy",
                    policy => policy.RequireAssertion(context =>
                        context.User.IsInRole("Admin") &&
                        context.User.HasClaim(c => c.Type == "Delete Role" && c.Value == "true") ||
                        context.User.IsInRole("Super User")
                    ));

                options.AddPolicy("EditRolePolicy",
                    policy => policy.RequireAssertion(context =>
                        context.User.IsInRole("Admin") &&
                        context.User.HasClaim(c => c.Type == "Delete Role" && c.Value == "true") ||
                        context.User.IsInRole("Super User")
                    ));

                // Make Sure that we can't change our own User Roles
                options.AddPolicy("ManageUserRolePolicy",
                    policy => policy.AddRequirements(new ManageAdminAuthorizationPolicyRequirements())
                    );

                options.AddPolicy("CreateRolePolicy",
                    policy => policy.RequireClaim("Create Role", "true"));
            });
            
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddSingleton<IAuthorizationHandler, CanOnlyManageOtherAdmins>();
            services.AddSingleton<IAuthorizationHandler, SuperUserHandler>();

            services.AddSingleton<DataProtectionPurposeStrings>();
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
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            //app.UseMvcWithDefaultRoute();

            //            Conventional Routing

            app.UseMvc(configureRoutes =>
            {
                configureRoutes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

            //            Attribute Routing
            //app.UseMvc();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello");
                //});
                endpoints.MapControllers();
            });
        }
    }
}
