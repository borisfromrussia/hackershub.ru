using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Web.Filters;
using Infrastructure.Loggers;
using Web.Models;
using Services;


namespace Web.Controllers

    [EnableCors("AllowAll")]
    [ServiceFilter(typeof(AuthFilter))]
    public class SystemController : BaseController
    {
        public SystemController(IServiceProvider provider)
            : base(provider)
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ServiceFilter(typeof(AdminFilter))]
        [Route("system/awsconfig")]
        [HttpPost]
        public async Task<IActionResult> GetAWSConfigs()
        {
            return Ok(_settings.AWS.settings);
        }


        /// <summary>
        /// Depricated! Who needs all the app settings?!
        /// </summary>
        /// <returns></returns>
        [Route("system/appsettings")]
        [HttpPost]
        public async Task<IActionResult> AppSettings()
        {
            return Ok(_settings.App);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Full database configuration</returns>
        [ServiceFilter(typeof(AdminFilter))]
        [Route("system/dbsettings")]
        [HttpPost]
        public async Task<IActionResult> GetDbSettings()
        {
            return Ok(_settings.Database.Configurations);
        }
    }
}
