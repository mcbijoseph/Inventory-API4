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
    public interface I_028_invWithdrawItemEntryListBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {
    }

    public class _028_invWithdrawItemEntryListBL : Common.BaseBL, I_028_invWithdrawItemEntryListBL<_028_invWithdrawItemEntryListDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_028_invWithdrawItemEntryListDomain projectDomain, Command commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@WithdrawMasterID_027", Value = projectDomain.WithdrawMasterID_027, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@ItemID_011", Value = projectDomain.ItemID_011, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@UnitsID_009", Value = projectDomain.UnitsID_009, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@Quantity", Value = projectDomain.Quantity, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@ItemCondID_018", Value = projectDomain.ItemCondID_018, Direction = ParameterDirection.Input }
            };

            return this.GetMessage(_dbHelper.Command("sp028invWithdrawItemEntryListCommand", commandType.ToString(), sqlParameters).Tables[0]);


        }

        public MessageViewDomain Delete(int id)
        {
            // throw new NotImplementedException();
            return Command(new _028_invWithdrawItemEntryListDomain() { ID = id }, Inventory_API4.Models.Command.Delete);
        }

        public IEnumerable<_028_invWithdrawItemEntryListDomain> Get()
        {
            return GetData(0);
        }

        public _028_invWithdrawItemEntryListDomain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_028_invWithdrawItemEntryListDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reuse the query
        /// </summary>
        /// <param name="id">0 Means ALL</param>
        /// <returns>List</returns>
        private IEnumerable<_028_invWithdrawItemEntryListDomain> GetData(int id)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter { ParameterName = "ID", Value = id, Direction = ParameterDirection.Input });

            /*return _dbHelper.GetRecords("sp001invRefCategory1Select", pars).Tables[0].AsEnumerable().Select
            (
                drow => new _028_invWithdrawItemEntryListDomain
                {
                    ID = drow.Field<int>("ID"),
                    Name = drow.Field<string>("Name")
                }
            );*/
            string tabledata = _dbHelper.GetRecords("sp028invWithdrawItemEntryListSelect", pars).Tables[0].Rows[0][0].ToString()??"{}";//, Newtonsoft.Json.Formatting.None);
            return JsonConvert.DeserializeObject<List<_028_invWithdrawItemEntryListDomain>>(tabledata);

        }
    }
}
