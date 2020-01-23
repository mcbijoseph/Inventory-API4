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
            throw new NotImplementedException();
        }

        public _013_invItemsEntryListDomain Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_013_invItemsEntryListDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        
    }
}
