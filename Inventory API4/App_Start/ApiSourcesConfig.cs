using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;

namespace Inventory_API4.App_Start
{
    public class ApiSourcesConfig
    {
        public static int requestCount = 0;
        public static void Config()
        {
            Inventory_Domain_Layer.ApiReferenceHolder.projectArray = Newtonsoft.Json.JsonConvert.DeserializeObject<JArray>(new Helper.SynchronousRequest("http://124.105.198.3:94/api/Projects").HttpRequest());
            Inventory_Domain_Layer.ApiReferenceHolder.hrmsArray = Newtonsoft.Json.JsonConvert.DeserializeObject<JArray>(new Helper.SynchronousRequest("http://124.105.198.3:92/api/PersonInformation").HttpRequest());
            Inventory_Domain_Layer.ApiReferenceHolder.supplierArray = Newtonsoft.Json.JsonConvert.DeserializeObject<JArray>(new Helper.SynchronousRequest("http://192.168.1.100:99/supplier/0").HttpRequest());
            requestCount++;
        }
    }
}