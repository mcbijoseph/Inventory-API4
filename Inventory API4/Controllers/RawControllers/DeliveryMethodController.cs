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
    /// DeliveryMethod
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DeliveryMethodController : ApiController
    {
        //IProjectBL<ProjectDomainModel> _projectBL = new ProjectBL();
        //attributeDo<_001_invRefCategory1Domain> cat1 = new _001_invRefCategory1BL();
        I_010_invRefDeliveryMethodBL<_010_invRefDeliveryMethodDomain> attrib = new _010_invRefDeliveryMethodBL();

        /// <summary>
        /// Add new DeliveryMethod
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        public IHttpActionResult Post([FromBody]_010_invRefDeliveryMethodDomain body)
        {
            return Json(attrib.Command(body, "insert"));
        }

        //Update
        /// <summary>
        /// Update DeliveryMethod by ID with JSON BODY
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut]
        [DomainValidatorFilter]
        public IHttpActionResult Put(int id, [FromBody]_010_invRefDeliveryMethodDomain body)
        {
            body.ID = id;
            return Json(attrib.Command(body, "update"));
        }

        /// <summary>
        /// Get List of DeliveryMethod
        /// </summary>
        /// <returns>List</returns>
        public IHttpActionResult Get()
        {
            var result = attrib.Get();
            /*
             * 
             */

            return Ok(result);
        }

        /// <summary>
        /// Get Specific DeliveryMethod by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1 JSON or NULL</returns>
        public IHttpActionResult Get(int id)
        {
            var result = attrib.Get(id);
            /*
             * 
             */

            return Ok(result);
        }
    }
}
