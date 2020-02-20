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
    public interface I_032_LoginBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {
    }

    public class _032_LoginBL : Common.BaseBL, I_032_LoginBL<_032_LoginDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_032_LoginDomain projectDomain, Command commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@Username", Value = projectDomain.Username, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@Password", Value = projectDomain.Password, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@Info", Value = projectDomain.Info, Direction = ParameterDirection.Input }
            };

            return this.GetMessage(_dbHelper.Command("sp031invRefTransferListCommand", commandType.ToString(), sqlParameters).Tables[0]);


        }

        public MessageViewDomain Delete(int id)
        {
            // throw new NotImplementedException();
            return Command(new _032_LoginDomain() { ID = id }, Inventory_Domain_Layer.Command.Delete);
        }

        public IEnumerable<_032_LoginDomain> Get()
        {
            return GetData(0);
        }

        public _032_LoginDomain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_032_LoginDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reuse the query
        /// </summary>
        /// <param name="id">0 Means ALL</param>
        /// <returns>List</returns>
        private IEnumerable<_032_LoginDomain> GetData(int id)
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
            return JsonConvert.DeserializeObject<List<_032_LoginDomain>>(tabledata);

        }
    }
}
