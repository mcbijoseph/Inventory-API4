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

namespace Inventory_API4.Controllers.RawControllers
{
    /// <summary>
    /// TransInfoOrigin
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TransInfoOriginController : ApiController
    {
        I_022_invTransInfoOriginBL<_022_invTransInfoOriginDomain> attrib;

        public TransInfoOriginController(I_022_invTransInfoOriginBL<_022_invTransInfoOriginDomain> _attrib)
        {
            attrib = _attrib;
        }
        /// <summary>
        /// Add new TransInfoOrigin
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess("TransInfoOrigin", "Insert")]
        public IHttpActionResult Post([FromBody]_022_invTransInfoOriginDomain body)
        {
            return Json(attrib.Command(body, Command.Insert));
        }

        //Update
        /// <summary>
        /// Update TransInfoOrigin by ID with JSON Body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess("TransInfoOrigin", "Update")]
        public IHttpActionResult Put(int id, [FromBody]_022_invTransInfoOriginDomain body)
        {
            body.ID = id;
            return Json(attrib.Command(body, Command.Update));
        }

        /// <summary>
        /// Delete Specific TransInfoOrigin
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess("TransInfoOrigin", "Delete")]
        public IHttpActionResult Delete(int id)
        {
            ///body.ID = id;
            return Json(attrib.Delete(id));
        }

        /// <summary>
        /// Get List of TransInfoOrigin
        /// </summary>
        /// <returns>List</returns>
        [ResponseType(typeof(IEnumerable<_022_invTransInfoOriginDomain>))]
        [AuthRoleAccess( "TransInfoOrigin", "SelectList")]
        public IHttpActionResult Get()
        {
            var result = attrib.Get();
            /*
             * 
             */

            return Ok(result);
        }

        /// <summary>
        /// Get Specific TransInfoOrigin by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1 JSON or NULL</returns>
        [ResponseType(typeof(_022_invTransInfoOriginDomain))]
        [AuthRoleAccess("TransInfoOrigin", "Select")]
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
