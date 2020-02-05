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
    /// TransMasterList
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TransMasterListController : ApiController
    {
        I_021_invTransMasterListBL<_021_invTransMasterListDomain> attrib;

        public TransMasterListController(I_021_invTransMasterListBL<_021_invTransMasterListDomain> _attrib)
        {
            attrib = _attrib;
        }
        /// <summary>
        /// Add new TransMasterList
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        public IHttpActionResult Post([FromBody]_021_invTransMasterListDomain body)
        {
            return Json(attrib.Command(body, Command.Insert));
        }

        /// <summary>
        /// Add Receive
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        public IHttpActionResult AddReceive([FromBody]_021_invTransMasterListDomain body)
        {
            return Json(attrib.Command(body, Command.Insert, true));
        }


        //Update
        /// <summary>
        /// Update TransMasterList by ID with JSON Body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        public IHttpActionResult Put(int id, [FromBody]_021_invTransMasterListDomain body)
        {
            body.ID = id;
            return Json(attrib.Command(body, Command.Update));
        }

        /// <summary>
        /// Delete Specific TransMasterList
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
        /// Get List of TransMasterList
        /// </summary>
        /// <returns>List</returns>
        [ResponseType(typeof(IEnumerable<_021_invTransMasterListDomain>))]
        public IHttpActionResult Get()
        {
            var result = attrib.Get();
            /*
             * 
             */

            return Ok(result);
        }

        /// <summary>
        /// Get Specific TransMasterList by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1 JSON or NULL</returns>
        [ResponseType(typeof(_021_invTransMasterListDomain))]
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
