using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Infrastructure.Loggers;
using Web.Models;
using Services;

namespace Web.Controllers
{
    public class ErrorController : BaseController
    {
        public ErrorController(IServiceProvider provider)
            : base(provider)
        {
        }


        [HttpGet("/StatusCode/{statusCode}")]
        public async Task<IActionResult> Index(int statusCode)
        {
            return View(statusCode);
        }

    }
}
