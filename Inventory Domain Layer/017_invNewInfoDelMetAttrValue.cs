using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Inventory_Domain_Layer
{
    public class _017_invNewInfoDelMetAttrValueDomain
    {
        [Range(0, int.MaxValue)]
        public int ID { get; set; }

        [Range(0, int.MaxValue)]
        public int DocEntryListID_007 { get; set; }

        [Range(0, int.MaxValue)]
        public int DelMethodAttrID_008 { get; set; }
        public int AttributeValueID_008a { get; set; }

        [Required]
        public string AttributeValue { get; set; }
    }
}
