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
    /// DeliveryMethodAttribute
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DelMethodAttributeController : ApiController
    {
        I_008_invRefDelMethodAttributeBL<_008_invRefDelMethodAttributeDomain> cat3 = new _008_invRefDelMethodAttributeBL();

        /// <summary>
        /// Add new DeliveryMethodAttribute
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        public IHttpActionResult Post([FromBody]_008_invRefDelMethodAttributeDomain body)
        {
            return Json(cat3.Command(body, "insert"));
        }

        //Update
        /// <summary>
        /// Update DeliveryMethodAttribute by ID with JSON Body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut]
        [DomainValidatorFilter]
        public IHttpActionResult Put(int id, [FromBody]_008_invRefDelMethodAttributeDomain body)
        {
            body.ID = id;
            return Json(cat3.Command(body, "update"));
        }

        /// <summary>
        /// Get List of DeliveryMethodAttribute 
        /// </summary>
        /// <returns>List</returns>
        public IHttpActionResult Get()
        {
            var result = cat3.Get();
            /*
             * 
             */

            return Ok(result);
        }

        /// <summary>
        /// Get Specific DeliveryMethodAttribute by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1 JSON or NULL</returns>
        public IHttpActionResult Get(int id)
        {
            var result = cat3.Get(id);
            /*
             *
             */

            return Ok(result);
        }

        /// <summary>
        /// Get Specific DeliveryMethodAttribute by DelMethodID_010
        /// </summary>
        /// <param name="id"></param>
        /// <param name="DelMethod"></param>
        /// <returns>1/Many Json or NULL</returns>
        public IHttpActionResult Get(int id, int DelMethod)
        {
            var result = cat3.GetData(id, DelMethod);
            /*
             *
             */

            return Ok(result);
        }
    }
}
