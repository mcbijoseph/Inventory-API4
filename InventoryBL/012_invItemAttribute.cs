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
    public interface I_012_invItemAttributeBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {

    }


    public class _012_invItemAttrivbuteBL : Common.BaseBL, I_012_invItemAttributeBL<_012_invItemAttributeDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_012_invItemAttributeDomain projectDomain, string commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@ItemID_011", Value = projectDomain.ItemID_011, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@AttID_006", Value = projectDomain.AttID_006, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@AttributeValue", Value = projectDomain.AttributeValue, Direction = ParameterDirection.Input }

            };

            return this.GetMessage(_dbHelper.Command("sp012invItemAttributeCommand", commandType, sqlParameters).Tables[0]);


        }

        public MessageViewDomain Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_012_invItemAttributeDomain> Get()
        {
            return GetData(0);
        }

        public _012_invItemAttributeDomain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_012_invItemAttributeDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_012_invItemAttributeDomain> GetData(int id)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add( new SqlParameter { ParameterName = "ID", Value = id, Direction = ParameterDirection.Input });
            return _dbHelper.GetRecords("sp012invItemAttributeSelect", pars).Tables[0].AsEnumerable().Select(drow => new _012_invItemAttributeDomain
            {
                ID = drow.Field<int>("ID"),
                AttID_006 = drow.Field<int>("AttID_006"),
                ItemID_011 = drow.Field<int>("ItemID_011"),
                AttributeValue = drow.Field<string>("AttributeValue")
            });
        }
    }
}
