﻿using System;
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
    /// TransferedItemsDetails
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TransferedItemsDetailsController : ApiController
    {
        I_022_invTransferedItemsDetailsBL<_022_invTransferedItemsDetailsDomain> attrib;

        public TransferedItemsDetailsController(I_022_invTransferedItemsDetailsBL<_022_invTransferedItemsDetailsDomain> _attrib)
        {
            attrib = _attrib;
        }
        /// <summary>
        /// Add new TransferedItemsDetails
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        public IHttpActionResult Post([FromBody]_022_invTransferedItemsDetailsDomain body)
        {
            return Json(attrib.Command(body, Command.Insert));
        }

        //Update
        /// <summary>
        /// Update TransferedItemsDetails by ID with JSON Body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        public IHttpActionResult Put(int id, [FromBody]_022_invTransferedItemsDetailsDomain body)
        {
            body.ID = id;
            return Json(attrib.Command(body, Command.Update));
        }

        /// <summary>
        /// Delete Specific TransferedItemsDetails
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
        /// Get List of TransferedItemsDetails
        /// </summary>
        /// <returns>List</returns>
        [ResponseType(typeof(IEnumerable<_022_invTransferedItemsDetailsDomain>))]
        public IHttpActionResult Get()
        {
            var result = attrib.Get();
            /*
             * 
             */

            return Ok(result);
        }

        /// <summary>
        /// Get Specific TransferedItemsDetails by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1 JSON or NULL</returns>
        [ResponseType(typeof(_022_invTransferedItemsDetailsDomain))]
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