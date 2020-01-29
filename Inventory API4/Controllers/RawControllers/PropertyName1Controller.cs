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
    /// PropertyName1
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PropertyName1Controller : ApiController
    {
        I_005_invRefPropertyName2BL<_005_invRefPropertyName2Domain> cat3 = new _005_invRefPropertyName2BL();

        /// <summary>
        /// Add new PropertyName1
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        public IHttpActionResult Post([FromBody]_005_invRefPropertyName2Domain body)
        {
            return Json(cat3.Command(body, "insert"));
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
        public IHttpActionResult Put(int id, [FromBody]_005_invRefPropertyName2Domain body)
        {
            body.ID = id;
            return Json(cat3.Command(body, "update"));
        }

        /// <summary>
        /// Delete Specific PropertyName1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id)
        {
            ///body.ID = id;
            return Json(cat3.Delete(id));
        }

        /// <summary>
        /// Get List of PropertyName1
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
        /// Get Specifc PropertyName1 by ID
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
