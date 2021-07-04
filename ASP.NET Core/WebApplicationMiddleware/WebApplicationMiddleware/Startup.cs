using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebApplicationMiddleware
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                logger.LogInformation("UseDeveloperExceptionPage : Incoming request");
                app.UseDeveloperExceptionPage();
                logger.LogInformation("UseDeveloperExceptionPage : Outgoing response");
            }

            app.Use(async (context, next) =>
            {
                logger.LogInformation("MW1: Incoming Request");
                await next();
                logger.LogInformation("MW1: Outgoing Response");
            });

            app.Use(async (context, next) =>
            {
                logger.LogInformation("MW2: Incoming Request");
                await next();
                logger.LogInformation("MW2: Outgoing Response");
            });

            app.Run(async (context) =>
            {
                throw new Exception("Some error processing the request");
                await context.Response.WriteAsync("MW3: Request handled and response produced");
                logger.LogInformation("MW3: Request handled and response produced");
            });

            /*

            if (env.IsDevelopment())
            {
                ilogger.LogInformation("UseDeveloperExceptionPage : Incoming request");
                app.UseDeveloperExceptionPage();
                ilogger.LogInformation("UseDeveloperExceptionPage : Outgoing response");
            }
            app.Use(PrintoConsole1);
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello from 1st Middleware");
            //    await next();//this is a delegate invocation and it is not method
            //});
            app.Run(async (context) =>
            {
                ilogger.LogInformation("Run : Incoming request");
                throw new Exception("Some error processing the request");
                await context.Response.WriteAsync("Hello from 2nd Middleware");//this block of code is nothing but some piece fo work of just like method and hence return type is task.
                ilogger.LogInformation("Run : Outgoing response");
            });
            //app.Run(PrintoConsole);
            */

        }

        public async Task PrintoConsole(HttpContext con)
        {
           // ilogger.LogInformation("PrintoConsole : Incoming request");
            await con.Response.WriteAsync("Hello from method1");
            //ilogger.LogInformation("PrintoConsole : Outgoing response");
        }
        //public async Task CallConsole(HttpContext con, Func<Task> next)
        //{
        //    await con.Response.WriteAsync("Hello from method1");
        //    await next();
        //}
        // public delegate Task RequestDelegate(HttpContext context);


        public async Task PrintoConsole1(HttpContext con,Func<Task> task)
        {
            await con.Response.WriteAsync("Hello from method1");
            await task();
        }
    }
}
