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

namespace Inventory_API4.Controllers
{
    /// <summary>
    /// FormList
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FormListController : ApiController
    {
        I_029_invRefFormListBL<_029_invRefFormListDomain> cat1;

        public FormListController(I_029_invRefFormListBL<_029_invRefFormListDomain> _001)
        {
            cat1 = _001;
        }
        /// <summary>
        /// Add new FormList
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess("FormList", "Insert")]
        public IHttpActionResult Post([FromBody]_029_invRefFormListDomain body)
        {
            return Json(cat1.Command(body, Command.Insert));
        }

        //Update
        /// <summary>
        /// Update FormList by ID with JSON Body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess("FormList", "Update")]
        public IHttpActionResult Put(int id, [FromBody]_029_invRefFormListDomain body)
        {
            body.ID = id;
            return Json(cat1.Command(body, Command.Update));
        }

        /// <summary>
        /// Delete Specific FormList
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess("FormList", "Delete")]
        public IHttpActionResult Delete(int id)
        {
            ///body.ID = id;
            return Json(cat1.Delete(id));
        }

        /// <summary>
        /// Get List of FormList
        /// </summary>
        /// <returns>List</returns>
        [ResponseType(typeof(IEnumerable<_029_invRefFormListDomain>))]
        [AuthRoleAccess("FormList", "SelectList")]
        public IHttpActionResult Get()
        {
            var result = cat1.Get();
            /*
             * 
             */

            return Ok(result);
        }

        /// <summary>
        /// Get Specific FormList by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1 JSON or NULL</returns>
        [ResponseType(typeof(_029_invRefFormListDomain))]
        [AuthRoleAccess( "FormList", "Select")]
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
