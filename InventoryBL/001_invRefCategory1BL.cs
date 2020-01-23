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

    public interface I_001_invRefCategory1BL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {

    }


    public class _001_invRefCategory1BL : Common.BaseBL, I_001_invRefCategory1BL<_001_invRefCategory1Domain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_001_invRefCategory1Domain projectDomain, string commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@Name", Value = projectDomain.Name, Direction = ParameterDirection.Input }
            };

            return this.GetMessage(_dbHelper.Command("spProjectCommand", commandType, sqlParameters).Tables[0]);

            
        }

        public MessageViewDomain Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_001_invRefCategory1Domain> Get()
        {
            throw new NotImplementedException();
        }

        public _001_invRefCategory1Domain Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_001_invRefCategory1Domain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }
    }
}
