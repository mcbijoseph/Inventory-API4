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
    public interface I_030_invRefFormHardCopySeriesBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {
    }

    public class _030_invRefFormHardCopySeriesBL : Common.BaseBL, I_030_invRefFormHardCopySeriesBL<_030_invRefFormHardCopySeriesDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_030_invRefFormHardCopySeriesDomain projectDomain, Command commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@FormID_029", Value = projectDomain.FormID_029, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@Series", Value = projectDomain.Series, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@isUsed", Value = projectDomain.isUsed, Direction = ParameterDirection.Input }
            };

            return this.GetMessage(_dbHelper.Command("sp030invRefFormHardCopySeriesCommand", commandType.ToString(), sqlParameters).Tables[0]);


        }

        public MessageViewDomain Delete(int id)
        {
            // throw new NotImplementedException();
            return Command(new _030_invRefFormHardCopySeriesDomain() { ID = id }, Inventory_API4.Models.Command.Delete);
        }

        public IEnumerable<_030_invRefFormHardCopySeriesDomain> Get()
        {
            return GetData(0);
        }

        public _030_invRefFormHardCopySeriesDomain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_030_invRefFormHardCopySeriesDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reuse the query
        /// </summary>
        /// <param name="id">0 Means ALL</param>
        /// <returns>List</returns>
        private IEnumerable<_030_invRefFormHardCopySeriesDomain> GetData(int id)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter { ParameterName = "ID", Value = id, Direction = ParameterDirection.Input });

            /*return _dbHelper.GetRecords("sp001invRefCategory1Select", pars).Tables[0].AsEnumerable().Select
            (
                drow => new _030_invRefFormHardCopySeriesDomain
                {
                    ID = drow.Field<int>("ID"),
                    Name = drow.Field<string>("Name")
                }
            );*/
            string tabledata = _dbHelper.GetRecords("sp030invRefFormHardCopySeriesSelect", pars).Tables[0].Rows[0][0].ToString();//, Newtonsoft.Json.Formatting.None);
            return JsonConvert.DeserializeObject<List<_030_invRefFormHardCopySeriesDomain>>(tabledata);

        }
    }
}
