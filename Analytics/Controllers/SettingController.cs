using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Analytics.Models;
using Analytics.Common;
using Analytics.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Analytics.Controllers
{
    public class SettingController : Controller
    {
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult Index()
        {
            return View();
        }
    }
}