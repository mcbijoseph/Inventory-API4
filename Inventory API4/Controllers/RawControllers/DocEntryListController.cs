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
    public class DocEntryListController : ApiController
    {
        I_007_invRefDocEntryListBL<_007_invRefDocEntryListDomain> cat3 = new _007_invRefDocEntryListBL();
        [HttpPost]
        [DomainValidatorFilter]
        public IHttpActionResult Post([FromBody]_007_invRefDocEntryListDomain body)
        {
            return Json(cat3.Command(body, "insert"));
        }

        //Update
        [HttpPut]
        [DomainValidatorFilter]
        public IHttpActionResult Put(int id, [FromBody]_007_invRefDocEntryListDomain body)
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