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
    /// FormHardCopySeries
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FormHardCopySeriesController : ApiController
    {
        I_030_invRefFormHardCopySeriesBL<_030_invRefFormHardCopySeriesDomain> cat1;

        public FormHardCopySeriesController(I_030_invRefFormHardCopySeriesBL<_030_invRefFormHardCopySeriesDomain> _001)
        {
            cat1 = _001;
        }
        /// <summary>
        /// Add new FormHardCopySeries
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess("FormHardCopySeries", "Insert")]
        public IHttpActionResult Post([FromBody]_030_invRefFormHardCopySeriesDomain body)
        {
            return Json(cat1.Command(body, Command.Insert));
        }

        //Update
        /// <summary>
        /// Update FormHardCopySeries by ID with JSON Body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess("FormHardCopySeries", "Update")]
        public IHttpActionResult Put(int id, [FromBody]_030_invRefFormHardCopySeriesDomain body)
        {
            body.ID = id;
            return Json(cat1.Command(body, Command.Update));
        }

        /// <summary>
        /// Delete Specific FormHardCopySeries
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess("FormHardCopySeries", "Delete")]
        public IHttpActionResult Delete(int id)
        {
            ///body.ID = id;
            return Json(cat1.Delete(id));
        }

        /// <summary>
        /// Get List of FormHardCopySeries
        /// </summary>
        /// <returns>List</returns>
        [ResponseType(typeof(IEnumerable<_030_invRefFormHardCopySeriesDomain>))]
        [AuthRoleAccess("FormHardCopySeries", "SelectList")]
        public IHttpActionResult Get()
        {
            var result = cat1.Get();
            /*
             * 
             */

            return Ok(result);
        }

        /// <summary>
        /// Get Specific FormHardCopySeries by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1 JSON or NULL</returns>
        [ResponseType(typeof(_030_invRefFormHardCopySeriesDomain))]
        [AuthRoleAccess( "FormHardCopySeries", "Select")]
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
