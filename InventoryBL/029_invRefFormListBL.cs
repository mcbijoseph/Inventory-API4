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
    public interface I_029_invRefFormListBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {
    }

    public class _029_invRefFormListBL : Common.BaseBL, I_029_invRefFormListBL<_029_invRefFormListDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_029_invRefFormListDomain projectDomain, Command commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@InitForm", Value = projectDomain.InitForm, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@Name", Value = projectDomain.Name, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@Abbr", Value = projectDomain.Abbr, Direction = ParameterDirection.Input }
            };

            return this.GetMessage(_dbHelper.Command("sp029invRefFormListCommand", commandType.ToString(), sqlParameters).Tables[0]);


        }

        public MessageViewDomain Delete(int id)
        {
            // throw new NotImplementedException();
            return Command(new _029_invRefFormListDomain() { ID = id }, Inventory_Domain_Layer.Command.Delete);
        }

        public IEnumerable<_029_invRefFormListDomain> Get()
        {
            return GetData(0);
        }

        public _029_invRefFormListDomain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_029_invRefFormListDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reuse the query
        /// </summary>
        /// <param name="id">0 Means ALL</param>
        /// <returns>List</returns>
        private IEnumerable<_029_invRefFormListDomain> GetData(int id)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter { ParameterName = "ID", Value = id, Direction = ParameterDirection.Input });

            /*return _dbHelper.GetRecords("sp001invRefCategory1Select", pars).Tables[0].AsEnumerable().Select
            (
                drow => new _029_invRefFormListDomain
                {
                    ID = drow.Field<int>("ID"),
                    Name = drow.Field<string>("Name")
                }
            );*/
            string tabledata = _dbHelper.GetRecords("sp029invRefFormListSelect", pars).Tables[0].Rows[0][0].ToString();//, Newtonsoft.Json.Formatting.None);
            return JsonConvert.DeserializeObject<List<_029_invRefFormListDomain>>(tabledata);

        }
    }
}
