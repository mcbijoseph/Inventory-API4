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
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@Delivery_Date", Value = projectDomain.Delivery_Date, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@IELID_013", Value = projectDomain.IELID_013, Direction = ParameterDirection.Input }

            };

            return this.GetMessage(_dbHelper.Command("spProjectCommand", commandType, sqlParameters).Tables[0]);
        }

        public MessageViewDomain Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_007_invRefDeliveryDateDomain> Get()
        {
            return _dbHelper.GetRecords("sp007invRefDeliveryDateSelect").Tables[0].AsEnumerable().Select(drow => new _007_invRefDeliveryDateDomain
            {
                ID = drow.Field<int>("ID"),
                Delivery_Date = drow.Field<DateTime>("Delivery_Date"),
                IELID_013 = drow.Field<int>("IELID_013")
            }).ToList();
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
