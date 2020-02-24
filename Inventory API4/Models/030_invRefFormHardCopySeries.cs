using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_API4.Models
{
    public class _030_invRefFormHardCopySeriesDomain
    {
        public int ID { get; set; }
        public int FormID_029 { get; set; }
        public int Series { get; set; }
        public bool isUsed { get; set; }
    }
}
