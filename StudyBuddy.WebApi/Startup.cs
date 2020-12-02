using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace StudyBuddy.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //AddLoggerFactory
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
            //AddEnvironment for deployment context/Azure

            //Authentication

            //Repos implementation

            //Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                { 
                 Version = "v1",
                 Title = "StudyBuddy Swagger",
                 Description = "Welcome to the insides of the Study Buddy.Enjoy!"
              });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

            });

            //CORS

            services.AddCors(options =>
              options.AddDefaultPolicy(
                  builder =>
                  {
                      builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                  })
          );



            services.AddControllers().AddNewtonsoftJson(options=> {
               options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
               options.SerializerSettings.MaxDepth = 100;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            using (var scope = app.ApplicationServices.CreateScope())
            {
                //Initialize database here
                var services = scope.ServiceProvider;
            }


            app.UseSwagger();

            //SwaggerUI here later
            
          //  app.UseSwaggerUI(c =>
          //  {
          //      c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
          //  });





            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
           
                using (var scope = app.ApplicationServices.CreateScope())
                {
                  //  var ctx = scope.ServiceProvider.GetService<Context>();
                  //  ctx.Database.EnsureCreated();
                }
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
