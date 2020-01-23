using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Inventory_Domain_Layer;
using Inventory_API4.Filters;
using InventoryBL;

namespace Inventory_API4.Controllers
{
    public class UnitsController : ApiController
    {
        //IProjectBL<ProjectDomainModel> _projectBL = new ProjectBL();
        //attributeDo<_001_invRefCategory1Domain> cat1 = new _001_invRefCategory1BL();
        I_009_invRefUnitsBL<_009_invRefUnitsDomain> attrib = new _009_invRefUnitsBL();

        [HttpPost]
        [DomainValidatorFilter]
        public object Post([FromBody]_009_invRefUnitsDomain body)
        {
            return Json(attrib.Command(new _009_invRefUnitsDomain(), "insert"));
        }


        public IEnumerable<_009_invRefUnitsDomain> Get()
        {
            return attrib.Get();
        }

    }
}
