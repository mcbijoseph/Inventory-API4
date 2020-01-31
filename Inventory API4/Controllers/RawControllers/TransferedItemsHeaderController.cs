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
    /// TransferedItemsHeader
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TransferedItemsHeaderController : ApiController
    {
        I_021_invTransferedItemsHeaderBL<_021_invTransferedItemsHeaderDomain> attrib;

        public TransferedItemsHeaderController(I_021_invTransferedItemsHeaderBL<_021_invTransferedItemsHeaderDomain> _attrib)
        {
            attrib = _attrib;
        }
        /// <summary>
        /// Add new TransferedItemsHeader
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        public IHttpActionResult Post([FromBody]_021_invTransferedItemsHeaderDomain body)
        {
            return Json(attrib.Command(body, Command.Insert));
        }

        //Update
        /// <summary>
        /// Update TransferedItemsHeader by ID with JSON Body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        public IHttpActionResult Put(int id, [FromBody]_021_invTransferedItemsHeaderDomain body)
        {
            body.ID = id;
            return Json(attrib.Command(body, Command.Update));
        }

        /// <summary>
        /// Delete Specific TransferedItemsHeader
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(MessageViewDomain))]
        public IHttpActionResult Delete(int id)
        {
            ///body.ID = id;
            return Json(attrib.Delete(id));
        }

        /// <summary>
        /// Get List of TransferedItemsHeader
        /// </summary>
        /// <returns>List</returns>
        [ResponseType(typeof(IEnumerable<_021_invTransferedItemsHeaderDomain>))]
        public IHttpActionResult Get()
        {
            var result = attrib.Get();
            /*
             * 
             */

            return Ok(result);
        }

        /// <summary>
        /// Get Specific TransferedItemsHeader by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1 JSON or NULL</returns>
        [ResponseType(typeof(_021_invTransferedItemsHeaderDomain))]
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
