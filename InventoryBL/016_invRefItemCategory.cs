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
    public interface I_016_invRefItemCategoryBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {

    }


    public class _016_invRefItemCategoryBL : Common.BaseBL, I_016_invRefItemCategoryBL<_016_invRefItemCategoryDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_016_invRefItemCategoryDomain projectDomain, string commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@Cat3ID_003", Value = projectDomain.Cat3ID_003, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@ItemID_011", Value = projectDomain.ItemID_011, Direction = ParameterDirection.Input }

            };

            return this.GetMessage(_dbHelper.Command("sp016invRefItemCategoryCommand", commandType, sqlParameters).Tables[0]);


        }

        public MessageViewDomain Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_016_invRefItemCategoryDomain> Get()
        {
            return GetData(0);
        }

        public _016_invRefItemCategoryDomain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_016_invRefItemCategoryDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_016_invRefItemCategoryDomain> GetData(int id)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add( new SqlParameter { ParameterName = "ID", Value = id, Direction = ParameterDirection.Input });
            return _dbHelper.GetRecords("sp016invRefItemCategorySelect", pars).Tables[0].AsEnumerable().Select(drow => new _016_invRefItemCategoryDomain
            {
                ID = drow.Field<int>("ID"),
                Cat3ID_003 = drow.Field<int>("Cat3ID_003"),
                ItemID_011 = drow.Field<int>("ItemID_011")
            });
        }
    }
}
