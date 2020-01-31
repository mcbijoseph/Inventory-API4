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
    public interface I_020_invReleasedItemDetailsBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {

    }

    public class _020_invReleasedItemDetailsBL : Common.BaseBL, I_020_invReleasedItemDetailsBL<_020_invReleasedItemDetailsDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_020_invReleasedItemDetailsDomain projectDomain, Command commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@HeaderID_019", Value = projectDomain.HeaderID_019, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@ItemID_011", Value = projectDomain.ItemID_011, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@Qty", Value = projectDomain.Qty, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@Remarks", Value = projectDomain.Remarks, Direction = ParameterDirection.Input }

            };

            return this.GetMessage(_dbHelper.Command("sp020invReleasedItemDetailsCommand", commandType.ToString(), sqlParameters).Tables[0]);


        }

        public MessageViewDomain Delete(int id)
        {
            //throw new NotImplementedException();
            return Command(new _020_invReleasedItemDetailsDomain() { ID = id }, Inventory_Domain_Layer.Command.Delete);
        }

        public IEnumerable<_020_invReleasedItemDetailsDomain> Get()
        {
            return GetData(0);
        }

        public _020_invReleasedItemDetailsDomain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_020_invReleasedItemDetailsDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_020_invReleasedItemDetailsDomain> GetData(int id)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter { ParameterName = "ID", Value = id, Direction = ParameterDirection.Input });
            return _dbHelper.GetRecords("sp020invReleasedItemDetailsSelect", pars).Tables[0].AsEnumerable().Select(drow => new _020_invReleasedItemDetailsDomain
            {
                ID = drow.Field<int>("ID"),
                HeaderID_019 = drow.Field<int>("HeaderID_019"),
                ItemID_011 = drow.Field<int>("ItemID_011"),
                Qty = drow.Field<decimal>("Qty"),
                Remarks = drow.Field<string>("Remarks")
            });
        }
    }
}
