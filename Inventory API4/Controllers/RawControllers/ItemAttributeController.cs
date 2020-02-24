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
    /// ItemAttribute
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ItemAttributeController : ApiController
    {

        I_012_invItemAttributeBL<_012_invItemAttributeDomain> cat3;

        public ItemAttributeController(I_012_invItemAttributeBL<_012_invItemAttributeDomain> _cat3)
        {
            cat3 = _cat3;
        }

        /// <summary>
        /// Add new ItemAttribute
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess("ItemAttribute", "Insert")]
        public IHttpActionResult Post([FromBody]_012_invItemAttributeDomain body)
        {
            return Json(cat3.Command(body, Command.Insert));
        }

        //Update
        /// <summary>
        /// Update ItemAttribute by ID with JSON Body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess("ItemAttribute", "Update")]
        public IHttpActionResult Put(int id, [FromBody]_012_invItemAttributeDomain body)
        {
            body.ID = id;
            return Json(cat3.Command(body, Command.Update));
        }

        /// <summary>
        /// Delete Specific ItemAttribute
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess("ItemAttribute", "Delete")]
        public IHttpActionResult Delete(int id)
        {
            ///body.ID = id;
            return Json(cat3.Delete(id));
        }

        /// <summary>
        /// Get List of ItemAttribute
        /// </summary>
        /// <returns>List</returns>
        [ResponseType(typeof(IEnumerable<_001_invRefCategory1Domain>))]
        [AuthRoleAccess("ItemAttribute", "SelectList")]
        public IHttpActionResult Get()
        {
            var result = cat3.Get();
            /*
             * 
             */

            return Ok(result);
        }

        /// <summary>
        /// Get Specific ItemAttribute by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1 JSON OR NULL</returns>
        [ResponseType(typeof(_001_invRefCategory1Domain))]
        [AuthRoleAccess("ItemAttribute", "Select")]
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
