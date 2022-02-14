using System;
using System.Collections.Generic;

namespace Analytics.Models.Entities
{
    public partial class Code
    {
        public Code()
        {
            PageVisitBrowserCode = new HashSet<PageVisit>();
            PageVisitPlatformCode = new HashSet<PageVisit>();
            Visitor = new HashSet<Visitor>();
        }

        public int CodeId { get; set; }
        public int CodeGroupId { get; set; }
        public string Value { get; set; }
        public string DisplayValue { get; set; }
        public bool IsActive { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual CodeGroup CodeGroup { get; set; }
        public virtual ICollection<PageVisit> PageVisitBrowserCode { get; set; }
        public virtual ICollection<PageVisit> PageVisitPlatformCode { get; set; }
        public virtual ICollection<Visitor> Visitor { get; set; }
    }
}
