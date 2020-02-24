using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Inventory_API4.Models;
using Inventory_API4.Filters;
using InventoryBL;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace Inventory_API4.Controllers
{

    /// <summary>
    /// TransItemEntryList
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TransItemEntryListController : ApiController
    {
        I_025_invTransItemEntryListBL<_025_invTransItemEntryListDomain> cat1;

        public TransItemEntryListController(I_025_invTransItemEntryListBL<_025_invTransItemEntryListDomain> _001)
        {
            cat1 = _001;
        }
        /// <summary>
        /// Add new TransItemEntryList
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess("TransItemEntryList", "Insert")]
        public IHttpActionResult Post([FromBody]_025_invTransItemEntryListDomain body)
        {
            return Json(cat1.Command(body, Command.Insert));
        }

        //Update
        /// <summary>
        /// Update TransItemEntryList by ID with JSON Body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess("TransItemEntryList", "Update")]
        public IHttpActionResult Put(int id, [FromBody]_025_invTransItemEntryListDomain body)
        {
            body.ID = id;
            return Json(cat1.Command(body, Command.Update));
        }

        /// <summary>
        /// Delete Specific TransItemEntryList
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess("TransItemEntryList", "Delete")]
        public IHttpActionResult Delete(int id)
        {
            ///body.ID = id;
            return Json(cat1.Delete(id));
        }

        /// <summary>
        /// Get List of TransItemEntryList
        /// </summary>
        /// <returns>List</returns>
        [ResponseType(typeof(IEnumerable<_025_invTransItemEntryListDomain>))]
        [AuthRoleAccess("TransItemEntryList", "SelectList")]
        public IHttpActionResult Get()
        {
            var result = cat1.Get();
            /*
             * 
             */

            return Ok(result);
        }

        /// <summary>
        /// Get Specific TransItemEntryList by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1 JSON or NULL</returns>
        [ResponseType(typeof(_025_invTransItemEntryListDomain))]
        [AuthRoleAccess("TransItemEntryList", "Select")]
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
