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
    /// DeliveryMethodEntryList
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class NewInfoDelMetAttrValueController : ApiController
    {
        //IProjectBL<ProjectDomainModel> _projectBL = new ProjectBL();
        //attributeDo<_001_invRefCategory1Domain> cat1 = new _001_invRefCategory1BL();
        I_017_invNewInfoDelMetAttrValueBL<_017_invNewInfoDelMetAttrValueDomain> attrib;

        public NewInfoDelMetAttrValueController(I_017_invNewInfoDelMetAttrValueBL<_017_invNewInfoDelMetAttrValueDomain> _attrib) 
        {
            attrib = _attrib;
        }

        /// <summary>
        /// Add new DeliveryMethodEntryList
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        [Auth("POST", "DeliveryMethodEntryList", "Insert")]
        public IHttpActionResult Post([FromBody]_017_invNewInfoDelMetAttrValueDomain body)
        {
            return Json(attrib.Command(body, Command.Insert));
        }

        //Update
        /// <summary>
        /// Update DeliveryMethodEntryList by ID with JSON Body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        [Auth("PUT", "DeliveryMethodEntryList", "Update")]
        public IHttpActionResult Put(int id, [FromBody]_017_invNewInfoDelMetAttrValueDomain body)
        {
            body.ID = id;
            return Json(attrib.Command(body, Command.Update));
        }

        /// <summary>
        /// Delete Specific DeliveryMethodEntryList
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(MessageViewDomain))]
        [Auth("DELETE", "DeliveryMethodEntryList", "Delete")]
        public IHttpActionResult Delete(int id)
        {
            ///body.ID = id;
            return Json(attrib.Delete(id));
        }

        /// <summary>
        /// Get List of DeliveryMethodEntryList
        /// </summary>
        /// <returns>List</returns>
        [ResponseType(typeof(IEnumerable<_017_invNewInfoDelMetAttrValueDomain>))]
        [Auth("GET", "DeliveryMethodEntryList", "SelectList")]
        public IHttpActionResult Get()
        {
            var result = attrib.Get();
            /*
             * 
             */

            return Ok(result);
        }

        /// <summary>
        /// Get Specific DeliveryMethodEntryList by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1 JSON or NULL</returns>
        [ResponseType(typeof(_017_invNewInfoDelMetAttrValueDomain))]
        [Auth("GET", "DeliveryMethodEntryList", "Select")]
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
