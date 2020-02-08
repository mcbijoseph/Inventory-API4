using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Inventory_Domain_Layer
{
    public class ApiReferenceHolder
    {
        public static JArray projectArray { get; set; }
        public static JArray hrmsArray { get; set; }
        public static JArray supplierArray { get; set; }

        public static JObject GetProjectByID(int ProjectID_EnggDB)
        {
            if (ProjectID_EnggDB == 0) { return null; }

            foreach (JObject j in projectArray)
            {
                if (int.Parse(j["ID"].ToString()) == ProjectID_EnggDB)
                {
                    return j;
                }
            }
            return null;
        }



        public JObject sample => null;
        public JObject Sample
        {
            get
            {                /*Syntax here*/
                return null;
            }


        }
    }
}
