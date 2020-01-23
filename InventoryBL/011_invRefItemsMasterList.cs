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
    public interface I_011_invRefItemsMasterListBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {

    }


    public class _011_invRefItemsMasterListBL : Common.BaseBL, I_011_invRefItemsMasterListBL<_011_invRefItemsMasterListDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_011_invRefItemsMasterListDomain projectDomain, string commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                /***
                //TOD:
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@ProjectName", Value = projectDomain.ProjectName, Direction = ParameterDirection.Input }
                */
            };

            return this.GetMessage(_dbHelper.Command("spProjectCommand", commandType, sqlParameters).Tables[0]);


        }

        public MessageViewDomain Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_011_invRefItemsMasterListDomain> Get()
        {
            throw new NotImplementedException();
        }

        public _011_invRefItemsMasterListDomain Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_011_invRefItemsMasterListDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }
    }
}
