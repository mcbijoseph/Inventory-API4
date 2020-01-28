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
    /// <summary>
    /// Items Attribute
    /// </summary>
    [EnableCors(origins:"*",headers:"*", methods:"*")]
    public class AttributeController : ApiController
    {
        I_006_invRefAttributeBL<_006_invRefAttributeDomain> cat1 = new _006_invRefAttributeBL();
        //view
        [HttpPost]
        [DomainValidatorFilter]
        public IHttpActionResult Post([FromBody]_006_invRefAttributeDomain body)
        {
            return Json(cat1.Command(body, "insert"));
        }

        //Update
        [HttpPut]
        [DomainValidatorFilter]
        public IHttpActionResult Put(int id, [FromBody]_006_invRefAttributeDomain body)
        {
            body.ID = id;
            return Json(cat1.Command(body, "update"));
        }

        public IHttpActionResult Get()
        {
            var result = cat1.Get();
            /*
             * 
             */

            return Ok(result);
        }

        public IHttpActionResult Get(int id)
        {
            var result = cat1.Get(id);
            /*
             *
             */

            return Ok(result);
        }


    }
}
