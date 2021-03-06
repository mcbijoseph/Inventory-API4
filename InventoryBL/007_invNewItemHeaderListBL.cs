﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.DAL;
using System.Data;
using System.Data.SqlClient;
using Inventory_Domain_Layer;
using Newtonsoft.Json;

namespace InventoryBL
{
    public interface I_007_invNewItemHeaderListBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {

    }


    public class _007_invNewItemHeaderListBL : Common.BaseBL, I_007_invNewItemHeaderListBL<_007_invNewItemHeaderListDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_007_invNewItemHeaderListDomain entity, Command commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter
                {
                    ParameterName = "@DocEntry",
                    Value = Newtonsoft.Json.JsonConvert.SerializeObject( entity),// projectDomain.ID,
                    Direction = ParameterDirection.Input
                },
                new SqlParameter
                {
                    ParameterName = "@ItemsEntry",
                    Value = Newtonsoft.Json.JsonConvert.SerializeObject( entity.ItemEntryList),// projectDomain.Name,
                    Direction = ParameterDirection.Input
                },
                new SqlParameter
                {
                    ParameterName = "@DeliveryEntry",
                    Value = Newtonsoft.Json.JsonConvert.SerializeObject( entity.DeliveryMethod.DelMethodAttribute[0].DeliveryMethodEntryList ),// projectDomain.Name,
                    Direction = ParameterDirection.Input
                }
            };

            return this.GetMessage(_dbHelper.Command("spDeriveStockEntryCommand", commandType.ToString(), sqlParameters).Tables[0]);

        }

        public MessageViewDomain Delete(int id)
        {
            ///throw new NotImplementedException();
            return Command(new _007_invNewItemHeaderListDomain() { ID = id }, Inventory_Domain_Layer.Command.Delete);
        }

        public IEnumerable<_007_invNewItemHeaderListDomain> Get()
        {
            return GetData(0);
        }

        public _007_invNewItemHeaderListDomain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_007_invNewItemHeaderListDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_007_invNewItemHeaderListDomain> GetData(int id)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter { ParameterName = "ID", Value = id, Direction = ParameterDirection.Input });
            /*
            return _dbHelper.GetRecords("sp007invRefDocEntryListSelect", pars).Tables[0].AsEnumerable().Select(drow => new _007_invRefDocEntryListDomain
            {
                ID = drow.Field<int>("ID"),
                SupID_VendorDB = drow.Field<int>("SupID_VendorDB"),
                ProjectID_EnggDB = drow.Field<int>("ProjectID_EnggDB"),
                DocumentNumber = drow.Field<string>("DocumentNumber"),
                DeliveryDate = drow.Field<DateTime>("DeliveryDate"),
                EntryDate = drow.Field<DateTime>("EntryDate"),
                ReceiverID_HRDB = drow.Field<int>("ReceiverID_HRDB"),
                ItemEntryList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<_013_invItemsEntryListDomain>>(drow.Field<string>("ItemEntryList")??"[]"),
                 DeliveryEntry = Newtonsoft.Json.JsonConvert.DeserializeObject<List<_017_invDeliveryMethodEntryListDomain>>(drow.Field<string>("DeliveryEntry")??"[]")
            });
            */

            string tabledata = _dbHelper.GetRecords("sp007invNewItemHeaderListSelect", pars).Tables[0].Rows[0]["RESULT"].ToString();//, Newtonsoft.Json.Formatting.None);
            return JsonConvert.DeserializeObject<List<_007_invNewItemHeaderListDomain>>(tabledata );

        }
    }
}
