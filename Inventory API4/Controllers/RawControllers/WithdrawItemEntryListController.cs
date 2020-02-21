using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Inventory_Domain_Layer;
using Inventory_API4.Filters;
using InventoryBL;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Collections.Generic;

namespace Inventory_API4.Controllers.RawControllers
{

    /// <summary>
    /// WithdrawItemEntryList
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class WithdrawItemEntryListController : ApiController
    {
        I_028_invWithdrawItemEntryListBL<_028_invWithdrawItemEntryListDomain> cat1;

        public WithdrawItemEntryListController(I_028_invWithdrawItemEntryListBL<_028_invWithdrawItemEntryListDomain> _001)
        {
            cat1 = _001;
        }
        /// <summary>
        /// Add new WithdrawItemEntryList
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess("WithdrawItemEntryList", "Insert")]
        public IHttpActionResult Post([FromBody]_028_invWithdrawItemEntryListDomain body)
        {
            return Json(cat1.Command(body, Command.Insert));
        }

        //Update
        /// <summary>
        /// Update WithdrawItemEntryList by ID with JSON Body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess("WithdrawItemEntryList", "Update")]
        public IHttpActionResult Put(int id, [FromBody]_028_invWithdrawItemEntryListDomain body)
        {
            body.ID = id;
            return Json(cat1.Command(body, Command.Update));
        }

        /// <summary>
        /// Delete Specific WithdrawItemEntryList
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess("WithdrawItemEntryList", "Delete")]
        public IHttpActionResult Delete(int id)
        {
            ///body.ID = id;
            return Json(cat1.Delete(id));
        }

        /// <summary>
        /// Get List of WithdrawItemEntryList
        /// </summary>
        /// <returns>List</returns>
        [ResponseType(typeof(IEnumerable<_028_invWithdrawItemEntryListDomain>))]
        [AuthRoleAccess("WithdrawItemEntryList", "SelectList")]
        public IHttpActionResult Get()
        {
            var result = cat1.Get();
            /*
             * 
             */

            return Ok(result);
        }

        /// <summary>
        /// Get Specific WithdrawItemEntryList by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1 JSON or NULL</returns>
        [ResponseType(typeof(_028_invWithdrawItemEntryListDomain))]
        [AuthRoleAccess("WithdrawItemEntryList", "Select")]
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
