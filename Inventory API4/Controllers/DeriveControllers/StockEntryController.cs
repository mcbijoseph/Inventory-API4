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
     
     {
	"DocEntry":{
		"ID":1,
		"SupID_VendorDB":1,
		"ProjectID_EnggDB": 1,
		"DocumentNumber":"Hello",
		"DeliveryDate":"12/12/12",
		"EntryDate":"12/12/12",
		"ReceiverID_HRDB":1
	},
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
		}]
    }
         
     */
    /// <summary>
    /// StockEntry
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class StockEntryController : ApiController
    {
        IStockEntryBL<Inventory_Domain_Layer.Derived.StockEntryDomain> stockEntryBL = new StockEntryBL();


        /// <summary>
        /// Add new Attribute
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        //view
        [HttpPost]
        [DomainValidatorFilter]
        public IHttpActionResult Post([FromBody]Inventory_Domain_Layer.Derived.StockEntryDomain body)
        {
            return Json(stockEntryBL.Command(body, "insert"));
        }

        /// <summary>
        /// Update Attribute by ID with JSON BODY
        /// </summary>
        /// <param name="id"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        //Update
        [HttpPut]
        [DomainValidatorFilter]
        public IHttpActionResult Put(int id, [FromBody]Inventory_Domain_Layer.Derived.StockEntryDomain body)
        {
            //body.ID = id;
            return Json(stockEntryBL.Command(body, "update"));
        }

        /// <summary>
        /// Get List of Item Attribute
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
        /// Get Specific Item Attribute
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