using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Inventory_API4.Models;
using Inventory_API4.Filters;
using InventoryBL;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace Inventory_API4.Controllers
{

    /// <summary>
    /// Category3DefaultAttribute
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Category3DefaultAttributeController : ApiController
    {
        I_033_invRefCategory3DefaultAttributeBL<_033_invRefCategory3DefaultAttributeDomain> cat2;

        public Category3DefaultAttributeController(I_033_invRefCategory3DefaultAttributeBL<_033_invRefCategory3DefaultAttributeDomain> _cat2)
        {
            cat2 = _cat2;
        }

        /// <summary>
        /// Add new Category3DefaultAttribute
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess("Category3DefaultAttribute", "Insert")]
        public IHttpActionResult Post([FromBody]_033_invRefCategory3DefaultAttributeDomain body)
        {
            return Json(cat2.Command(body, Command.Insert));
        }

        //Update
        /// <summary>
        /// Update Category3DefaultAttribute by ID with JSON Body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess("Category3DefaultAttribute", "Update")]
        public IHttpActionResult Put(int id, [FromBody]_033_invRefCategory3DefaultAttributeDomain body)
        {
            body.ID = id;
            return Json(cat2.Command(body, Command.Update));
        }

        /// <summary>
        /// Delete Specific Category3DefaultAttribute
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess("Category3DefaultAttribute", "Delete")]
        public IHttpActionResult Delete(int id)
        {
            ///body.ID = id;
            return Json(cat2.Delete(id));
        }

        /// <summary>
        /// Get List of Category3DefaultAttribute
        /// </summary>
        /// <returns>List</returns>
        [ResponseType(typeof(IEnumerable<_033_invRefCategory3DefaultAttributeDomain>))]
        [AuthRoleAccess("Category3DefaultAttribute", "SelectList")]
        public IHttpActionResult Get()
        {
            var result = cat2.Get();
            /*
             * 
             */

            return Ok(result);
        }

        /// <summary>
        /// Get Specific Category3DefaultAttribute by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1 JSON or NULL</returns>
        [ResponseType(typeof(_033_invRefCategory3DefaultAttributeDomain))]
        [AuthRoleAccess("Category3DefaultAttribute", "Select")]
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
