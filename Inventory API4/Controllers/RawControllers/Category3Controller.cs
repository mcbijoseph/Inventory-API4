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
    public class Category3Controller : ApiController
    {
        I_003_invRefCategory3BL<_003_invRefCategory3Domain> cat3 = new _003_invRefCategory3BL();
        [HttpPost]
        [DomainValidatorFilter]
        public object Post([FromBody]_003_invRefCategory3Domain body)
        {
            return Json(cat3.Command(new _003_invRefCategory3Domain(), "insert"));
        }
        public IEnumerable<_003_invRefCategory3Domain> Get()
        {
            return cat3.Get();
        }


    }
}
