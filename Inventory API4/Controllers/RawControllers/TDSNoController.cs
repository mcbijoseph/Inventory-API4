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
    public class TDSNoController : ApiController
    {
        //IProjectBL<ProjectDomainModel> _projectBL = new ProjectBL();
        //attributeDo<_001_invRefCategory1Domain> cat1 = new _001_invRefCategory1BL();
        I_010_invRefTDSNoBL<_010_invRefTDSNoDomain> attrib = new _010_invRefTDSNoBL();

        [HttpPost]
        [DomainValidatorFilter]
        public object Post([FromBody]_010_invRefTDSNoDomain body)
        {
            return Json(attrib.Command(new _010_invRefTDSNoDomain(), "insert"));
        }

        public IEnumerable<_010_invRefTDSNoDomain> Get()
        {
            return attrib.Get();
        }

        public _010_invRefTDSNoDomain Get(int id)
        {
            return attrib.Get(id);
        }
    }
}
