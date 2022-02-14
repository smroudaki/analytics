using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Analytics.Common;
using Analytics.Models;
using Analytics.Models.Entities;
using Analytics.Models.Enums;
using Analytics.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Analytics.Controllers
{
    public class VistorController : Controller
    {
        private readonly AnalyticsContext _context;

        public VistorController(AnalyticsContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            List<Model_VistorList> _Vistor = new List<Model_VistorList>();

            foreach (var item in _context.Visitor.OrderBy(a => a.VisitorId).Take(100))
            {
                _Vistor.Add(new Model_VistorList()
                {
                    ID = item.VisitorId,
                    IP = item.IpAddress.Ip,
                    Type = item.TypeCode.DisplayValue,
                    DateTime = item.CreationDate.ToPeString("yyyy/MM/dd HH:MM")
                });
            }

            return View(_Vistor);
        }

        [HttpPost]
        public ActionResult GetVisitor()
        {
            int start = Convert.ToInt32(HttpContext.Request.Query["start"]);
            int length = Convert.ToInt32(HttpContext.Request.Query["length"]);
            string searchValue = HttpContext.Request.Query["search[value]"];
            string sortColumnName = HttpContext.Request.Query["columns["] + HttpContext.Request.Query["order[0][column]"] + HttpContext.Request.Query["][name]"];
            string sortDirection = HttpContext.Request.Query["order[0][dir]"];

            List<Model_VistorList> _Vistor = new List<Model_VistorList>();

            foreach (var item in _context.Visitor.OrderBy(a => a.VisitorId).Take(100))
            {
                _Vistor.Add(new Model_VistorList()
                {
                    ID = item.VisitorId,
                    IP = item.IpAddress.Ip,
                    Type = item.TypeCode.DisplayValue,
                    DateTime = item.CreationDate.ToPeString("yyyy/MM/dd HH:MM")
                });
            }

            int totalRows = _Vistor.Count;

            if (!string.IsNullOrEmpty(searchValue))
            {
                _Vistor = _Vistor.Where(x => x.ID.ToString().ToLower().Contains(searchValue.ToLower()) ||
                                               x.ID.ToString().ToLower().Contains(searchValue.ToLower()) ||
                                               x.IP.ToLower().Contains(searchValue.ToLower()) ||
                                               x.DateTime.ToLower().Contains(searchValue.ToLower()) ||
                                               x.Type.ToLower().Contains(searchValue.ToLower())).ToList();
            }

            int totalRowsAfterFiltering = _Vistor.Count;

            //_Vistor = _Vistor.OrderBy(sortColumnName + " " + sortDirection).ToList();

            _Vistor = _Vistor.Skip(start).Take(length).ToList();

            return Json(new { data = _Vistor, draw = HttpContext.Request.Query["draw"], recordsTotal = totalRows, recordsFiltered = totalRowsAfterFiltering }/*, JsonRequestBehavior.AllowGet*/);
        }
    }
}