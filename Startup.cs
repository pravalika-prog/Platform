using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Platform.platform;
using Platform.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Platform.Services.TimeStamping;

namespace Platform
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)

        {
        }

        //           services.Configure<RouteOptions>(opts => {
        //               opts.ConstraintMap.Add("countryName", typeof(CountryRouteConstraint));

        //               // services.AddSingleton<IResponseFormatter, HtmlResponseFormatter>();
        //               services.AddScoped<IResponseFormatter, TimeResponseFormatter>
        //();
        //               services.AddScoped<ITimeStamper, DefaultTimeStamper>();
        //           }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseRouting();

            app.UseEndpoints(endpoints => {
                endpoints.MapGet("/cookie", async context =>
                {
                     int counter1 =int.Parse(context.Request.Cookies["counter1"] ?? "0") + 1;
                    
                    context.Response.Cookies.Append("counter1", counter1.ToString(),
                    new CookieOptions
                    {
                        MaxAge = TimeSpan.FromMinutes(30)
                    });
                    int counter2 =
                    int.Parse(context.Request.Cookies["counter2"] ?? "0") + 1;
                    context.Response.Cookies.Append("counter2", counter2.ToString(),
    new CookieOptions
    {
        MaxAge = TimeSpan.FromMinutes(30)
    });
                    await context.Response.WriteAsync($"Counter1: {counter1},Counter2: { counter2}");
});
                endpoints.MapGet("clear", context => {
                    context.Response.Cookies.Delete("counter1");
                    context.Response.Cookies.Delete("counter2") ;
                    context.Response.Redirect("/");
                    //return Task.CompletedTask;
                    return Task.CompletedTask;
                });
                endpoints.MapFallback(async context =>
                await context.Response.WriteAsync("Hello World" +
                ""));
              
});
        }
    }
}
//        public void Configure(IApplicationBuilder app,
//IWebHostEnvironment env,IConfiguration config)
//        {
//            app.UseDeveloperExceptionPage();
//            app.UseRouting();
//            app.Use(async (context, next) =>
//            {
//                string defaultDebug =config["Logging:LogLevel:Default"];
//                await context.Response
//                .WriteAsync($"The config setting is: { defaultDebug} ");
//            });
//        }
//    }
//}

//        public void Configure(IApplicationBuilder app,
//        IWebHostEnvironment env)
//        {
//            app.UseDeveloperExceptionPage();
//            app.UseRouting();
//            app.UseEndpoints(endpoints =>
//            {
//                endpoints.MapGet("/", async context =>
//{
//    await context.Response.WriteAsync("Hello World");
//});
//            });
//        }
//    }
//}
//            app.UseDeveloperExceptionPage();
//            app.UseRouting();
//            app.UseMiddleware<WeatherMiddleware>();
//            //IResponseFormatter formatter = new
//            //TextResponseFormatter();
//            app.Use(async (context, next) =>
//            {
//                if (context.Request.Path == "/middleware/function")
//                {
//                    await formatter.Format(context,
//                    "Middleware Function: It is snowing in Chicago");
//                    //await  TextResponseFormatter.Singleton.Format(context,
//                    //  "Middleware Function: It is snowing in Chicago");
//         //           await TypeBroker.Formatter.Format(context,
//         //"Middleware Function: It is snowing in Chicago");
//                  }
//                else
//                {
//                    await next();
//                }
//            });
//            app.UseEndpoints(endpoints => {
//                app.UseEndpoints(endpoints => {
//                    endpoints.MapGet("{first}/{second}/{third}", async
//                    context => {
//                        await context.Response.WriteAsync("Request Was Routed\n");
//                    foreach (var kvp in context.Request.RouteValues)
//                        {
//                            await context.Response
//        .WriteAsync($"{kvp.Key}: {kvp.Value}\n");
//                        }
//                    });
//                    endpoints.MapGet("capital/{country}",
//                    Capital.Endpoint);
//                    endpoints.MapGet("population/{city}",
//                    Population.Endpoint)
//                    .WithMetadata(new RouteNameMetadata("population"));
//                });
//                app.Use(async (context, next) => {
//                    await context.Response.WriteAsync("Terminal Middleware  Reached");
//});
//                //endpoints.MapGet("/endpoint/class",
//                //WeatherEndpoint.Endpoint);
//                //endpoints.MapWeather("/endpoint/class");
//                endpoints.MapGet("/endpoint/function", async context =>
//                {
//                    //await context.Response
//                    //.WriteAsync("Endpoint Function: It is sunny in LA");
//                    //await
//                    //TextResponseFormatter.Singleton.Format(context,
//                    //"Endpoint Function: It is sunny in LA");
//                    //await TypeBroker.Formatter.Format(context,"Endpoint Function: It is sunny in LA");
//                    await formatter.Format(context,"Endpoint Function: It is sunny in LA");
//                });
//            });
//        }
//    }
//}






