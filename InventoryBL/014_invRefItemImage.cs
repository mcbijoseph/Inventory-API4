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
    public interface I_014_invRefItemImageBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {

    }


    public class _014_invRefItemImageBL : Common.BaseBL, I_014_invRefItemImageBL<_014_invRefItemImageDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_014_invRefItemImageDomain projectDomain, string commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@Extension", Value = projectDomain.Extension, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@ImageName", Value = projectDomain.ImageName, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@isProfile", Value = projectDomain.isProfile, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@ItemID", Value = projectDomain.ItemID, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@Order", Value = projectDomain.Order, Direction = ParameterDirection.Input }

            };

            return this.GetMessage(_dbHelper.Command("spProjectCommand", commandType, sqlParameters).Tables[0]);


        }

        public MessageViewDomain Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_014_invRefItemImageDomain> Get()
        {
            throw new NotImplementedException();
        }

        public _014_invRefItemImageDomain Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_014_invRefItemImageDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }
    }
}
