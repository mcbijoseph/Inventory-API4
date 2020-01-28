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

namespace Inventory_API4.Controllers.RawControllers
{
    /// <summary>
    /// Item Condition
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ItemConditionController : ApiController
    {
        //IProjectBL<ProjectDomainModel> _projectBL = new ProjectBL();
        //attributeDo<_001_invRefCategory1Domain> cat1 = new _001_invRefCategory1BL();
        I_018_invRefItemConditiontBL<_018_invRefItemConditionDomain> attrib = new _018_invRefItemConditiontBL();

        /// <summary>
        /// Add new Item Condition
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        public IHttpActionResult Post([FromBody]_018_invRefItemConditionDomain body)
        {
            return Json(attrib.Command(body, "insert"));
        }

        //Update
        /// <summary>
        /// Update Item Condition by ID with JSON Body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut]
        [DomainValidatorFilter]
        public IHttpActionResult Put(int id, [FromBody]_018_invRefItemConditionDomain body)
        {
            body.ID = id;
            return Json(attrib.Command(body, "update"));
        }

        /// <summary>
        /// Get List of Item Condition
        /// </summary>
        /// <returns>List</returns>
        public IHttpActionResult Get()
        {
            var result = attrib.Get();
            /*
             * 
             */

            return Ok(result);
        }

        /// <summary>
        /// Get Specific Item Condition by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1 JSON or NULL</returns>
        public IHttpActionResult Get(int id)
        {
            var result = attrib.Get(id);
            /*
             * 
             */

            return Ok(result);
        }
    }
}
