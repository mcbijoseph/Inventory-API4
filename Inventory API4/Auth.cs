using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_API4
{
    /*
    struct Auth2
    {
        public string URL;
    }
    struct Employee
    {
        public int EmpId = 0;
        public string FirstName;
        public string LastName;
    }
    */
    public static  class Auth2
    {
        public static string URL = "http://192.168.1.100:98/api/user/userroleaccess";
        public static string Expression(string controlName, string action)
        {
            return $"systemname=inventory, controlname={controlName}, action={action}, isallowed=true";
        }
        public static string map => "customSettings";
        
    }

    public class Auth: Helper.RoleAccessDataAttribute
    {
        public Auth(string method,string controlName, string actioname): 
            base(Auth2.URL,"GET",Auth2.map,Auth2.Expression(controlName, actioname),"UserID","Token")
        {

        }

    }

}