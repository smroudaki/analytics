using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Analytics.Models.ViewModels
{
    public class EditAccountViewModel : CreateAccountViewModel
    {
        public Guid AccountGuid { get; set; }
    }
}
