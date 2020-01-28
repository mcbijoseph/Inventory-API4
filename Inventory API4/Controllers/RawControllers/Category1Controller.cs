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
    /// Category1
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Category1Controller : ApiController
    {
        I_001_invRefCategory1BL<_001_invRefCategory1Domain> cat1 = new _001_invRefCategory1BL();
        
        //view
        /// <summary>
        /// Add new Category1
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        public IHttpActionResult Post([FromBody]_001_invRefCategory1Domain body)
        {
            return Json(cat1.Command(body, "insert"));
        }

        //Update
        /// <summary>
        /// Update Category1 by ID with JSON Body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut]
        [DomainValidatorFilter]
        public IHttpActionResult Put(int id, [FromBody]_001_invRefCategory1Domain body)
        {
            body.ID = id;
            return Json(cat1.Command(body, "update"));
        }

        /// <summary>
        /// Get List of Category1
        /// </summary>
        /// <returns>List</returns>
        public IHttpActionResult Get()
        {
            var result = cat1.Get();
            /*
             * 
             */

            return Ok(result);
        }

        /// <summary>
        /// Get Specific Category1 by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1 JSON or NULL</returns>
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
