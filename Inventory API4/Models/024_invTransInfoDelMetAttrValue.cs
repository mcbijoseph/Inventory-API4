using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_API4.Models
{
    public class _024_invTransInfoDelMetAttrValueDomain
    {
        public int ID { get; set; }
        public int TransMasterID_021 { get; set; }
        public int DeliveryAttrID_008 { get; set; }
        public int AttributeValueID { get; set; }
        public string AttributeValue { get; set; }
        public Boolean isDestination { get; set; }
        public List<_008a_invRefDelMethodAttrValueDomain> DelMethodAttrValue2 { get; set; }
    }
}
