using System.Web.Http.Cors;
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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ItemsEntryListController : ApiController
    {
        I_013_invItemsEntryListBL<_013_invItemsEntryListDomain> cat3 = new _013_invItemsEntryListBL();
        [HttpPost]
        [DomainValidatorFilter]
        public IHttpActionResult Post([FromBody]_013_invItemsEntryListDomain body)
        {
            return Json(cat3.Command(body, "insert"));
        }

        public IHttpActionResult Get()
        {
            var result = cat3.Get();
            /*
             * 
             */

            return Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            var result = cat3.Get(id);
            /*
             *
             */

            return Ok(result);
        }
    }
}
