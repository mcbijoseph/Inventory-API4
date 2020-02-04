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
    /// TransItemRecievedList
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TransItemRecievedListController : ApiController
    {
        I_026_invTransItemRecievedListBL<_026_invTransItemRecievedListDomain> cat1;

        public TransItemRecievedListController(I_026_invTransItemRecievedListBL<_026_invTransItemRecievedListDomain> _001)
        {
            cat1 = _001;
        }
        /// <summary>
        /// Add new TransItemRecievedList
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        public IHttpActionResult Post([FromBody]_026_invTransItemRecievedListDomain body)
        {
            return Json(cat1.Command(body, Command.Insert));
        }

        //Update
        /// <summary>
        /// Update TransItemRecievedList by ID with JSON Body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        public IHttpActionResult Put(int id, [FromBody]_026_invTransItemRecievedListDomain body)
        {
            body.ID = id;
            return Json(cat1.Command(body, Command.Update));
        }

        /// <summary>
        /// Delete Specific TransItemRecievedList
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(MessageViewDomain))]
        public IHttpActionResult Delete(int id)
        {
            ///body.ID = id;
            return Json(cat1.Delete(id));
        }

        /// <summary>
        /// Get List of TransItemRecievedList
        /// </summary>
        /// <returns>List</returns>
        [ResponseType(typeof(IEnumerable<_026_invTransItemRecievedListDomain>))]
        public IHttpActionResult Get()
        {
            var result = cat1.Get();
            /*
             * 
             */

            return Ok(result);
        }

        /// <summary>
        /// Get Specific TransItemRecievedList by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1 JSON or NULL</returns>
        [ResponseType(typeof(_026_invTransItemRecievedListDomain))]
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
