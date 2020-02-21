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
using System.Web.Http.Description;

namespace Inventory_API4.Controllers
{
    /// <summary>
    /// NewItemEntryList
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class NewItemEntryListController : ApiController
    {
        I_013_invNewItemEntryListBL<_013_invNewItemEntryListDomain> cat3;

        public NewItemEntryListController(I_013_invNewItemEntryListBL<_013_invNewItemEntryListDomain> _cat3)
        {
            cat3 = _cat3;
        }

        /// <summary>
        /// Add new ItemsEntryList
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess("POST", "NewItemEntryList", "Insert")]
        public IHttpActionResult Post([FromBody]_013_invNewItemEntryListDomain body)
        {
            return Json(cat3.Command(body, Command.Insert));
        }

        //Update
        /// <summary>
        /// Update NewItemEntryList by ID with JSON Body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess("NewItemEntryList", "Update")]
        public IHttpActionResult Put(int id, [FromBody]_013_invNewItemEntryListDomain body)
        {
            body.ID = id;
            return Json(cat3.Command(body, Command.Update));
        }

        /// <summary>
        /// Delete Specific NewItemEntryList
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess("NewItemEntryList", "Delete")]
        public IHttpActionResult Delete(int id)
        {
            ///body.ID = id;
            return Json(cat3.Delete(id));
        }

        /// <summary>
        /// Get List of NewItemEntryList
        /// </summary>
        /// <returns>List</returns>
        [ResponseType(typeof(IEnumerable<_001_invRefCategory1Domain>))]
        [AuthRoleAccess("NewItemEntryList", "SelectList")]
        public IHttpActionResult Get()
        {
            var result = cat3.Get();
            /*
             * 
             */

            return Ok(result);
        }

        /// <summary>
        /// Get Specific NewItemEntryList by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1 JSON or NULL</returns>
        [ResponseType(typeof(_001_invRefCategory1Domain))]
        [AuthRoleAccess("NewItemEntryList", "Select")]
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
