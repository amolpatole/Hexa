using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreASPNETRouteMVC.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoreASPNETRouteMVC
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
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddMemoryCache();

            services.AddSingleton<IMemoryCache, MemoryCache>();

            services.AddDistributedMemoryCache();

            services.AddSession(config=>
            {
                config.Cookie.Name = "MySession";
                config.Cookie.HttpOnly = true;
                config.Cookie.MaxAge = TimeSpan.FromSeconds(25);
                config.IdleTimeout = TimeSpan.FromSeconds(20);
            });

            //services.AddDistributedSqlServerCache(config=>
            //{
            //    config.TableName = "CacheTableA";
            //    config.SchemaName = "dbo";
            //    config.ConnectionString = Configuration.GetConnectionString("SqlConnection");
            //});

            //services.AddStackExchangeRedisCache(config =>
            //{
            //    config.InstanceName = Configuration.GetValue<string>("Redis:InstanceName");
            //    config.Configuration = Configuration.GetValue<string>("Redis:Configuration");

            //});

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSingleton<DataService>();
            
            services.AddMvc()
                .AddSessionStateTempDataProvider()
                .AddCookieTempDataProvider()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.Use(async (context, next) =>
            {
                //Form Validation and Header checking done here
                if (context.Request.Headers.ContainsKey("x-samplekey"))
                {
                    context.Items["IsVerified"] = true;
                    context.Items["Description"] = "Requset is verifed for Forgery checking";
                }
                else
                {
                    context.Items["IsVerified"] = false;
                }
                await next.Invoke();
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
