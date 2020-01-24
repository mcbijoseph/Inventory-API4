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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TDSNoController : ApiController
    {
        //IProjectBL<ProjectDomainModel> _projectBL = new ProjectBL();
        //attributeDo<_001_invRefCategory1Domain> cat1 = new _001_invRefCategory1BL();
        I_010_invRefTDSNoBL<_010_invRefTDSNoDomain> attrib = new _010_invRefTDSNoBL();

        [HttpPost]
        [DomainValidatorFilter]
        public IHttpActionResult Post([FromBody]_010_invRefTDSNoDomain body)
        {
            return Json(attrib.Command(body, "insert"));
        }

        //Update
        [HttpPut]
        [DomainValidatorFilter]
        public IHttpActionResult Put(int id, [FromBody]_010_invRefTDSNoDomain body)
        {
            body.ID = id;
            return Json(attrib.Command(body, "update"));
        }

        public IHttpActionResult Get()
        {
            var result = attrib.Get();
            /*
             * 
             */

            return Ok(result);
        }

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
