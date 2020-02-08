using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;

namespace Inventory_API4.App_Start
{
    public class ApiSourcesConfig
    {

        public static void Config()
        {
            Inventory_Domain_Layer.ApiReferenceHolder.projectArray = Newtonsoft.Json.JsonConvert.DeserializeObject<JArray>(new Helper.SynchronousRequest("http://124.105.198.3:94/api/Projects").HttpRequest());
        }
    }
}