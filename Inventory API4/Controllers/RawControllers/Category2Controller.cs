using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Inventory_Domain_Layer;
using Inventory_API4.Filters;
using InventoryBL;
using System.Web.Http.Cors;

namespace Inventory_API4.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Category2Controller : ApiController
    {
        I_002_invRefCategory2BL<_002_invRefCategory2Domain> cat2 = new _002_invRefCategory2BL();

        [HttpPost]
        [DomainValidatorFilter]
        public IHttpActionResult Post([FromBody]_002_invRefCategory2Domain body)
        {
            return Json(cat2.Command(new _002_invRefCategory2Domain(), "insert"));
        }

        public IHttpActionResult Get()
        {
            var result = cat2.Get();
            /*
             * 
             */

            return Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            var result = cat2.Get(id);
            /*
             *
             */

            return Ok(result);
        }
    }
}
