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
    /// ReleasedItemDetails
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ReleasedItemDetailsController : ApiController
    {
        I_020_invReleasedItemDetailsBL<_020_invReleasedItemDetailsDomain> attrib;

        public ReleasedItemDetailsController(I_020_invReleasedItemDetailsBL<_020_invReleasedItemDetailsDomain> _attrib)
        {
            attrib = _attrib;
        }
        /// <summary>
        /// Add new ReleasedItemDetails
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        [Auth("POST", "ReleasedItemDetails", "Insert")]
        public IHttpActionResult Post([FromBody]_020_invReleasedItemDetailsDomain body)
        {
            return Json(attrib.Command(body, Command.Insert));
        }

        //Update
        /// <summary>
        /// Update ReleasedItemDetails by ID with JSON Body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        [Auth("PUT", "ReleasedItemDetails", "Update")]
        public IHttpActionResult Put(int id, [FromBody]_020_invReleasedItemDetailsDomain body)
        {
            body.ID = id;
            return Json(attrib.Command(body, Command.Update));
        }

        /// <summary>
        /// Delete Specific ReleasedItemDetails
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(MessageViewDomain))]
        [Auth("DELETE", "ReleasedItemDetails", "Delete")]
        public IHttpActionResult Delete(int id)
        {
            ///body.ID = id;
            return Json(attrib.Delete(id));
        }

        /// <summary>
        /// Get List of ReleasedItemDetails
        /// </summary>
        /// <returns>List</returns>
        [ResponseType(typeof(IEnumerable<_020_invReleasedItemDetailsDomain>))]
        [Auth("GET", "ReleasedItemDetails", "SelectList")]
        public IHttpActionResult Get()
        {
            var result = attrib.Get();
            /*
             * 
             */

            return Ok(result);
        }

        /// <summary>
        /// Get Specific ReleasedItemDetails by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1 JSON or NULL</returns>
        [ResponseType(typeof(_020_invReleasedItemDetailsDomain))]
        [Auth("GET", "ReleasedItemDetails", "Select")]
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
