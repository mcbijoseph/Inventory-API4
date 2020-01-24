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
    public class Category1Controller : ApiController
    {
        I_001_invRefCategory1BL<_001_invRefCategory1Domain> cat1 = new _001_invRefCategory1BL();
        
        [HttpPost]
        [DomainValidatorFilter]
        public object Post([FromBody]_001_invRefCategory1Domain body)
        {
            return Json(cat1.Command(new _001_invRefCategory1Domain(), "insert"));
        }

        public IEnumerable<_001_invRefCategory1Domain> Get()
        {
            

            return cat1.Get();
        }

        public  _001_invRefCategory1Domain Get(int id)
        {
            return cat1.Get(id);
        }
    }
}
