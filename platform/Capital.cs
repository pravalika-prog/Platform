using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
namespace Platform.platform
{
    public class Capital
    {
        public static async Task Endpoint(HttpContext context)
        {
            string capital = null;
            string country = context.Request.RouteValues["country"]
            as string;
            switch ((country ?? "").ToLower())
            {
                case "uk":
                    capital = "London";
                    break;
                case "france":
                    capital = "Paris";
                    break;
                case "monaco":
                    LinkGenerator generator =context.RequestServices.GetService<LinkGenerator>();
                    string url =
                    generator.GetPathByRouteValues(context,
                    "population", new { city = country });
                    context.Response.Redirect(url);
                    return;

            }
            //context.Response.Redirect($"/population/{country}")
            //;
            //return;

            if (capital != null)
            {
                await context.Response
                .WriteAsync($"{capital} is the capital of { country}");
               
            }
            else
            {
                context.Response.StatusCode =
                StatusCodes.Status404NotFound;
            }
        }
    }
}

        
                       
  

                

