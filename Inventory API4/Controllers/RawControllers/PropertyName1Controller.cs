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
    /// PropertyName1
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PropertyName1Controller : ApiController
    {
        I_004_invRefPropertyName1BL<_004_invRefPropertyName1Domain> cat3;

        public PropertyName1Controller(I_004_invRefPropertyName1BL<_004_invRefPropertyName1Domain> _cat3)
        {
            cat3 = _cat3;
        }

        /// <summary>
        /// Add new PropertyName1
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        [Auth("POST", "PropertyName1", "Insert")]
        public IHttpActionResult Post([FromBody]_004_invRefPropertyName1Domain body)
        {
            return Json(cat3.Command(body, Command.Insert));
        }

        //Update
        /// <summary>
        /// Update PropertyName1 by ID with JSON Body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        [Auth("PUT", "PropertyName1", "Update")]
        public IHttpActionResult Put(int id, [FromBody]_004_invRefPropertyName1Domain body)
        {
            body.ID = id;
            return Json(cat3.Command(body, Command.Update));
        }

        /// <summary>
        /// Delete Specific PropertyName1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(MessageViewDomain))]
        [Auth("DELETE", "PropertyName1", "Delete")]
        public IHttpActionResult Delete(int id)
        {
            ///body.ID = id;
            return Json(cat3.Delete(id));
        }

        /// <summary>
        /// Get List of PropertyName1
        /// </summary>
        /// <returns>List</returns>
        [ResponseType(typeof(IEnumerable<_004_invRefPropertyName1Domain>))]
        [Auth("GET", "PropertyName1", "SelectList")]
        public IHttpActionResult Get()
        {
            var result = cat3.Get();
            /*
             * 
             */

            return Ok(result);
        }

        /// <summary>
        /// Get Specifc PropertyName1 by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1 JSON or NULL</returns>
        [ResponseType(typeof(_004_invRefPropertyName1Domain))]
        [Auth("GET", "PropertyName1", "Select")]
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
