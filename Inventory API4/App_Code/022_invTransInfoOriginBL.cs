using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.DAL;
using System.Data;
using System.Data.SqlClient;
using Inventory_API4.Models;
using Newtonsoft.Json;

namespace InventoryBL
{
    public interface I_022_invTransInfoOriginBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {

    }

    public class _022_invTransInfoOriginBL : Common.BaseBL, I_022_invTransInfoOriginBL<_022_invTransInfoOriginDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_022_invTransInfoOriginDomain projectDomain, Command commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@TransMasterID_021", Value = projectDomain.TransMasterID_021, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@ProjectID_EnggDB", Value = projectDomain.ProjectID_EnggDB, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@WHInchargeID_HrmsDB", Value = projectDomain.WHInchargeID_HrmsDB, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@TransDelMethodID_024", Value = projectDomain.TransDelMethodID_024, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@Date", Value = projectDomain.Date, Direction = ParameterDirection.Input }

            };

            return this.GetMessage(_dbHelper.Command("sp022invTransInfoOriginCommand", commandType.ToString(), sqlParameters).Tables[0]);


        }

        public MessageViewDomain Delete(int id)
        {
            //throw new NotImplementedException();
            return Command(new _022_invTransInfoOriginDomain() { ID = id }, Inventory_API4.Models.Command.Delete);
        }

        public IEnumerable<_022_invTransInfoOriginDomain> Get()
        {
            return GetData(0);
        }

        public _022_invTransInfoOriginDomain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_022_invTransInfoOriginDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_022_invTransInfoOriginDomain> GetData(int id)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter { ParameterName = "ID", Value = id, Direction = ParameterDirection.Input });
            /*return _dbHelper.GetRecords("sp022invTransferedItemsDetailsSelect", pars).Tables[0].AsEnumerable().Select(drow => new _022_invTransInfoOriginDomain
            {
                ID = drow.Field<int>("ID"),
                HeaderID_021 = drow.Field<int>("HeaderID_021"),
                ItemID_011 = drow.Field<int>("ItemID_011"),
                UnitID_009 = drow.Field<int>("UnitID_009"),
                Quantity = drow.Field<decimal>("Quantity"),
                ItemConditionId_018 = drow.Field<int>("ItemConditionId_018")
            });*/
            string tabledata = _dbHelper.GetRecords("sp022invTransInfoOriginSelect", pars).Tables[0].Rows[0][0].ToString() ?? "{}";//, Newtonsoft.Json.Formatting.None);
            return JsonConvert.DeserializeObject<List<_022_invTransInfoOriginDomain>>(tabledata);
        }
    }
}
