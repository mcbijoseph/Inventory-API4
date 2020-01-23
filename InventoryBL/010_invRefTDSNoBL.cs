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
    public interface I_010_invRefTDSNoBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {

    }


    public class _010_invRefTDSNoBL : Common.BaseBL, I_010_invRefTDSNoBL<_010_invRefTDSNoDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_010_invRefTDSNoDomain projectDomain, string commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                
                //TOD:
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@Name", Value = projectDomain.Name, Direction = ParameterDirection.Input }

            };

            return this.GetMessage(_dbHelper.Command("spProjectCommand", commandType, sqlParameters).Tables[0]);


        }

        public MessageViewDomain Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_010_invRefTDSNoDomain> Get()
        {
            return _dbHelper.GetRecords("sp010invRefTDSNoSelect").Tables[0].AsEnumerable().Select(drow => new _010_invRefTDSNoDomain
            {
                ID = drow.Field<int>("ID"),
                Name = drow.Field<string>("Name")
            }).ToList();
        }

        public _010_invRefTDSNoDomain Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_010_invRefTDSNoDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }
    }
}
