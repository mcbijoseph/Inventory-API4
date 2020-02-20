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
    /// Units
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UnitsController : ApiController
    {
        //IProjectBL<ProjectDomainModel> _projectBL = new ProjectBL();
        //attributeDo<_001_invRefCategory1Domain> cat1 = new _001_invRefCategory1BL();
        I_009_invRefUnitsBL<_009_invRefUnitsDomain> attrib;

        public UnitsController(I_009_invRefUnitsBL<_009_invRefUnitsDomain> _attrib)
        {
            attrib = _attrib;
        }

        /// <summary>
        /// Add new Units
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        [Auth("POST", "Units", "Insert")]
        public IHttpActionResult Post([FromBody]_009_invRefUnitsDomain body)
        {
            return Json(attrib.Command(body , Command.Insert));
        }

        //Update
        /// <summary>
        /// Update Units by ID with JSON Body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        [Auth("PUT", "Units", "Update")]
        public IHttpActionResult Put(int id, [FromBody]_009_invRefUnitsDomain body)
        {
            body.ID = id;
            return Json(attrib.Command(body, Command.Update));
        }

        /// <summary>
        /// Delete Specific Units
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(MessageViewDomain))]
        [Auth("DELETE", "Units", "Delete")]
        public IHttpActionResult Delete(int id)
        {
            ///body.ID = id;
            return Json(attrib.Delete(id));
        }

        /// <summary>
        /// Get List of Units
        /// </summary>
        /// <returns>List</returns>
        [ResponseType(typeof(IEnumerable<_001_invRefCategory1Domain>))]
        [Auth("GET", "Units", "SelectList")]
        public IHttpActionResult Get()
        {
            var result = attrib.Get();
            /*
             * 
             */
            
            return Ok(result);
        }

        /// <summary>
        /// Get Specific Units by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1 JSON or NULL</returns>
        [ResponseType(typeof(_001_invRefCategory1Domain))]
        [Auth("GET", "Units", "Select")]
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
