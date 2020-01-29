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

namespace Inventory_API4.Controllers
{
    /// <summary>
    /// ItemImage
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ItemImageController : ApiController
    {
        I_014_invRefItemImageBL<_014_invRefItemImageDomain>  cat3 = new _014_invRefItemImageBL();

        /// <summary>
        /// Add new ItemImage
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        public IHttpActionResult Post([FromBody]_014_invRefItemImageDomain body)
        {
            return Json(cat3.Command(body, "insert"));
        }

        //Update
        /// <summary>
        /// Update ItemImage by ID with JSON Body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut]
        [DomainValidatorFilter]
        public IHttpActionResult Put(int id, [FromBody]_014_invRefItemImageDomain body)
        {
            body.ID = id;
            return Json(cat3.Command(body, "update"));
        }

        /// <summary>
        /// Delete Specific ItemImage
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id)
        {
            ///body.ID = id;
            return Json(cat3.Delete(id));
        }

        /// <summary>
        /// Get List of ItemImage
        /// </summary>
        /// <returns>List</returns>
        public IHttpActionResult Get()
        {
            var result = cat3.Get();
            /*
             * 
             */

            return Ok(result);
        }

        /// <summary>
        /// Get Specific ItemImage by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1 JSON or NULL</returns>
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
