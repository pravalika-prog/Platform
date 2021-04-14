﻿using Microsoft.AspNetCore.Http;
using Platform.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Platform.platform
{
    public class WeatherMiddleware
    {
        private RequestDelegate next;
        private IResponseFormatter formatter;
        public WeatherMiddleware(RequestDelegate nextDelegate,IResponseFormatter respFormatter)
        {
            next = nextDelegate;
            formatter = respFormatter;
        }
        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path == "/middleware/class")
            {
                //await context.Response
                //.WriteAsync("Middleware Class: It is raining in London");
                await formatter.Format(context,
"Middleware Class: It is raining in London");
            }
            else
            {
                await next(context);
            }
        }
    }
}

    
