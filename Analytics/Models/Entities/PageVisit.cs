using System;
using System.Collections.Generic;

namespace Analytics.Models.Entities
{
    public partial class PageVisit
    {
        public int PageVisitId { get; set; }
        public int VisitorId { get; set; }
        public int LogId { get; set; }
        public int BrowserCodeId { get; set; }
        public int PlatformCodeId { get; set; }
        public string PageUrl { get; set; }
        public string Referrer { get; set; }
        public string WindowSize { get; set; }
        public string BrowserInfo { get; set; }
        public string UserAgent { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual Code BrowserCode { get; set; }
        public virtual Log Log { get; set; }
        public virtual Code PlatformCode { get; set; }
    }
}
