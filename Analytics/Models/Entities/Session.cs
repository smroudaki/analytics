using System;
using System.Collections.Generic;

namespace Analytics.Models.Entities
{
    public partial class Session
    {
        public int SessionId { get; set; }
        public int VisitorId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual Visitor Visitor { get; set; }
    }
}
