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
    /// ItemFullName
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ItemFullNameController : ApiController
    {
        I_003_invRefItemFullNameBL<_003_invRefItemFullNameDomain> cat3;

        public ItemFullNameController(I_003_invRefItemFullNameBL<_003_invRefItemFullNameDomain> _cat3)
        {
            cat3 = _cat3;
        }

        /// <summary>
        /// Add new ItemFullName
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        //[AuthRoleAccess("ItemFullName", "Insert")]
        public IHttpActionResult Post([FromBody]_003_invRefItemFullNameDomain body)
        {
            return Json(cat3.Command(body, Command.Insert));
        }

        //Update
        /// <summary>
        /// Update ItemFullName by ID with JSON Body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        //[AuthRoleAccess("ItemFullName", "Update")]
        public IHttpActionResult Put(int id, [FromBody]_003_invRefItemFullNameDomain body)
        {
            body.ID = id;
            return Json(cat3.Command(body, Command.Update));
        }

        /// <summary>
        /// Delete Specific ItemFullName
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(MessageViewDomain))]
        //[AuthRoleAccess("ItemFullName", "Delete")]
        public IHttpActionResult Delete(int id)
        {
            ///body.ID = id;
            return Json(cat3.Delete(id));
        }

        /// <summary>
        /// Get List of ItemFullName
        /// </summary>
        /// <returns>List</returns>
        [ResponseType(typeof(IEnumerable<_001_invRefCategory1Domain>))]
        //[AuthRoleAccess("ItemFullName", "Select")]
        public IHttpActionResult Get()
        {
            var result = cat3.Get();
            /*
             * 
             */

            return Ok(result);
        }

        /// <summary>
        /// Get Specific ItemFullName by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1 JSON or NULL</returns>
        [ResponseType(typeof(_001_invRefCategory1Domain))]
        //[AuthRoleAccess("ItemFullName", "Select")]
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
