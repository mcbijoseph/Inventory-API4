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
    public class ItemCategoryController : ApiController
    {
        I_016_invRefItemCategoryBL<_016_invRefItemCategoryDomain> cat3 = new _016_invRefItemCategoryBL();
        [HttpPost]
        [DomainValidatorFilter]
        public object Post([FromBody]_016_invRefItemCategoryDomain body)
        {
            return Json(cat3.Command(new _016_invRefItemCategoryDomain(), "insert"));
        }

    }
}
