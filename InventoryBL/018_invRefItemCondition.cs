using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.DAL;
using System.Data;
using System.Data.SqlClient;
using Inventory_Domain_Layer;

namespace InventoryBL
{
    public interface I_018_invRefItemConditiontBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {

    }


    public class _018_invRefItemConditiontBL : Common.BaseBL, I_018_invRefItemConditiontBL<_018_invRefItemConditionDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_018_invRefItemConditionDomain projectDomain, string commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@StatusName", Value = projectDomain.StatusName, Direction = ParameterDirection.Input }

            };

            return this.GetMessage(_dbHelper.Command("sp018invRefItemConditionCommand", commandType, sqlParameters).Tables[0]);


        }

        public MessageViewDomain Delete(int id)
        {
            //throw new NotImplementedException();
            return Command(new _018_invRefItemConditionDomain() { ID = id }, "delete");
        }

        public IEnumerable<_018_invRefItemConditionDomain> Get()
        {
            return GetData(0);
        }

        public _018_invRefItemConditionDomain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_018_invRefItemConditionDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_018_invRefItemConditionDomain> GetData(int id)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter { ParameterName = "ID", Value = id, Direction = ParameterDirection.Input });
            return _dbHelper.GetRecords("sp018invRefItemConditionSelect", pars).Tables[0].AsEnumerable().Select(drow => new _018_invRefItemConditionDomain
            {
                ID = drow.Field<int>("ID"),
                StatusName = drow.Field<string>("StatusName")
            });
        }
    }
}
