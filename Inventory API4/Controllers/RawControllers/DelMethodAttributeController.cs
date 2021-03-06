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

namespace Inventory_API4.Controllers
{
    /// <summary>
    /// DelMethodAttribute
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DelMethodAttributeController : ApiController
    {
        I_008_invRefDelMethodAttributeBL<_008_invRefDelMethodAttributeDomain> cat3;

        public DelMethodAttributeController(I_008_invRefDelMethodAttributeBL<_008_invRefDelMethodAttributeDomain> _cat3)
        {
            cat3 = _cat3;
        }

        /// <summary>
        /// Add new DelMethodAttribute
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess("DelMethodAttribute", "Insert")]
        public IHttpActionResult Post([FromBody]_008_invRefDelMethodAttributeDomain body)
        {
            return Json(cat3.Command(body, Command.Insert));
        }

        //Update
        /// <summary>
        /// Update DelMethodAttribute by ID with JSON Body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess("DelMethodAttribute", "Update")]
        public IHttpActionResult Put(int id, [FromBody]_008_invRefDelMethodAttributeDomain body)
        {
            body.ID = id;
            return Json(cat3.Command(body, Command.Update));
        }

        /// <summary>
        /// Delete Specific DelMethodAttribute
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess("DelMethodAttribute", "Delete")]
        public IHttpActionResult Delete(int id)
        {
            ///body.ID = id;
            return Json(cat3.Delete(id));
        }

        /// <summary>
        /// Get List of DelMethodAttribute 
        /// </summary>
        /// <returns>List</returns>
        [ResponseType(typeof(IEnumerable<_001_invRefCategory1Domain>))]
        [AuthRoleAccess("DelMethodAttribute", "SelectList")]
        public IHttpActionResult Get()
        {
            var result = cat3.Get();
            /*
             * 
             */

            return Ok(result);
        }

        /// <summary>
        /// Get Specific DelMethodAttribute by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1 JSON or NULL</returns>
        [ResponseType(typeof(_001_invRefCategory1Domain))]
        [AuthRoleAccess("DelMethodAttribute", "Select")]
        public IHttpActionResult Get(int id)
        {
            var result = cat3.Get(id);
            /*
             *
             */

            return Ok(result);
        }

        /// <summary>
        /// Get Specific DelMethodAttribute by DelMethodID_010
        /// </summary>
        /// <param name="id"></param>
        /// <param name="DelMethod"></param>
        /// <returns>1/Many Json or NULL</returns>
        [ResponseType(typeof(_001_invRefCategory1Domain))]
        [AuthRoleAccess("DelMethodAttribute", "Select")]
        public IHttpActionResult Get(int id, int DelMethod)
        {
            var result = cat3.GetData(id, DelMethod);
            /*
             *
             */

            return Ok(result);
        }
    }
}
