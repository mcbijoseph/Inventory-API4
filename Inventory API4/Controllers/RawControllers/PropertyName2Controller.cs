using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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
    public class PropertyName2Controller : ApiController
    {
        //IProjectBL<ProjectDomainModel> _projectBL = new ProjectBL();
        //attributeDo<_001_invRefCategory1Domain> cat1 = new _001_invRefCategory1BL();
        //I_006_invRefAttributeBL<_006_invRefAttributeDomain> attrib = new _006_invRefAttributeBL();
        I_005_invRefPropertyName2BL<_005_invRefPropertyName2Domain> attrib = new _005_invRefPropertyName2BL();

        [HttpPost]
        [DomainValidatorFilter]
        public object Post([FromBody]_005_invRefPropertyName2Domain body)
        {
            return Json(attrib.Command(new _005_invRefPropertyName2Domain(), "insert"));
        }
    }
}
