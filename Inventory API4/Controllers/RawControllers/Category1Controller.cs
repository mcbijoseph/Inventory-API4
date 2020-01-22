using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Inventory_API4.Controllers
{
    public class Category1Controller : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]Inventory_Domain_Layer._001_invRefCategory1 value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]Inventory_Domain_Layer._001_invRefCategory1 value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
