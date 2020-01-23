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
    public class ItemPropListController : ApiController
    {
        I_015_invRefItemPropListBL<_015_invRefItemPropListDomain> cat3 = new _015_invRefItemPropListBL();
        [HttpPost]
        [DomainValidatorFilter]
        public object Post([FromBody]_015_invRefItemPropListDomain body)
        {
            return Json(cat3.Command(new _015_invRefItemPropListDomain(), "insert"));
        }
    }
}
