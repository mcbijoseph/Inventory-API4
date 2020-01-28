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
    /// Category2
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Category2Controller : ApiController
    {
        I_002_invRefCategory2BL<_002_invRefCategory2Domain> cat2 = new _002_invRefCategory2BL();

        /// <summary>
        /// Add new Category2
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        public IHttpActionResult Post([FromBody]_002_invRefCategory2Domain body)
        {
            return Json(cat2.Command(body, "insert"));
        }

        //Update
        /// <summary>
        /// Update Category2 by ID with JSON Body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut]
        [DomainValidatorFilter]
        public IHttpActionResult Put(int id, [FromBody]_002_invRefCategory2Domain body)
        {
            body.ID = id;
            return Json(cat2.Command(body, "update"));
        }

        /// <summary>
        /// Get List of Category2
        /// </summary>
        /// <returns>List</returns>
        public IHttpActionResult Get()
        {
            var result = cat2.Get();
            /*
             * 
             */

            return Ok(result);
        }

        /// <summary>
        /// Get Specific Category2 by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1 JSON or NULL</returns>
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
