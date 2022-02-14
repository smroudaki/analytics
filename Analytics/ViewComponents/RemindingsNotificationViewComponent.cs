using Analytics.Common;
using Analytics.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Analytics.ViewComponents
{
    public class RemindingsNotificationViewComponent : ViewComponent
    {
        private readonly AnalyticsContext context;

        public RemindingsNotificationViewComponent(AnalyticsContext context)
        {
            this.context = context;
        }

        public IViewComponentResult Invoke()
        {
            //var transactions = context.Transaction
            //    .Where(x => !x.IsDelete && x.ReceiptDate > DateTime.Now && x.ReceiptDate < DateTime.Now.AddDays(10) && x.StateCodeGuid == Codes.WaitingState)
            //    .ToList();

            //return View(transactions.Count);
            return View();
        }
    }
}
