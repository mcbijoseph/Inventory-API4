using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Inventory_API4.Controllers.ReferenceApi
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VendorListController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok(Inventory_Domain_Layer.ApiReferenceHolder.supplierArray);
        }
    }
}
