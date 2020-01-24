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
    public class EntryDateController : ApiController
    {
        I_008_invRefEntryDateBL<_008_invRefEntryDateDomain> cat3 = new _008_invRefEntryDateBL();
        [HttpPost]
        [DomainValidatorFilter]
        public object Post([FromBody]_008_invRefEntryDateDomain body)
        {
            return Json(cat3.Command(new _008_invRefEntryDateDomain(), "insert"));
        }

        public IEnumerable<_008_invRefEntryDateDomain> Get()
        {
            return cat3.Get();
        }

        public _008_invRefEntryDateDomain Get(int id)
        {
            return cat3.Get(id);
        }
    }
}
