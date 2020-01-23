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

    public interface I_009_invRefUnitsBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {

    }


    public class _009_invRefUnitsBL : Common.BaseBL, I_009_invRefUnitsBL<_009_invRefUnitsDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_009_invRefUnitsDomain projectDomain, string commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                
                //TOD:
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@ProjectName", Value = projectDomain.Name, Direction = ParameterDirection.Input }

            };

            return this.GetMessage(_dbHelper.Command("spProjectCommand", commandType, sqlParameters).Tables[0]);


        }

        public MessageViewDomain Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_009_invRefUnitsDomain> Get()
        {
            return _dbHelper.GetRecords("sp009invRefUnitsSelect").Tables[0].AsEnumerable().Select(drow => new _009_invRefUnitsDomain
            {
                ID = drow.Field<int>("ID"),
                Name = drow.Field<string>("Name")
            }).ToList();
        }

        public _009_invRefUnitsDomain Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_009_invRefUnitsDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }
    }
}
