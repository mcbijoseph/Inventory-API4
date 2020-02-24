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
    /// TransInfoDestination
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TransInfoDestinationController : ApiController
    {
        I_023_invTransInfoDestinationBL<_023_invTransInfoDestinationDomain> attrib;

        public TransInfoDestinationController(I_023_invTransInfoDestinationBL<_023_invTransInfoDestinationDomain> _attrib)
        {
            attrib = _attrib;
        }
        /// <summary>
        /// Add new TransInfoDestination
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess("TransInfoDestination", "Insert")]
        public IHttpActionResult Post([FromBody]_023_invTransInfoDestinationDomain body)
        {
            return Json(attrib.Command(body, Command.Insert));
        }

        //Update
        /// <summary>
        /// Update TransInfoDestination by ID with JSON Body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess("TransInfoDestination", "Update")]
        public IHttpActionResult Put(int id, [FromBody]_023_invTransInfoDestinationDomain body)
        {
            body.ID = id;
            return Json(attrib.Command(body, Command.Update));
        }

        /// <summary>
        /// Delete Specific TransInfoDestination
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess( "TransInfoDestination", "Delete")]
        public IHttpActionResult Delete(int id)
        {
            ///body.ID = id;
            return Json(attrib.Delete(id));
        }

        /// <summary>
        /// Get List of TransInfoDestination
        /// </summary>
        /// <returns>List</returns>
        [ResponseType(typeof(IEnumerable<_023_invTransInfoDestinationDomain>))]
        [AuthRoleAccess("TransInfoDestination", "SelectList")]
        public IHttpActionResult Get()
        {
            var result = attrib.Get();
            /*
             * 
             */

            return Ok(result);
        }

        /// <summary>
        /// Get Specific TransInfoDestination by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1 JSON or NULL</returns>
        [ResponseType(typeof(_023_invTransInfoDestinationDomain))]
        [AuthRoleAccess("TransInfoDestination", "Select")]
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
