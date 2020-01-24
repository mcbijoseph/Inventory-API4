using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Inventory_Domain_Layer;
using Inventory_API4.Filters;
using InventoryBL;

namespace Inventory_API4.Controllers
{
    public class ItemsEntryListController : ApiController
    {
        I_013_invItemsEntryListBL<_013_invItemsEntryListDomain> cat3 = new _013_invItemsEntryListBL();
        [HttpPost]
        [DomainValidatorFilter]
        public object Post([FromBody]_013_invItemsEntryListDomain body)
        {
            return Json(cat3.Command(new _013_invItemsEntryListDomain(), "insert"));
        }

        public IEnumerable<_013_invItemsEntryListDomain> Get()
        {
            return cat3.Get();
        }

        public _013_invItemsEntryListDomain Get(int id)
        {
            return cat3.Get(id);
        }
    }
}
