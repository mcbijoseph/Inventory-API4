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

namespace Inventory_API4.Controllers
{
    /// <summary>
    /// PropertyName2
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PropertyName2Controller : ApiController
    {
        //IProjectBL<ProjectDomainModel> _projectBL = new ProjectBL();
        //attributeDo<_001_invRefCategory1Domain> cat1 = new _001_invRefCategory1BL();
        //I_006_invRefAttributeBL<_006_invRefAttributeDomain> attrib = new _006_invRefAttributeBL();
        I_005_invRefPropertyName2BL<_005_invRefPropertyName2Domain> attrib = new _005_invRefPropertyName2BL();

        /// <summary>
        /// Add new PropertyName2
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        public IHttpActionResult Post([FromBody]_005_invRefPropertyName2Domain body)
        {
            return Json(attrib.Command(body, "insert"));
        }

        //Update
        /// <summary>
        /// Update PropertyName2 by ID with JSON Body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut]
        [DomainValidatorFilter]
        public IHttpActionResult Put(int id, [FromBody]_005_invRefPropertyName2Domain body)
        {
            body.ID = id;
            return Json(attrib.Command(body, "update"));
        }

        /// <summary>
        /// Delete Specific PropertyName2
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Delete(int id)
        {
            ///body.ID = id;
            return Json(attrib.Delete(id));
        }

        /// <summary>
        /// Get List of PropertyName2
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
        /// Get Specific PropertyName2 by ID
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
