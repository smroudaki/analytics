using Analytics.Common;
using Analytics.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Analytics.Models.Repositories
{
    public class DashboardRepository
    {
        private readonly AnalyticsContext _context;

        public DashboardRepository(AnalyticsContext context)
        {
            _context = context;
        }
    }
}
