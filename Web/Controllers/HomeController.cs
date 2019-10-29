using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Filters;
using Web.Models;
using Services;


namespace Web.Controllers
{

    [ServiceFilter(typeof(AuthFilter))]
    public class HomeController : Controller
    {
        public HomeController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }
 
    }
}
