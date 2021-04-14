using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Platform.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Platform.platform
{
    public class WeatherEndpoint
    {
        private IResponseFormatter formatter;
        public WeatherEndpoint(IResponseFormatter responseFormatter)
        {
            formatter = responseFormatter;
        }
        public async Task Endpoint(HttpContext context)
        {
            await formatter.Format(context, "Endpoint Class: It is cloudy in Milan");
        }
    }
}

    //public static  async Task Endpoint(HttpContext context)
    //{
    //    IResponseFormatter formatter =
    //    context.RequestServices.GetRequiredService < IResponseFormatter > ();
    //    await formatter.Format(context, "Endpoint Class: It is cloudy in Milan");
    //}

