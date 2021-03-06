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
    public interface I_021_invTransMasterListBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {
        MessageViewDomain Command(_021_invTransMasterListDomain projectDomain, Command commandType, bool isReceived);
        IEnumerable<_021_invTransMasterListDomain> Search( string args);
        _021_invTransMasterListDomain SearchbyReference(string reference);
    }

    public class _021_invTransMasterListBL : Common.BaseBL, I_021_invTransMasterListBL<_021_invTransMasterListDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_021_invTransMasterListDomain projectDomain, Command commandType)
        {
            return this.Command(projectDomain, commandType, false);
        }
        public MessageViewDomain Command(_021_invTransMasterListDomain projectDomain, Command commandType, bool isReceived)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@ReferenceNumber", Value = projectDomain.ReferenceNumber, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@HardSeriesNumber", Value = projectDomain.HardSeriesNumber, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@isCancelled", Value = projectDomain.isCancelled, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@cancelReason", Value = projectDomain.cancelReason ?? "", Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@Date", Value = projectDomain.Date ?? DateTime.Now, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@TransInfoOrigin", Value = JsonConvert.SerializeObject(projectDomain.TransInfoOrigin) ?? "[]", Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@TransInfoDestination", Value = JsonConvert.SerializeObject(projectDomain.TransInfoDestination) ?? "[]", Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@TransInfoDelMetAttrValue", Value = JsonConvert.SerializeObject(projectDomain.TransInfoDelMetAttrValue) ?? "[]", Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@TransItemEntryList", Value = JsonConvert.SerializeObject(projectDomain.TransItemEntryList) ??"[]", Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@TransItemReceivedList", Value = JsonConvert.SerializeObject(projectDomain.TransItemReceivedList) ?? "[]", Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@isReceive", Value = isReceived, Direction = ParameterDirection.Input }

            };

            return this.GetMessage(_dbHelper.Command("sp021invTransMasterListCommand", commandType.ToString(), sqlParameters).Tables[0]);
        }

        public MessageViewDomain Delete(int id)
        {
            //throw new NotImplementedException();
            return Command(new _021_invTransMasterListDomain() { ID = id }, Inventory_Domain_Layer.Command.Delete);
        }

        public IEnumerable<_021_invTransMasterListDomain> Get()
        {
            return GetData(0);
        }

        public _021_invTransMasterListDomain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_021_invTransMasterListDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<_021_invTransMasterListDomain> Search(string args)
        {
            IEnumerable<_021_invTransMasterListDomain> testVal = GetData(0);
            args = args.ToLower();
            string[] argsArray = args.Split(' ');
            if (testVal == null)
                return null;
            return testVal.Where(e => {
                string s = JsonConvert.SerializeObject(e);
                bool hasItem = true;

                foreach (string eacs in argsArray)
                {
                    if (!s.Contains(eacs)) return false;
                }

                return hasItem;
            });

        }

        public _021_invTransMasterListDomain SearchbyReference(string reference)
        {
            IEnumerable<_021_invTransMasterListDomain> testVal = GetData(0);

            foreach (_021_invTransMasterListDomain tmld in testVal)
            {
                if (tmld.HardSeriesNumber.ToString() == reference || tmld.ReferenceNumber == reference)
                {
                    return tmld;
                }
            }
            return null;

        }

        public IEnumerable<_021_invTransMasterListDomain> GetData(int id)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter { ParameterName = "ID", Value = id, Direction = ParameterDirection.Input });
            /*return _dbHelper.GetRecords("sp021invTransferedItemsHeaderSelect", pars).Tables[0].AsEnumerable().Select(drow => new _021_invTransMasterListDomain
            {
                ID = drow.Field<int>("ID"),
                Ctrlnumber = drow.Field<string>("Ctrlnumber"),
                ProjectID_ENGGDB = drow.Field<int>("ProjectID_ENGGDB"),
                WarehouseInCharge_HRMSDB = drow.Field<int>("WarehouseInCharge_HRMSDB"),
                DatePrepared = drow.Field<DateTime>("DatePrepared"),
                ReceiverWarehouseInCharge_HRMSDB = drow.Field<int>("ReceiverWarehouseInCharge_HRMSDB"),
                ReceiverProjectID_ENGGDB = drow.Field<int>("ReceiverProjectID_ENGGDB"),
                ReceivedDate = drow.Field<DateTime>("ReceivedDate"),
                DocEntryListID_007 = drow.Field<int>("DocEntryListID_007")
            });*/
            string tabledata = _dbHelper.GetRecords("sp021invTransMasterListSelect", pars).Tables[0].Rows[0][0].ToString() ?? "{}";//, Newtonsoft.Json.Formatting.None);
            return JsonConvert.DeserializeObject<List<_021_invTransMasterListDomain>>(tabledata);
        }
    }
}
