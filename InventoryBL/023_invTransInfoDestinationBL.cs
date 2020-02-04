using System;
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
    public interface I_023_invTransInfoDestinationBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {

    }

    public class _023_invTransInfoDestinationBL : Common.BaseBL, I_023_invTransInfoDestinationBL<_023_invTransInfoDestinationDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_023_invTransInfoDestinationDomain projectDomain, Command commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@TransMasterID_021", Value = projectDomain.TransMasterID_021, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@ProjectID_EnggDB", Value = projectDomain.ProjectID_EnggDB, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@WHInchargeID_HrmsDB", Value = projectDomain.WHInchargeID_HrmsDB, Direction = ParameterDirection.Input }

            };

            return this.GetMessage(_dbHelper.Command("sp023invTransInfoDestinationCommand", commandType.ToString(), sqlParameters).Tables[0]);


        }

        public MessageViewDomain Delete(int id)
        {
            //throw new NotImplementedException();
            return Command(new _023_invTransInfoDestinationDomain() { ID = id }, Inventory_Domain_Layer.Command.Delete);
        }

        public IEnumerable<_023_invTransInfoDestinationDomain> Get()
        {
            return GetData(0);
        }

        public _023_invTransInfoDestinationDomain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_023_invTransInfoDestinationDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_023_invTransInfoDestinationDomain> GetData(int id)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter { ParameterName = "ID", Value = id, Direction = ParameterDirection.Input });
            /*return _dbHelper.GetRecords("sp023invTransItemsDelMethodAttributeSelect", pars).Tables[0].AsEnumerable().Select(drow => new _023_invTransInfoDestinationDomain
            {
                ID = drow.Field<int>("ID"),
                HeaderID_021 = drow.Field<int>("HeaderID_021"),
                DeliveryAttrID_008 = drow.Field<int>("DeliveryAttrID_008"),
                AttributeValue = drow.Field<string>("AttributeValue")
            });*/
            string tabledata = _dbHelper.GetRecords("sp023invTransInfoDestinationSelect", pars).Tables[0].Rows[0][0].ToString();//, Newtonsoft.Json.Formatting.None);
            return JsonConvert.DeserializeObject<List<_023_invTransInfoDestinationDomain>>(tabledata);
        }
    }
}
