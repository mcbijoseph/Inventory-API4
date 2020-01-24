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
    public class PropertyName1Controller : ApiController
    {
        I_005_invRefPropertyName2BL<_005_invRefPropertyName2Domain> cat3 = new _005_invRefPropertyName2BL();

        [HttpPost]
        [DomainValidatorFilter]
        public object Post([FromBody]_005_invRefPropertyName2Domain body)
        {
            return Json(cat3.Command(new _005_invRefPropertyName2Domain(), "insert"));
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
