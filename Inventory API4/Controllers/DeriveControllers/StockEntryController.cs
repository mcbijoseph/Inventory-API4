using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Inventory_Domain_Layer;

namespace Inventory_API4.Controllers.DeriveControllers
{
    public class StockEntryController : ApiController
    {
        public _007_invRefDocEntryListDomain _007_InvRefDocEntryListDomain { get; set; }
        public _013_invItemsEntryListDomain[] _013_InvItemsEntryListDomain { get; set; }
    }
}
