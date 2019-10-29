using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Filters
{
    public class AuthFilter : IActionFilter
    {
        private readonly AppSettings _appSettings;
        public AuthFilter(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings?.Value;
        }


        public void OnActionExecuting(ActionExecutingContext context)
        {
            //TODO Block all the non-authorized requests
            return Utility.RequestFilters.NonAuthorizedFilter(context);
        }


        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}
