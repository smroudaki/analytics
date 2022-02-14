using System;
using System.Collections.Generic;

namespace Analytics.Models.Entities
{
    public partial class IpAddress
    {
        public IpAddress()
        {
            Visitor = new HashSet<Visitor>();
        }

        public int IpAddressId { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public string Ip { get; set; }
        public string Isp { get; set; }

        public virtual ICollection<Visitor> Visitor { get; set; }
    }
}
