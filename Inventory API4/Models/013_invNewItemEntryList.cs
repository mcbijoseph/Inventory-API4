using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Inventory_API4.Models
{
    public class _013_invNewItemEntryListDomain
    {
        [Range(0, int.MaxValue)]
        public int ID { get; set; }
        public int DocEntryId_007 { get; set; }

        [Range(0, int.MaxValue)]
        public int ItemID_011 { get; set; }
        public int Cat3ID_003 { get; set; }
        public bool hasAttribute { get; set; }

        [Range(0, int.MaxValue)]
        public int UnitID_009 { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }

        [Range(0, int.MaxValue)]
        public int ItemConditionID_018 { get; set; }


        public fnItemFullNameDomain ItemFullName { get; set; }
        public _018_invRefItemConditionDomain Condition
        {
            get; set;
        }

        public _009_invRefUnitsDomain Unit
        {
            get; set;
        }

        public List<_012_invItemAttributeDomain> ItemAttributes
        { get; set; }
       
    }
}
