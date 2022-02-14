using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Analytics.Models.Repositories
{
    public class CodesRepository
    {
        private readonly AnalyticsContext _context;

        public CodesRepository(AnalyticsContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetCodesByCodeGroupId(int id)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            var codes = _context.Code
                .Where(x => x.CodeGroupId == id).ToList();

            foreach (var code in codes)
            {
                list.Add(new SelectListItem() { Value = code.CodeId.ToString(), Text = code.DisplayValue });
            }

            return list.AsEnumerable();
        }
    }
}
