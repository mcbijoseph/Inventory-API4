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
    /// PropertyName2
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PropertyName2Controller : ApiController
    {
        //IProjectBL<ProjectDomainModel> _projectBL = new ProjectBL();
        //attributeDo<_001_invRefCategory1Domain> cat1 = new _001_invRefCategory1BL();
        //I_006_invRefAttributeBL<_006_invRefAttributeDomain> attrib = new _006_invRefAttributeBL();
        I_005_invRefPropertyName2BL<_005_invRefPropertyName2Domain> attrib;

        public PropertyName2Controller(I_005_invRefPropertyName2BL<_005_invRefPropertyName2Domain> _attrib)
        {
            attrib = _attrib;
        }

        /// <summary>
        /// Add new PropertyName2
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess("POST", "PropertyName2", "Insert")]
        public IHttpActionResult Post([FromBody]_005_invRefPropertyName2Domain body)
        {
            return Json(attrib.Command(body, Command.Insert));
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
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess("PUT", "PropertyName2", "Update")]
        public IHttpActionResult Put(int id, [FromBody]_005_invRefPropertyName2Domain body)
        {
            body.ID = id;
            return Json(attrib.Command(body, Command.Update));
        }

        /// <summary>
        /// Delete Specific PropertyName2
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess("DELETE", "PropertyName2", "Delete")]
        public IHttpActionResult Delete(int id)
        {
            ///body.ID = id;
            return Json(attrib.Delete(id));
        }

        /// <summary>
        /// Get List of PropertyName2
        /// </summary>
        /// <returns>List</returns>
        [ResponseType(typeof(IEnumerable<_001_invRefCategory1Domain>))]
        [AuthRoleAccess("GET", "PropertyName2", "SelectList")]
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
        [ResponseType(typeof(_001_invRefCategory1Domain))]
        [AuthRoleAccess("GET", "PropertyName2", "Select")]
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
