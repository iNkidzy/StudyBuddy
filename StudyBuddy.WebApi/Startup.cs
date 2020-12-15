using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Core.Entity;
using Infrastructure.Data;
using Infrastructure.Data.Helper;
using Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using StudyBuddy.Core.ApplicationService;
using StudyBuddy.Core.ApplicationService.Service;
using StudyBuddy.Core.DomainService;

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

            // if (Environment.IsDevelopment())
            // {   
            //      services.AddDbContext<context>(opt => { opt.UseSqlite("Data Source=StudyBuddy.db"); }
            //       );
            //   }
            //else
            //{
            //    //Azure SQL database:
            //    services.AddDbContext<context>(opt =>
            //        opt.UseSqlServer(Configuration.GetConnectionString("defaultConnection"))
            //        );
            //}



            //Authentication

            //Repos implementation
            services.AddDbContext<StudyBuddyContext>(opt => opt.UseSqlite("Data Source=StudyBuddy.db"));
            services.AddScoped<ICommentRepository, CommentRepo>();
            services.AddScoped<IUserRepository, UserRepo>();
            services.AddScoped<ICourseRepository, CourseRepo>();
            services.AddScoped<ITopicRepository, TopicRepo>();

            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ITopicService, TopicService>();
            services.AddTransient<IDBInitializer, DBInitializer>();

            //services.AddTransient<IDBinitializer, DBinitializer>();

            Byte[] secretBytes = new byte[40];
            Random rand = new Random();
            rand.NextBytes(secretBytes);
            services.AddSingleton<IAuthenticationHelper>(new 
                AuthenticationHelper(secretBytes));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    //ValidAudience = "TodoApiClient",
                    ValidateIssuer = false,
                    //ValidIssuer = "TodoApi",
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretBytes),
                    ValidateLifetime = true, //validate the expiration and not before values in the token
                    ClockSkew = TimeSpan.FromMinutes(5) //5 minute tolerance for the expiration date
                };
            });

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
               options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
               options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
               options.SerializerSettings.MaxDepth = 100;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            using (var scope = app.ApplicationServices.CreateScope())
            {
                
                var services = scope.ServiceProvider;
                var ctx = scope.ServiceProvider.GetService<StudyBuddyContext>();
                var dbInit = services.GetService<IDBInitializer>();
                dbInit.SeedDB(ctx);

            }


            app.UseSwagger();

            

           app.UseSwaggerUI(c =>
           {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });





            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            else
            {

                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<StudyBuddyContext>();
                }
            }


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
