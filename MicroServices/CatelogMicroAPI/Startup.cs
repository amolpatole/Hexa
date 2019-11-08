using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CatelogMicroAPI.CustomFormatters;
using CatelogMicroAPI.Infra;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;

namespace CatelogMicroAPI
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
            services.AddScoped<CatalogDbContext>();

            services.AddCors(cors =>
            {
                // Default Policy
                //cors.AddDefaultPolicy(x => x.AllowAnyOrigin()
                //.AllowAnyMethod()
                //.AllowAnyHeader());

                // Custom Policy 1
                cors.AddPolicy("AllowPartners", x =>
                {
                    x.WithOrigins("http://microsoft.com", "https://synegrtics.com")
                    .WithMethods("GET", "POST")
                    .AllowAnyHeader();
                });

                // Custom Policy 2
                cors.AddPolicy("AllowAll", x =>
                {
                    x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Info
                {
                    Title = "Catalog API",
                    Description = "Catalog management API methods for eShop application",
                    Version = "1.0",
                    Contact = new Contact
                    {
                        Name = "Amol Patole",
                        Email = "amolpatole9000@gmail.com",
                        Url = "http://google.com"
                    }
                });
            });

            services.AddAuthentication(auth=>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; // for OAuth to navigate other login page navigation
            })
            //.AddGoogle()
            //.AddFacebook()
            //.AddMicrosoftAccount();
            .AddJwtBearer(jt =>
            {
                jt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration.GetValue<string>("Jwt:issuer"),
                    ValidAudience = Configuration.GetValue<string>("Jwt:audience"),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetValue<string>("Jwt:secret")))
                };
            });

            services.AddMvc(options =>
            {
                options.OutputFormatters.Add(new CsvOutputFormatter());
            })
                .AddXmlDataContractSerializerFormatters()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseCors("AllowPartners");
            app.UseCors("AllowAll");

            app.UseSwagger();

            if (env.IsDevelopment())
            {
                app.UseSwaggerUI(config =>
                {
                    config.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog API");
                    config.RoutePrefix = "";
                });
            }

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
