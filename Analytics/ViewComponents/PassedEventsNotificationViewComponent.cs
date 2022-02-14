using Analytics.Common;
using Analytics.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Analytics.ViewComponents
{
    public class PassedEventsNotificationViewComponent : ViewComponent
    {
        private readonly AnalyticsContext context;

        public PassedEventsNotificationViewComponent(AnalyticsContext context)
        {
            this.context = context;
        }

        public IViewComponentResult Invoke()
        {
            //var transactions = context.Transaction
            //    .Where(x => !x.IsDelete && x.ReceiptDate < DateTime.Now && x.StateCodeGuid == Codes.WaitingState)
            //    .ToList();

            //return View(transactions.Count);
            return View();
        }
    }
}
