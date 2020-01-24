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
    public class ItemsMasterListController : ApiController
    {
        I_011_invRefItemsMasterListBL<_011_invRefItemsMasterListDomain> cat3 = new _011_invRefItemsMasterListBL();
        [HttpPost]
        [DomainValidatorFilter]
        public object Post([FromBody]_011_invRefItemsMasterListDomain body)
        {
            return Json(cat3.Command(new _011_invRefItemsMasterListDomain(), "insert"));
        }

        public IEnumerable<_011_invRefItemsMasterListDomain> Get()
        {
            return cat3.Get();
        }

        public _011_invRefItemsMasterListDomain Get(int id)
        {
            return cat3.Get(id);
        }
    }
}
