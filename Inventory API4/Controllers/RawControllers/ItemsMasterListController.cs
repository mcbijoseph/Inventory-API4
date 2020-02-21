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
    /// ItemsMasterList
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ItemsMasterListController : ApiController
    {
        I_011_invRefItemsMasterListBL<_011_invRefItemsMasterListDomain> cat3;

        public ItemsMasterListController(I_011_invRefItemsMasterListBL<_011_invRefItemsMasterListDomain> _cat3)
        {
            cat3 = _cat3;
        }

        /// <summary>
        /// Add new ItemsMasterList
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess( "ItemsMasterList", "Insert")]
        public IHttpActionResult Post([FromBody]_011_invRefItemsMasterListDomain body)
        {
            return Json(cat3.Command(body, Command.Insert));
        }

        //Update
        /// <summary>
        /// Update ItemsMasterList by ID with JSON Body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess("ItemsMasterList", "Update")]
        public IHttpActionResult Put(int id, [FromBody]_011_invRefItemsMasterListDomain body)
        {
            body.ID = id;
            return Json(cat3.Command(body, Command.Update));
        }

        [HttpGet]
        [ResponseType(typeof(_011_invRefItemsMasterListDomain))]
        [Route("api/ItemsMasterList/ItemsbyProjects/{id}")]
        [AuthRoleAccess("ItemsMasterList", "Select")]
        public IHttpActionResult ItemsbyProjects(int id)
        {
            var result = cat3.GetbyProjectID(id);
            /*
             *
             */

            return Ok(result);
        }

        /// <summary>
        /// Delete Specific ItemsMasterList
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess("ItemsMasterList", "Delete")]
        public IHttpActionResult Delete(int id)
        {
            ///body.ID = id;
            return Json(cat3.Delete(id));
        }

        /// <summary>
        /// Get List of ItemsMasterList
        /// </summary>
        /// <returns>List</returns>
        [ResponseType(typeof(IEnumerable<_011_invRefItemsMasterListDomain>))]
        [AuthRoleAccess("ItemsMasterList", "SelectList")]
        public IHttpActionResult Get()
        {
            var result = cat3.Get();
            /*
             * 
             */

            return Ok(result);
        }

        /// <summary>
        /// Get Specific ItemsMasterList by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1 JSON or NULL</returns>
        [ResponseType(typeof(_011_invRefItemsMasterListDomain))]
        [AuthRoleAccess("ItemsMasterList", "Select")]
        public IHttpActionResult Get(int id)
        {
            var result = cat3.Get(id);
            /*
             *
             */

            return Ok(result);
        }

        [HttpGet]
        [Route("api/ItemsMasterList/Search")]
        [ResponseType(typeof(_011_invRefItemsMasterListDomain))]
        [AuthRoleAccess("ItemsMasterList", "Select")]
        public IHttpActionResult Search(string q)
        {
            var result = cat3.Search(q);
            /*
             *
             */

            return Ok(result);
        }

    }
}
