﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Analytics.Models.ViewModels
{
    public class EditCheckTransactionViewModel : CreateCheckTransactionViewModel
    {
        public Guid TransactionGuid { get; set; }
    }
}
