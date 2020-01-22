using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Inventory_Domain_Layer
{
    public class _008_invRefEntryDate
    {
        [Range(0, int.MaxValue)]
        public int ID { get; set; }
        [Required]
        public DateTime EntryDate { get; set; }
        [Range(0, int.MaxValue)]
        public int IELID_013 { get; set; }
    }
}
