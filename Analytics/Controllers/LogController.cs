using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Analytics.Models;
using Analytics.Common;
using Analytics.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Analytics.Controllers
{
    public class LogController : Controller
    {
        private readonly AnalyticsContext _context;

        public LogController(AnalyticsContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {

            List<Model_LogList> _log = new List<Model_LogList>();

            foreach (var item in _context.Log.OrderBy(a => a.LogId).Take(100).ToList())
            {
                _log.Add(new Model_LogList()
                {
                    ID = item.LogId,
                    DateTime = item.CreationDate.ToPeString("yyyy/MM/dd HH:mm"),
                    IP = item.Ip
                });
            }

            return View(_log);
        }

        [HttpPost]
        public ActionResult GetLog()
        {
            int start = Convert.ToInt32(HttpContext.Request.Query["start"]);
            int length = Convert.ToInt32(HttpContext.Request.Query["length"]);
            string searchValue = HttpContext.Request.Query["search[value]"];
            string sortColumnName = HttpContext.Request.Query["columns["] + HttpContext.Request.Query["order[0][column]"] + HttpContext.Request.Query["][name]"];
            string sortDirection = HttpContext.Request.Query["order[0][dir]"];

            List<Model_LogList> _log = new List<Model_LogList>();

            foreach (var item in _context.Log.OrderBy(a => a.LogId).ToList())
            {
                _log.Add(new Model_LogList()
                {
                    ID = item.LogId,
                    DateTime = item.CreationDate.ToPeString("yyyy/MM/dd HH:mm"),
                    IP = item.Ip
                });

            }

            int totalRows = _log.Count;

            if (!string.IsNullOrEmpty(searchValue))
            {
                _log = _log.Where(x => x.ID.ToString().ToLower().Contains(searchValue.ToLower()) ||
                                               x.ID.ToString().ToLower().Contains(searchValue.ToLower()) ||
                                               x.IP.ToLower().Contains(searchValue.ToLower()) ||
                                               x.DateTime.ToLower().Contains(searchValue.ToLower())).ToList();
            }

            int totalRowsAfterFiltering = _log.Count;

            //_log = _log.OrderBy(sortColumnName + " " + sortDirection).ToList();

            _log = _log.Skip(start).Take(length).ToList();

            return Json(new { data = _log, draw = HttpContext.Request.Query["draw"], recordsTotal = totalRows, recordsFiltered = totalRowsAfterFiltering }/*, JsonRequestBehavior.AllowGet*/);
        }

        [HttpGet]
        public ActionResult LogShow(int ID)
        {
            var q = _context.Log.Where(a => a.LogId == ID).Take(100).SingleOrDefault().RawValue;

            Model_LogShow logShow = new Model_LogShow();

            logShow.Raw = q;

            return PartialView(logShow);
        }
    }
}