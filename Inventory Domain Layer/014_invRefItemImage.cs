using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Inventory_Domain_Layer
{
    public class _014_invRefItemImageDomain
    {
        [Range(0, int.MaxValue)]
        public int ID { get; set; }

        [Range(0, int.MaxValue)]
        public int ItemID_011 { get; set; }

        [Required]
        public String ImageName { get; set; }

        [Required]
        public String Extension { get; set; }

        public int Order { get; set; }

        public Boolean isProfile { get; set; }
    }
}
