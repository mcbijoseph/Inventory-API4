using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.DAL;
using System.Data;
using System.Data.SqlClient;
using Inventory_Domain_Layer;
using InventoryBL.Common;

namespace InventoryBL
{
    public interface I_013_invItemsEntryListBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {

    }


    public class _013_invItemsEntryListBL : Common.BaseBL, I_013_invItemsEntryListBL<_013_invItemsEntryListDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_013_invItemsEntryListDomain projectDomain, string commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@DelID_007", Value = projectDomain.DelID_007, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@Emp_Receive_ID", Value = projectDomain.Emp_Receive_ID, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@EntID_008", Value = projectDomain.EntID_008, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@ItemID_011", Value = projectDomain.ItemID_011, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@Qty", Value = projectDomain.Qty, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@Sup_ID", Value = projectDomain.Sup_ID, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@TDSID_010", Value = projectDomain.TDSID_010, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@UnitID_009", Value = projectDomain.UnitID_009, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@UnitPrice", Value = projectDomain.UnitPrice, Direction = ParameterDirection.Input }

            };

            return this.GetMessage(_dbHelper.Command("spProjectCommand", commandType, sqlParameters).Tables[0]);


        }

        public MessageViewDomain Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_013_invItemsEntryListDomain> Get()
        {
            return GetData(0);
        }

        public _013_invItemsEntryListDomain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_013_invItemsEntryListDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_013_invItemsEntryListDomain> GetData(int id)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add( new SqlParameter { ParameterName = "ID", Value = id, Direction = ParameterDirection.Input });
            return _dbHelper.GetRecords("sp013invItemsEntryListSelect", pars).Tables[0].AsEnumerable().Select(drow => new _013_invItemsEntryListDomain
            {
                ID = drow.Field<int>("ID"),
                DelID_007 = drow.Field<int>("DelID_007"),
                Emp_Receive_ID = drow.Field<int>("Emp_Receive_ID"),
                EntID_008 = drow.Field<int>("EntID_008"),
                ItemID_011 = drow.Field<int>("ItemID_011"),
                Qty = drow.Field<decimal>("Qty"),
                Sup_ID = drow.Field<int>("Sup_ID"),
                TDSID_010 = drow.Field<int>("TDSID_010"),
                UnitID_009 = drow.Field<int>("UnitID_009"),
                UnitPrice = drow.Field<decimal>("UnitPrice")
            });
        }
    }
}
