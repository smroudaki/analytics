using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Analytics.Models;
using Analytics.Common;
using Analytics.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Analytics.Models.Entities;
using Hangfire;

namespace Analytics.Controllers
{
    //[EnableCors("*", "*", "*")]
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class ApiLogController : ControllerBase
    {
        private readonly AnalyticsContext _context;

        public ApiLogController(AnalyticsContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task Post([FromBody] object analiseData)
        {
            if (analiseData != null)
            {
                //string ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                //if (string.IsNullOrEmpty(ip))
                //{
                //    ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
                //}

                Log _Log = new Log
                {
                    RawValue = analiseData.ToString(),
                    Ip = HttpContext.Connection.RemoteIpAddress.ToString()
                };

                _context.Log.Add(_Log);
                await _context.SaveChangesAsync();

                BackgroundJob.Enqueue(() => Test());
            }
        }

        public string Test()
        {
            return "Joon from api";
        }
    }
}
