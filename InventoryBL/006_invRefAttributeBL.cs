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

    public interface I_006_invRefAttributeBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {
    }


    public class _006_invRefAttributeBL : Common.BaseBL, I_006_invRefAttributeBL<_006_invRefAttributeDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_006_invRefAttributeDomain projectDomain, string commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@Name", Value = projectDomain.Name, Direction = ParameterDirection.Input }
                
            };

            return this.GetMessage(_dbHelper.Command("spProjectCommand", commandType, sqlParameters).Tables[0]);


        }

        public MessageViewDomain Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_006_invRefAttributeDomain> Get()
        {
            return _dbHelper.GetRecords("sp006invRefAttributeSelect").Tables[0].AsEnumerable().Select(drow => new _006_invRefAttributeDomain
            {
                ID = drow.Field<int>("ID"),
                Name = drow.Field<string>("Name")
            }).ToList();
        }

        public _006_invRefAttributeDomain Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_006_invRefAttributeDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }
    }
}
