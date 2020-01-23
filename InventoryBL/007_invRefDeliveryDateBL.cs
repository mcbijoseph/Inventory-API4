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
    public interface I_007_invRefDeliveryDateBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {

    }


    public class _007_invRefDeliveryDateBL : Common.BaseBL, I_007_invRefDeliveryDateBL<_007_invRefDeliveryDateDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_007_invRefDeliveryDateDomain projectDomain, string commandType)
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

        public IEnumerable<_007_invRefDeliveryDateDomain> Get()
        {
            throw new NotImplementedException();
        }

        public _007_invRefDeliveryDateDomain Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_007_invRefDeliveryDateDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }
    }
}
