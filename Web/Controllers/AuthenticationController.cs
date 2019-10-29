using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Web.Filters;
using Infrastructure.Loggers;
using Web.Models;
using Services;

namespace Web.Controllers
{
    [EnableCors("AllowAll")]
    [ServiceFilter(typeof(GeoIpFilter))]
    public class AuthenticationController : BaseController
    {
        private readonly IAuthenticationService _authService;
        public AuthenticationController(IServiceProvider provider, IAuthenticationService authService)
            : base(provider)
        {
            _authService = authService;
        }

        [HttpGet]
        [Route("authentication/login")]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        [Route("authentication/loginnew")]
        public async Task<IActionResult> LoginNew([FromForm] LoginDtIn data)
        {
            return await _authService.AuthenticationResponseAsync();
        }

        /// <summary>
        /// Will be removed. Someone did a mess here...
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("authentication/login")]
        public async Task<IActionResult> Login([FromForm] LoginDtIn data)
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(_settings.Database.ConnectionString))
                {
                    con.Open();
                    var cmdStr = $"select * from users where username = '{data.Username}' and password = '{data.Password}'";
                    using (MySqlCommand command = new MySqlCommand(cmdStr, con))
                    {
                        command.ExecuteNonQuery();
                        var reader = command.ExecuteReader();
                        if (reader.HasRows)
                            return await _authService.ForceAuthenticationAsync();
                    }
                }

            }
            catch (Exception ex)
            {
                _logger.Error("Something terrible happened here!", ex);
            }

            return BadRequest();
        }

    }



}
