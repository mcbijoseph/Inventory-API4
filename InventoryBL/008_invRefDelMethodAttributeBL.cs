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
    public interface I_008_invRefDelMethodAttributeBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {

    }


    public class _008_invRefDelMethodAttributeBL : Common.BaseBL, I_008_invRefDelMethodAttributeBL<_008_invRefDelMethodAttributeDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_008_invRefDelMethodAttributeDomain projectDomain, string commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@DelMethodID_010", Value = projectDomain.DelMethodID_010, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@MethodAttribute", Value = projectDomain.MethodAttribute, Direction = ParameterDirection.Input }
            };

            return this.GetMessage(_dbHelper.Command("sp008invRefDelMethodAttributeCommand", commandType, sqlParameters).Tables[0]);


        }

        public MessageViewDomain Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_008_invRefDelMethodAttributeDomain> Get()
        {
            return GetData(0);
        }

        public _008_invRefDelMethodAttributeDomain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_008_invRefDelMethodAttributeDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_008_invRefDelMethodAttributeDomain> GetData(int id)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add( new SqlParameter { ParameterName = "ID", Value = id, Direction = ParameterDirection.Input });
            return _dbHelper.GetRecords("sp008invRefDelMethodAttributeSelect", pars).Tables[0].AsEnumerable().Select(drow => new _008_invRefDelMethodAttributeDomain
            {
                ID = drow.Field<int>("ID"),
                DelMethodID_010 = drow.Field<int>("DelMethodID_010"),
                MethodAttribute = drow.Field<string>("MethodAttribute")
            });
        }
    }
}
