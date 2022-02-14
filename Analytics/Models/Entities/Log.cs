using System;
using System.Collections.Generic;

namespace Analytics.Models.Entities
{
    public partial class Log
    {
        public Log()
        {
            PageVisit = new HashSet<PageVisit>();
        }

        public int LogId { get; set; }
        public string RawValue { get; set; }
        public string Ip { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual ICollection<PageVisit> PageVisit { get; set; }
    }
}
