using System;
using System.Collections.Generic;

namespace Analytics.Models.Entities
{
    public partial class CodeGroup
    {
        public CodeGroup()
        {
            Code = new HashSet<Code>();
        }

        public int CodeGroupId { get; set; }
        public string Key { get; set; }
        public string DisplayKey { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<Code> Code { get; set; }
    }
}
