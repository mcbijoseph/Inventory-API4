using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Inventory_API4.Models;
using Inventory_API4.Filters;
using InventoryBL;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using Newtonsoft.Json.Linq;

namespace Inventory_API4.Controllers.RawControllers
{
    /// <summary>
    /// TransMasterList
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TransMasterListController : ApiController
    {
        I_021_invTransMasterListBL<_021_invTransMasterListDomain> attrib;

        public TransMasterListController(I_021_invTransMasterListBL<_021_invTransMasterListDomain> _attrib)
        {
            attrib = _attrib;
        }
        /// <summary>
        /// Add new TransMasterList
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess("TransMasterList", "Insert")]
        public IHttpActionResult Post([FromBody]_021_invTransMasterListDomain body)
        {
            return Json(attrib.Command(body, Command.Insert));
        }

        /// <summary>
        /// Add Receive
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        [Route("api/TransMasterList/ConfirmReceive")]
        [AuthRoleAccess("TransMasterList", "Insert")]
        public IHttpActionResult ConfirmReceive([FromBody]_021_invTransMasterListDomain body)
        {
            return Json(attrib.Command(body, Command.Insert, true));
        }


        //Update
        /// <summary>
        /// Update TransMasterList by ID with JSON Body
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut]
        [DomainValidatorFilter]
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess("TransMasterList", "Update")]
        public IHttpActionResult Put(int id, [FromBody]_021_invTransMasterListDomain body)
        {
            body.ID = id;
            return Json(attrib.Command(body, Command.Update));
        }



        /// <summary>
        /// Delete Specific TransMasterList
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(MessageViewDomain))]
        [AuthRoleAccess("TransMasterList", "Delete")]
        public IHttpActionResult Delete(int id)
        {
            ///body.ID = id;
            return Json(attrib.Delete(id));
        }
        



        /// <summary>
        /// Get List of TransMasterList
        /// </summary>
        /// <returns>List</returns>
        [ResponseType(typeof(IEnumerable<_021_invTransMasterListDomain>))]
        [AuthRoleAccess("TransMasterList", "SelectList")]
        public IHttpActionResult Get()
        {
           
            var result = attrib.Get();
            setProject(result);
            /*
             * 
             */

            return Ok(result);
        }

        void setProjectInfo(_021_invTransMasterListDomain transMaster, JArray projectArray)
        {
            if (transMaster == null) return;
            foreach (JObject trans in projectArray)
            {
                if (transMaster.TransInfoOrigin != null)
                {
                    if (transMaster.TransInfoOrigin.ProjectID_EnggDB == int.Parse(trans["ID"].ToString()))
                    {
                        //transMaster.TransInfoOrigin.ProjectInfo = trans;
                        //break;
                    }
                   if( transMaster.TransInfoDestination != null)
                    {
                       if( transMaster.TransInfoDestination.ProjectID_EnggDB == int.Parse(trans["ID"].ToString()))
                        {
                            //transMaster.TransInfoDestination.ProjectInfo = trans;
                        }
                    }
                }
            }
        }

        void setProject(IEnumerable<_021_invTransMasterListDomain> list)
        {
            return;
            JArray projectArray = Newtonsoft.Json.JsonConvert.DeserializeObject<JArray>(new Helper.SynchronousRequest("http://124.105.198.3:94/api/Projects").HttpRequest());

            foreach (_021_invTransMasterListDomain trans in list)
            {
                setProjectInfo(trans, projectArray);
            }
        }

        /// <summary>
        /// Get Specific TransMasterList by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>1 JSON or NULL</returns>
        [ResponseType(typeof(_021_invTransMasterListDomain))]
        [AuthRoleAccess( "TransMasterList", "Select")]
        public IHttpActionResult Get(int id)
        {
            //return Ok(projectArray);
            _021_invTransMasterListDomain result = attrib.Get(id);

            JArray projectArray = Newtonsoft.Json.JsonConvert.DeserializeObject<JArray>(new Helper.SynchronousRequest("http://124.105.198.3:94/api/Projects").HttpRequest());
            setProjectInfo(result, projectArray);
            /*
             *
             */

            return Ok(result);
        }

        [HttpGet]
        [Route("api/TransMasterList/Search")]
        [ResponseType(typeof(IEnumerable<_021_invTransMasterListDomain>))]
        [AuthRoleAccess( "TransMasterList", "Select")]
        public IHttpActionResult Search(string q)
        {
            
            var result = attrib.Search(q);
            setProject(result);
            /*
             *
             */

            return Ok(result);
        }

        [HttpGet]
        [Route("api/TransMasterList/SearchbyReference")]
        [ResponseType(typeof(_021_invTransMasterListDomain))]
        [AuthRoleAccess( "TransMasterList", "Select")]
        public IHttpActionResult SearchbyReference(string q)
        {
            var result = attrib.SearchbyReference(q);
            /*
             *
             */

            return Ok(result);
        }
    }
}
