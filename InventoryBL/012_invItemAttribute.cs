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
    public interface I_012_invItemAttributeBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {

    }


    public class _012_invItemAttrivbuteBL : Common.BaseBL, I_012_invItemAttributeBL<_012_invItemAttributeDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_012_invItemAttributeDomain projectDomain, string commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@ItemID_011", Value = projectDomain.ItemID_011, Direction = ParameterDirection.Input }
        
            };

            return this.GetMessage(_dbHelper.Command("spProjectCommand", commandType, sqlParameters).Tables[0]);


        }

        public MessageViewDomain Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_012_invItemAttributeDomain> Get()
        {
            throw new NotImplementedException();
        }

        public _012_invItemAttributeDomain Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_012_invItemAttributeDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }
    }
}
