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
    public interface I_031_invRefFormTransferListBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {
    }

    public class _031_invRefTransferListBL : Common.BaseBL, I_031_invRefFormTransferListBL<_031_invRefFormTransferListDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_031_invRefFormTransferListDomain projectDomain, Command commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@StrDate", Value = projectDomain.StrDate, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@Year", Value = projectDomain.Year, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@Series", Value = projectDomain.Series, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@HardSeriesNo", Value = projectDomain.HardSeriesNo, Direction = ParameterDirection.Input }
            };

            return this.GetMessage(_dbHelper.Command("sp031invRefTransferListCommand", commandType.ToString(), sqlParameters).Tables[0]);


        }

        public MessageViewDomain Delete(int id)
        {
            // throw new NotImplementedException();
            return Command(new _031_invRefFormTransferListDomain() { ID = id }, Inventory_API4.Models.Command.Delete);
        }

        public IEnumerable<_031_invRefFormTransferListDomain> Get()
        {
            return GetData(0);
        }

        public _031_invRefFormTransferListDomain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_031_invRefFormTransferListDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reuse the query
        /// </summary>
        /// <param name="id">0 Means ALL</param>
        /// <returns>List</returns>
        private IEnumerable<_031_invRefFormTransferListDomain> GetData(int id)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter { ParameterName = "ID", Value = id, Direction = ParameterDirection.Input });

            /*return _dbHelper.GetRecords("sp001invRefCategory1Select", pars).Tables[0].AsEnumerable().Select
            (
                drow => new _031_invRefTransferListDomain
                {
                    ID = drow.Field<int>("ID"),
                    Name = drow.Field<string>("Name")
                }
            );*/
            string tabledata = _dbHelper.GetRecords("sp031invRefTransferListSelect", pars).Tables[0].Rows[0][0].ToString();//, Newtonsoft.Json.Formatting.None);
            return JsonConvert.DeserializeObject<List<_031_invRefFormTransferListDomain>>(tabledata);

        }
    }
}
