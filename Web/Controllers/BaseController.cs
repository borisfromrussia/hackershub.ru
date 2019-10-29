using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Loggers;
using Web.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Web.Controllers
{
    public class BaseController : Controller
    {
        protected readonly ICustomLogger _logger;
        protected readonly AppSettings _settings;

        public BaseController(IServiceProvider provider)
        {
            _logger = provider.GetService<ICustomLogger>();
            _settings = provider.GetService<IOptions<AppSettings>>()?.Value;
        }

    }
}
