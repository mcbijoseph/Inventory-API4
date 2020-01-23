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
    public interface I_008_invRefEntryDateBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {

    }


    public class _008_invRefEntryDateBL : Common.BaseBL, I_008_invRefEntryDateBL<_008_invRefEntryDateDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_008_invRefEntryDateDomain projectDomain, string commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@EntryDate", Value = projectDomain.EntryDate, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@IELID_013", Value = projectDomain.IELID_013, Direction = ParameterDirection.Input }
            };

            return this.GetMessage(_dbHelper.Command("spProjectCommand", commandType, sqlParameters).Tables[0]);


        }

        public MessageViewDomain Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_008_invRefEntryDateDomain> Get()
        {
            throw new NotImplementedException();
        }

        public _008_invRefEntryDateDomain Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_008_invRefEntryDateDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }
    }
}
