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
    public interface I_017_invDeliveryMethodEntryListBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {

    }


    public class _017_invDeliveryMethodEntryListBL : Common.BaseBL, I_017_invDeliveryMethodEntryListBL<_017_invDeliveryMethodEntryListDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_017_invDeliveryMethodEntryListDomain projectDomain, string commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@DocEntryListID_007", Value = projectDomain.DocEntryListID_007, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@DelMethodAttrID_008", Value = projectDomain.DelMethodAttrID_008, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@AttributeValue", Value = projectDomain.AttributeValue, Direction = ParameterDirection.Input }

            };

            return this.GetMessage(_dbHelper.Command("sp017invDeliveryMethodEntryListCommand", commandType, sqlParameters).Tables[0]);


        }

        public MessageViewDomain Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_017_invDeliveryMethodEntryListDomain> Get()
        {
            return GetData(0);
        }

        public _017_invDeliveryMethodEntryListDomain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_017_invDeliveryMethodEntryListDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_017_invDeliveryMethodEntryListDomain> GetData(int id)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter { ParameterName = "ID", Value = id, Direction = ParameterDirection.Input });
            return _dbHelper.GetRecords("sp016invDeliveryMethodEntryListSelect", pars).Tables[0].AsEnumerable().Select(drow => new _017_invDeliveryMethodEntryListDomain
            {
                ID = drow.Field<int>("ID"),
                DocEntryListID_007= drow.Field<int>("DocEntryListID_007"),
                DelMethodAttrID_008 = drow.Field<int>("DelMethodAttrID_008"),
                AttributeValue = drow.Field<string>("AttributeValue")
            });
        }
    }
}
