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
    public class ItemAttributeController : ApiController
    {

        I_012_invItemAttributeBL<_012_invItemAttributeDomain> cat3 = new _012_invItemAttrivbuteBL();
        [HttpPost]
        [DomainValidatorFilter]
        public object Post([FromBody]_012_invItemAttributeDomain body)
        {
            return Json(cat3.Command(new _012_invItemAttributeDomain(), "insert"));
        }

        public IEnumerable<_012_invItemAttributeDomain> Get()
        {
            return cat3.Get();
        }

        public _012_invItemAttributeDomain Get(int id)
        {
            return cat3.Get(id);
        }
    }
}
