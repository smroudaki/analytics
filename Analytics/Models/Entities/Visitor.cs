using System;
using System.Collections.Generic;

namespace Analytics.Models.Entities
{
    public partial class Visitor
    {
        public Visitor()
        {
            Session = new HashSet<Session>();
        }

        public int VisitorId { get; set; }
        public int IpAddressId { get; set; }
        public int TypeCodeId { get; set; }
        public DateTime CreationDate { get; set; }

        public virtual IpAddress IpAddress { get; set; }
        public virtual Code TypeCode { get; set; }
        public virtual ICollection<Session> Session { get; set; }
    }
}
