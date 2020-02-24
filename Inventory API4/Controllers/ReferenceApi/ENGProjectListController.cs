using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Inventory_API4.Models;

namespace Inventory_API4.Controllers.ReferenceApi
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ENGProjectListController : ApiController
    {

        public IHttpActionResult Get()
        {
            return Ok(ApiReferenceHolder.projectArray);
        }

        public IHttpActionResult Get(int id)
        {
            //Newtonsoft.Json.Linq.JArray jar = Newtonsoft.Json.JsonConvert.DeserializeObject<>
            foreach (Newtonsoft.Json.Linq.JObject jo in ApiReferenceHolder.projectArray)
            {
                if (int.Parse(jo["ID"].ToString()) == id)
                    return Ok(jo);
            }
            return Ok();
        }
    }
}
