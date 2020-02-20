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
    /// FormTransferList
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FormTransferListController : ApiController
    {
        I_031_invRefFormTransferListBL<_031_invRefFormTransferListDomain> cat1;

        public FormTransferListController(I_031_invRefFormTransferListBL<_031_invRefFormTransferListDomain> _001)
        {
            cat1 = _001;
        }
        /// <summary>
        /// Add new FormTransferList
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        [Auth("POST", "FormTransferList", "Insert")]
        public IHttpActionResult Post([FromBody]_031_invRefFormTransferListDomain body)
        {
            return Json(cat1.Command(body, Command.Insert));
        }

        //Update
        /// <summary>
        /// Update FormTransferList by ID with JSON Body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        [Auth("PUT", "FormTransferList", "Update")]
        public IHttpActionResult Put(int id, [FromBody]_031_invRefFormTransferListDomain body)
        {
            body.ID = id;
            return Json(cat1.Command(body, Command.Update));
        }

        /// <summary>
        /// Delete Specific FormTransferList
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(MessageViewDomain))]
        [Auth("DELETE", "FormTransferList", "Delete")]
        public IHttpActionResult Delete(int id)
        {
            ///body.ID = id;
            return Json(cat1.Delete(id));
        }

        /// <summary>
        /// Get List of FormTransferList
        /// </summary>
        /// <returns>List</returns>
        [ResponseType(typeof(IEnumerable<_031_invRefFormTransferListDomain>))]
        [Auth("GET", "FormTransferList", "SelectList")]
        public IHttpActionResult Get()
        {
            var result = cat1.Get();
            /*
             * 
             */

            return Ok(result);
        }

        /// <summary>
        /// Get Specific FormTransferList by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1 JSON or NULL</returns>
        [ResponseType(typeof(_031_invRefFormTransferListDomain))]
        [Auth("GET", "FormTransferList", "Select")]
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
