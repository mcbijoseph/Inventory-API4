using System.Web.Http.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Inventory_Domain_Layer;
using Inventory_API4.Filters;
using InventoryBL;

namespace Inventory_API4.Controllers
{
    /// <summary>
    /// ItemsEntryList
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ItemsEntryListController : ApiController
    {
        I_013_invItemsEntryListBL<_013_invItemsEntryListDomain> cat3 = new _013_invItemsEntryListBL();

        /// <summary>
        /// Add new ItemsEntryList
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        public IHttpActionResult Post([FromBody]_013_invItemsEntryListDomain body)
        {
            return Json(cat3.Command(body, "insert"));
        }

        //Update
        /// <summary>
        /// Update ItemsEntryList by ID with JSON Body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut]
        [DomainValidatorFilter]
        public IHttpActionResult Put(int id, [FromBody]_013_invItemsEntryListDomain body)
        {
            body.ID = id;
            return Json(cat3.Command(body, "update"));
        }

        /// <summary>
        /// Get List of ItemsEntryList
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
        /// Get Specific ItemsEntryList by ID
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
