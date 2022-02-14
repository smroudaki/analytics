using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Analytics.Models.Entities
{
    public partial class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string Address { get; set; }
        public DateTime RegisteredDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDelete { get; set; }
    }
}
