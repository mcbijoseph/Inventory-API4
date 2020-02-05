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
    /// NewItemHeaderList
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class NewItemHeaderListController : ApiController
    {
        I_007_invNewItemHeaderListBL<_007_invNewItemHeaderListDomain> cat3;

        public NewItemHeaderListController(I_007_invNewItemHeaderListBL<_007_invNewItemHeaderListDomain> _cat3) 
        {
            cat3 = _cat3;
        }

        /// <summary>
        /// Add new NewItemHeaderList
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        public IHttpActionResult Post([FromBody]_007_invNewItemHeaderListDomain body)
        {
            return Json(cat3.Command(body, Command.Insert));
        }

        //Update
        /// <summary>
        /// Update NewItemHeaderList by ID with JSON Body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        public IHttpActionResult Put(int id, [FromBody]_007_invNewItemHeaderListDomain body)
        {
            body.ID = id;
            return Json(cat3.Command(body, Command.Update));
        }

        /// <summary>
        /// Delete Specific NewItemHeaderList
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(MessageViewDomain))]
        public IHttpActionResult Delete(int id)
        {
            ///body.ID = id;
            return Json(cat3.Delete(id));
        }

        /// <summary>
        /// Get List of NewItemHeaderList
        /// </summary>
        /// <returns>List</returns>
        [ResponseType(typeof(IEnumerable<_001_invRefCategory1Domain>))]
        public IHttpActionResult Get()
        {
            var result = cat3.Get();
            /*
             * 
             */

            return Ok(result);
        }

        /// <summary>
        /// Get Specific NewItemHeaderList by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1 JSON or NULL</returns>
        [ResponseType(typeof(_001_invRefCategory1Domain))]
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
