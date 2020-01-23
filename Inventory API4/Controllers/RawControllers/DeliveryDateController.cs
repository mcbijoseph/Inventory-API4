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
    public class DeliveryDateController : ApiController
    {
        I_007_invRefDeliveryDateBL<_007_invRefDeliveryDateDomain> cat3 = new _007_invRefDeliveryDateBL();
        [HttpPost]
        [DomainValidatorFilter]
        public object Post([FromBody]_007_invRefDeliveryDateDomain body)
        {
            return Json(cat3.Command(new _007_invRefDeliveryDateDomain(), "insert"));
        }
    }
}
