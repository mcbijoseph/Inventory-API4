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
    public class UnitsController : ApiController
    {
        //IProjectBL<ProjectDomainModel> _projectBL = new ProjectBL();
        //attributeDo<_001_invRefCategory1Domain> cat1 = new _001_invRefCategory1BL();
        I_009_invRefUnitsBL<_009_invRefUnitsDomain> attrib = new _009_invRefUnitsBL();

        [HttpPost]
        [DomainValidatorFilter]
        public IHttpActionResult Post([FromBody]_009_invRefUnitsDomain body)
        {
            return Json(attrib.Command(body , "insert"));
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
