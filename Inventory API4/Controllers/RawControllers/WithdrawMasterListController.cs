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

namespace Inventory_API4.Controllers.RawControllers
{

    /// <summary>
    /// WithdrawMasterList
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class WithdrawMasterListController : ApiController
    {
        I_027_invWithdrawMasterListBL<_027_invWithdrawMasterListDomain> cat1;

        public WithdrawMasterListController(I_027_invWithdrawMasterListBL<_027_invWithdrawMasterListDomain> _001)
        {
            cat1 = _001;
        }
        /// <summary>
        /// Add new WithdrawMasterList
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess("WithdrawMasterList", "Insert")]
        public IHttpActionResult Post([FromBody]_027_invWithdrawMasterListDomain body)
        {
            return Json(cat1.Command(body, Command.Insert));
        }

        //Update
        /// <summary>
        /// Update WithdrawMasterList by ID with JSON Body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess("WithdrawMasterList", "Update")]
        public IHttpActionResult Put(int id, [FromBody]_027_invWithdrawMasterListDomain body)
        {
            body.ID = id;
            return Json(cat1.Command(body, Command.Update));
        }

        /// <summary>
        /// Delete Specific WithdrawMasterList
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess( "WithdrawMasterList", "Delete")]
        public IHttpActionResult Delete(int id)
        {
            ///body.ID = id;
            return Json(cat1.Delete(id));
        }

        /// <summary>
        /// Get List of WithdrawMasterList
        /// </summary>
        /// <returns>List</returns>
        [ResponseType(typeof(IEnumerable<_027_invWithdrawMasterListDomain>))]
        [AuthRoleAccess("WithdrawMasterList", "SelectList")]
        public IHttpActionResult Get()
        {
            var result = cat1.Get();
            /*
             * 
             */

            return Ok(result);
        }

        /// <summary>
        /// Get Specific WithdrawMasterList by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1 JSON or NULL</returns>
        [ResponseType(typeof(_027_invWithdrawMasterListDomain))]
        [AuthRoleAccess("WithdrawMasterList", "Select")]
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
