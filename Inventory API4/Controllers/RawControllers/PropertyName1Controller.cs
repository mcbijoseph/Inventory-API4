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
    public class PropertyName1Controller : ApiController
    {
        I_005_invRefPropertyName2BL<_005_invRefPropertyName2Domain> cat3 = new _005_invRefPropertyName2BL();

        [HttpPost]
        [DomainValidatorFilter]
        public object Post([FromBody]_005_invRefPropertyName2Domain body)
        {
            return Json(cat3.Command(new _005_invRefPropertyName2Domain(), "insert"));
        }
    }
}
