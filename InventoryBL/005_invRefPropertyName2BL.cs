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
    public interface I_005_invRefPropertyName2BL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {

    }


    public class _005_invRefPropertyName2BL : Common.BaseBL, I_005_invRefPropertyName2BL<_005_invRefPropertyName2Domain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_005_invRefPropertyName2Domain projectDomain, string commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                
                //TOD:
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@Name", Value = projectDomain.Name, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@FullName", Value = projectDomain.FullName, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@Prop1ID_004", Value = projectDomain.Prop1ID_004, Direction = ParameterDirection.Input }
            };

            return this.GetMessage(_dbHelper.Command("spProjectCommand", commandType, sqlParameters).Tables[0]);


        }

        public MessageViewDomain Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_005_invRefPropertyName2Domain> Get()
        {
            throw new NotImplementedException();
        }

        public _005_invRefPropertyName2Domain Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_005_invRefPropertyName2Domain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }
    }
}
