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
using System.Web.Http.Description;

namespace Inventory_API4.Controllers
{
    /// <summary>
    /// Category1
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Category1Controller : ApiController
    {
        I_001_invRefCategory1BL<_001_invRefCategory1Domain> cat1;
        
        public Category1Controller(I_001_invRefCategory1BL<_001_invRefCategory1Domain> _001)
        {
            cat1 = _001;
        }
        /// <summary>
        /// Add new Category1
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        [Auth("POST", "Category1", "Insert")]
        public IHttpActionResult Post([FromBody]_001_invRefCategory1Domain body)
        {

            return Json(cat1.Command(body, Command.Insert));
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
        [ResponseType(typeof(MessageViewDomain))]
        [Auth("PUT", "Category1", "Update")]
        public IHttpActionResult Put(int id, [FromBody]_001_invRefCategory1Domain body)
        {
            body.ID = id;
            return Json(cat1.Command(body, Command.Update));
        }

        /// <summary>
        /// Delete Specific Category1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(MessageViewDomain))]
        [Auth("DELETE", "Category1", "Delete")]
        public IHttpActionResult Delete(int id)
        {
            ///body.ID = id;
            return Json(cat1.Delete(id));
        }

        /// <summary>
        /// Get List of Category1
        /// </summary>
        /// <returns>List</returns>
        [ResponseType(typeof(IEnumerable<_001_invRefCategory1Domain>))]
        [Auth("GET","Category1","SelectList")]
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
        [ResponseType(typeof(_001_invRefCategory1Domain))]
        [Auth("GET","Category1","Select")]
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
