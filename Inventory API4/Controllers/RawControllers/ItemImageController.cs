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
    public class ItemImageController : ApiController
    {
        I_014_invRefItemImageBL<_014_invRefItemImageDomain>  cat3 = new _014_invRefItemImageBL();
        [HttpPost]
        [DomainValidatorFilter]
        public object Post([FromBody]_014_invRefItemImageDomain body)
        {
            return Json(cat3.Command(new _014_invRefItemImageDomain(), "insert"));
        }

        public IEnumerable<_014_invRefItemImageDomain> Get()
        {
            return cat3.Get();
        }

    }
}
