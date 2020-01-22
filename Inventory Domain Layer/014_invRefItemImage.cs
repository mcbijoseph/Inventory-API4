using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Domain_Layer
{
    class _014_invRefItemImage
    {
        public int ID { get; set; }
        public int ItemID { get; set; }
        public String ImageName { get; set; }
        public String Extension { get; set; }
        public int Order { get; set; }
        public Boolean isProfile { get; set; }
    }
}
