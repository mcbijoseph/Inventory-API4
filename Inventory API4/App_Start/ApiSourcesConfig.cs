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
        {/*
            Inventory_API4.Models.ApiReferenceHolder.projectArray = Newtonsoft.Json.JsonConvert.DeserializeObject<JArray>(new Helper.SynchronousRequest("http://124.105.198.3:94/api/Projects").HttpRequest());
            Inventory_API4.Models.ApiReferenceHolder.hrmsArray = Newtonsoft.Json.JsonConvert.DeserializeObject<JArray>(new Helper.SynchronousRequest("http://124.105.198.3:92/api/PersonInformation").HttpRequest());
            Inventory_API4.Models.ApiReferenceHolder.supplierArray = Newtonsoft.Json.JsonConvert.DeserializeObject<JArray>(new Helper.SynchronousRequest("http://192.168.1.100:99/api/supplier/0").HttpRequest());*/

           /* Inventory_API4.Models.ApiReferenceHolder.projectArray = Newtonsoft.Json.JsonConvert.DeserializeObject<JArray>(new Helper.SynchronousRequest("http://192.168.1.100:94/api/Projects").HttpRequest());
            Inventory_API4.Models.ApiReferenceHolder.hrmsArray = Newtonsoft.Json.JsonConvert.DeserializeObject<JArray>(new Helper.SynchronousRequest("http://192.168.1.100:92/api/PersonInformation").HttpRequest());
            Inventory_API4.Models.ApiReferenceHolder.supplierArray = Newtonsoft.Json.JsonConvert.DeserializeObject<JArray>(new Helper.SynchronousRequest("http://192.168.1.100:99/api/supplier/0").HttpRequest());
*/

            Inventory_API4.Models.ApiReferenceHolder.projectArray = Newtonsoft.Json.JsonConvert.DeserializeObject<JArray>(new Helper.SynchronousRequest("http://mcbi-dev3:94/api/Projects").HttpRequest());
            Inventory_API4.Models.ApiReferenceHolder.hrmsArray = Newtonsoft.Json.JsonConvert.DeserializeObject<JArray>(new Helper.SynchronousRequest("http://mcbi-dev3:92/api/PersonInformation").HttpRequest());
            Inventory_API4.Models.ApiReferenceHolder.supplierArray = Newtonsoft.Json.JsonConvert.DeserializeObject<JArray>(new Helper.SynchronousRequest("http://mcbi-dev3:99/api/supplier/0").HttpRequest());


            requestCount++;
        }
    }
}