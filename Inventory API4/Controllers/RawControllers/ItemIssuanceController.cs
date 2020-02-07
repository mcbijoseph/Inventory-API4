using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InventoryBL;

namespace Inventory_API4.Controllers.RawControllers
{
#pragma warning disable 1591
    public class ItemIssuanceController : ApiController
    {
        private IvwItemProjectQuantityBL _Issuance;
        public ItemIssuanceController(IvwItemProjectQuantityBL issuance)
        {
            this._Issuance = issuance;
        }

        [Route("issuance/item/{ProjectID}")]
        public IHttpActionResult GetItems(int ProjectID)
        {
            return Ok(_Issuance.GetRecords(ProjectID));
        }
    }
}
