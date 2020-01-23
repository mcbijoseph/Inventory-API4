using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Inventory_Domain_Layer
{
    public class _007_invRefDeliveryDateDomain
    {
        [Range(0, int.MaxValue)]
        public int ID { get; set; }
        [Required]
        public DateTime Delivery_Date { get; set; }
        [Range(0, int.MaxValue)]
        public int IELID_013 { get; set; }
    }
}
