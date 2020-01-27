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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DelMethodAttributeController : ApiController
    {
        I_008_invRefDelMethodAttributeBL<_008_invRefDelMethodAttributeDomain> cat3 = new _008_invRefDelMethodAttributeBL();
        [HttpPost]
        [DomainValidatorFilter]
        public IHttpActionResult Post([FromBody]_008_invRefDelMethodAttributeDomain body)
        {
            return Json(cat3.Command(body, "insert"));
        }

        //Update
        [HttpPut]
        [DomainValidatorFilter]
        public IHttpActionResult Put(int id, [FromBody]_008_invRefDelMethodAttributeDomain body)
        {
            body.ID = id;
            return Json(cat3.Command(body, "update"));
        }

        public IHttpActionResult Get()
        {
            var result = cat3.Get();
            /*
             * 
             */

            return Ok(result);
        }

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