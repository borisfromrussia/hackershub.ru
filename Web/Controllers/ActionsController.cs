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
using Web.Filters;
using Infrastructure.Loggers;
using Web.Models;
using Services;


namespace Web.Controllers
{
    [EnableCors("AllowAll")]
    [ServiceFilter(typeof(AuthFilter))]
    public class ActionsController : BaseController
    {
        private readonly IActionsService _actionsService;
        public ActionsController(IServiceProvider provider, IActionsService actionsService)
            : base(provider)
        {
            _actionsService = actionsService;
        }

        [Route("actions/lock")]
        [HttpPost]
        public async Task<IActionResult> Lock([FromForm] WebsiteLockDtIn data)
        {
            return await _wsService.TryLock(data);
        }

        [Route("actions/unlock")]
        [HttpPost]
        public async Task<IActionResult> Unlock([FromForm] WebsiteUnlockLockDtIn data)
        {
            return await _wsService.TryUnlock(data);
        }


        [HttpPost]
        [Route("actions/listall")]

        public async Task<IActionResult> ListAll()
        {
            return await _actionsService.All();
        }

    }
}
