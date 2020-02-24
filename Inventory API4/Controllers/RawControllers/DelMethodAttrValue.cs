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

namespace Inventory_API4.Controllers.RawControllers
{
    /// <summary>
    /// DelMethodAttrValue
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DelMethodAttrValueController : ApiController
    {
        I_008a_invRefDelMethodAttrValueBL<_008a_invRefDelMethodAttrValueDomain> cat1;

        public DelMethodAttrValueController(I_008a_invRefDelMethodAttrValueBL<_008a_invRefDelMethodAttrValueDomain> _001)
        {
            cat1 = _001;
        }
        /// <summary>
        /// Add new DelMethodAttrValue
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess("DelMethodAttrValue", "Insert")]
        public IHttpActionResult Post([FromBody]_008a_invRefDelMethodAttrValueDomain body)
        {
            return Json(cat1.Command(body, Command.Insert));
        }

        //Update
        /// <summary>
        /// Update DelMethodAttrValue by ID with JSON Body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess( "DelMethodAttrValue", "Update")]
        public IHttpActionResult Put(int id, [FromBody]_008a_invRefDelMethodAttrValueDomain body)
        {
            body.ID = id;
            return Json(cat1.Command(body, Command.Update));
        }

        /// <summary>
        /// Delete Specific DelMethodAttrValue
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess( "DelMethodAttrValue", "Delete")]
        public IHttpActionResult Delete(int id)
        {
            ///body.ID = id;
            return Json(cat1.Delete(id));
        }

        /// <summary>
        /// Get List of DelMethodAttrValue
        /// </summary>
        /// <returns>List</returns>
        [ResponseType(typeof(IEnumerable<_008a_invRefDelMethodAttrValueDomain>))]
        [AuthRoleAccess( "DelMethodAttrValue", "SelectList")]
        public IHttpActionResult Get()
        {
            var result = cat1.Get();
            /*
             * 
             */

            return Ok(result);
        }

        /// <summary>
        /// Get Specific DelMethodAttrValue by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1 JSON or NULL</returns>
        [ResponseType(typeof(_008a_invRefDelMethodAttrValueDomain))]
        [AuthRoleAccess("DelMethodAttrValue", "Select")]
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
