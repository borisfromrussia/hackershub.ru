using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Infrastructure.Loggers;
using Web.Models;
using Web.Services;

namespace Web.Filters
{
    public class GeoIpFilter : IActionFilter
    {
        private readonly AppSettings _appSettings;

        public GeoIpFilter(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings?.Value;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //Block all the incomming requests from not allowed IP ranges
            return Utility.RequestFilters.IpFilter(context);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}
