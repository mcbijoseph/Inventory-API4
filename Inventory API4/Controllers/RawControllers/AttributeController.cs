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

        /// <summary>
        /// Add new Attribute
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        //view
        [HttpPost]
        [DomainValidatorFilter]
        [Auth("POST", "Attribute", "Insert")]
        public IHttpActionResult Post([FromBody]_006_invRefAttributeDomain body)
        {
            return Json(cat1.Command(body, Command.Insert));
        }

        /// <summary>
        /// Update Attribute by ID with JSON BODY
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        //Update
        [HttpPut]
        [DomainValidatorFilter]
        [Auth("PUT", "Attribute", "Update")]
        public IHttpActionResult Put(int id, [FromBody]_006_invRefAttributeDomain body)
        {
            body.ID = id;
            return Json(cat1.Command(body, Command.Update));
        }

        /// <summary>
        /// Get List of Item Attribute
        /// </summary>
        /// <returns>List</returns>
        [Auth("GET", "Attribute", "SelectList")]
        public IHttpActionResult Get()
        {
            var result = cat1.Get();
            /*
             * 
             */

            return Ok(result);
        }

        /// <summary>
        /// Get Specific Item Attribute by ID
        /// </summary>
        /// <param name="id">ID of target</param>
        /// <returns>1 JSON or NULL</returns>
        [Auth("GET", "Attribute", "Select")]
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
