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
    /// TransInfoDelMetAttrValue
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TransInfoDelMetAttrValueController : ApiController
    {
        I_024_invTransInfoDelMetAttrValueBL<_024_invTransInfoDelMetAttrValueDomain> cat1;

        public TransInfoDelMetAttrValueController(I_024_invTransInfoDelMetAttrValueBL<_024_invTransInfoDelMetAttrValueDomain> _001)
        {
            cat1 = _001;
        }
        /// <summary>
        /// Add new TransInfoDelMetAttrValue
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess("TransInfoDelMetAttrValue", "Insert")]
        public IHttpActionResult Post([FromBody]_024_invTransInfoDelMetAttrValueDomain body)
        {
            return Json(cat1.Command(body, Command.Insert));
        }

        //Update
        /// <summary>
        /// Update TransInfoDelMetAttrValue by ID with JSON Body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess("TransInfoDelMetAttrValue", "Update")]
        public IHttpActionResult Put(int id, [FromBody]_024_invTransInfoDelMetAttrValueDomain body)
        {
            body.ID = id;
            return Json(cat1.Command(body, Command.Update));
        }

        /// <summary>
        /// Delete Specific TransInfoDelMetAttrValue
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess("TransInfoDelMetAttrValue", "Delete")]
        public IHttpActionResult Delete(int id)
        {
            ///body.ID = id;
            return Json(cat1.Delete(id));
        }

        /// <summary>
        /// Get List of TransInfoDelMetAttrValue
        /// </summary>
        /// <returns>List</returns>
        [ResponseType(typeof(IEnumerable<_024_invTransInfoDelMetAttrValueDomain>))]
        [AuthRoleAccess("TransInfoDelMetAttrValue", "SelectList")]
        public IHttpActionResult Get()
        {
            var result = cat1.Get();
            /*
             * 
             */

            return Ok(result);
        }

        /// <summary>
        /// Get Specific TransInfoDelMetAttrValue by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1 JSON or NULL</returns>
        [ResponseType(typeof(_024_invTransInfoDelMetAttrValueDomain))]
        [AuthRoleAccess("TransInfoDelMetAttrValue", "Select")]
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
