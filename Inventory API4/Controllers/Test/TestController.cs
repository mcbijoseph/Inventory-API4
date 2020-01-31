
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
using InventoryBL.Derived;

namespace Inventory_API4.Controllers.DeriveControllers
{
    /*
     POST
     {
	"DocEntry":{
		"ID":1,
		"SupID_VendorDB":1,
		"ProjectID_EnggDB": 1,
		"DocumentNumber":"Hello",
		"DeliveryDate":"12/12/12",
		"EntryDate":"12/12/12",
		"ReceiverID_HRDB":1,
        "ItemEntryList":[
		        {
			        "ID":1,
			        "DocEntryID_007":2,
			        "ItemID_011":3,
			        "UnitID_009":4,
			        "UnitPrice":5,
			        "Quantity":6,
			        "ItemConditionID_018":7
		        },{
			        "ID":6,
			        "DocEntryID_007":5,
			        "ItemID_011":4,
			        "UnitID_009":20,
			        "UnitPrice":3,
			        "Quantity":2,
			        "ItemConditionID_018":1
		        }],	
        "DeliveryEntry":[
            {
                "ID":1,
                "DocEntryListID_007":1,
                "DelMethodAttrID_008":1,
                "AttributeValue":"AttrValue"
            }]
	},
	

    }         
     */
    /// <summary>
    /// StockEntry
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TestController : ApiController
    {
        InventoryBL.Test.I_007_invRefDocEntryListSampleBL<Inventory_Domain_Layer.Test._007_invRefDocEntryListDomainSample> stockEntryBL = new InventoryBL.Test._007_invRefDocEntryListSampleBL();


        /// <summary>
        /// Add new STOCK with ItemEntryList[], DocEntry, DeliveryEntry[]
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        //view
        [HttpPost]
        [DomainValidatorFilter]
        public IHttpActionResult Post([FromBody]Inventory_Domain_Layer.Test._007_invRefDocEntryListDomainSample body)
        {
            var j = body;
            return Json(stockEntryBL.Command(body, Command.Insert));
        }

        /// <summary>
        /// Update StockEntry by ID with JSON BODY
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        //Update
        [HttpPut]
        [DomainValidatorFilter]
        public IHttpActionResult Put(int id, [FromBody]Inventory_Domain_Layer.Test._007_invRefDocEntryListDomainSample body)
        {
            //body.ID = id;
            return Json(stockEntryBL.Command(body, Command.Delete));
        }

        /// <summary>
        /// Get List of All StockEntry
        /// </summary>
        /// <returns>List</returns>
        public IHttpActionResult Get()
        {
            var result = stockEntryBL.Get();
            /*
             * 
             */

            return Ok(result);
        }

        /// <summary>
        /// Get Specific StockEntry
        /// </summary>
        /// <param name="id">ID of target</param>
        /// <returns>1 JSON or NULL</returns>
        public IHttpActionResult Get(int id)
        {
            var result = stockEntryBL.Get(id);
            /*
             *
             */

            return Ok(result);
        }

    }
}