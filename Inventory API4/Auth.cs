using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;

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

    public class AuthRoleAccess: Helper.RoleAccessDataAttribute
    {
        private string _ActionName = null;
        /// <summary>
        /// Customize the request setup
        /// </summary>
        /// <param name="method"></param>
        /// <param name="controlName"></param>
        /// <param name="actioname"></param>
        public AuthRoleAccess(string controlName, string actioname) :
            base(Auth2.URL, "GET", Auth2.map, Auth2.Expression(controlName, actioname), "UserID", "Token")
        {

        }
        /// <summary>
        /// Auto Provides Data Expression Required
        /// </summary>
        public AuthRoleAccess():base(Auth2.URL, "GET", Auth2.map, null, "UserID", "Token")
        {
        }
        /// <summary>
        /// Custom Action 
        /// </summary>
        /// <param name="ActionName">Customized Action Name</param>
        public AuthRoleAccess(string ActionName) : base(Auth2.URL, "GET", Auth2.map, null, "UserID", "Token")
        {
            _ActionName = ActionName;
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {

            if (_ra.TestMatchExpressionValue == null)
            {
                string actionName = _ActionName ?? actionContext.ActionDescriptor.ActionName;
                string cName = actionContext.ActionDescriptor.ControllerDescriptor.ControllerName;

                this.SetMatchExpression(Auth2.Expression(cName, actionName));
            }


            base.OnActionExecuting(actionContext);
        }



    }

}