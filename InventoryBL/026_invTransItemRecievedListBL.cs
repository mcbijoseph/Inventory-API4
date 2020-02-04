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
    public interface I_026_invTransItemRecievedListBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {
    }

    public class _026_invTransItemRecievedListBL : Common.BaseBL, I_026_invTransItemRecievedListBL<_026_invTransItemRecievedListDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_026_invTransItemRecievedListDomain projectDomain, Command commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@TransMasterID_021", Value = projectDomain.TransMasterID_021, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@ItemID_011", Value = projectDomain.ItemID_011, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@UnitsID_009", Value = projectDomain.UnitsID_009, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@Quantity", Value = projectDomain.Quantity, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@ItemCondID_018", Value = projectDomain.ItemCondID_018, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@RecieverID_HrmsDB", Value = projectDomain.RecieverID_HrmsDB, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@DelMethodID_024", Value = projectDomain.DelMethodID_024, Direction = ParameterDirection.Input }
            };

            return this.GetMessage(_dbHelper.Command("sp026invTransItemReceivedListCommand", commandType.ToString(), sqlParameters).Tables[0]);


        }

        public MessageViewDomain Delete(int id)
        {
            // throw new NotImplementedException();
            return Command(new _026_invTransItemRecievedListDomain() { ID = id }, Inventory_Domain_Layer.Command.Delete);
        }

        public IEnumerable<_026_invTransItemRecievedListDomain> Get()
        {
            return GetData(0);
        }

        public _026_invTransItemRecievedListDomain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_026_invTransItemRecievedListDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reuse the query
        /// </summary>
        /// <param name="id">0 Means ALL</param>
        /// <returns>List</returns>
        private IEnumerable<_026_invTransItemRecievedListDomain> GetData(int id)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter { ParameterName = "ID", Value = id, Direction = ParameterDirection.Input });

            /*return _dbHelper.GetRecords("sp001invRefCategory1Select", pars).Tables[0].AsEnumerable().Select
            (
                drow => new _026_invTransItemRecievedListDomain
                {
                    ID = drow.Field<int>("ID"),
                    Name = drow.Field<string>("Name")
                }
            );*/
            string tabledata = _dbHelper.GetRecords("sp026invTransItemReceivedListSelect", pars).Tables[0].Rows[0][0].ToString();//, Newtonsoft.Json.Formatting.None);
            return JsonConvert.DeserializeObject<List<_026_invTransItemRecievedListDomain>>(tabledata);

        }
    }
}
