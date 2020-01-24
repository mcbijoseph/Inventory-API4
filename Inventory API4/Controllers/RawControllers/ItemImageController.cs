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
    public class ItemImageController : ApiController
    {
        I_014_invRefItemImageBL<_014_invRefItemImageDomain>  cat3 = new _014_invRefItemImageBL();
        [HttpPost]
        [DomainValidatorFilter]
        public object Post([FromBody]_014_invRefItemImageDomain body)
        {
            return Json(cat3.Command(new _014_invRefItemImageDomain(), "insert"));
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
