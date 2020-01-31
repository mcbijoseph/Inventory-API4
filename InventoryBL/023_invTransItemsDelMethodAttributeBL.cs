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
    public interface I_023_invTransItemsDelMethodAttributeBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {

    }

    public class _023_invTransItemsDelMethodAttributeBL : Common.BaseBL, I_023_invTransItemsDelMethodAttributeBL<_023_invTransItemsDelMethodAttributeDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_023_invTransItemsDelMethodAttributeDomain projectDomain, string commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@HeaderID_021", Value = projectDomain.HeaderID_021, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@DeliveryAttrID_008", Value = projectDomain.DeliveryAttrID_008, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@AttributeValue", Value = projectDomain.AttributeValue, Direction = ParameterDirection.Input }

            };

            return this.GetMessage(_dbHelper.Command("sp023invTransItemsDelMethodAttributeCommand", commandType, sqlParameters).Tables[0]);


        }

        public MessageViewDomain Delete(int id)
        {
            //throw new NotImplementedException();
            return Command(new _023_invTransItemsDelMethodAttributeDomain() { ID = id }, "delete");
        }

        public IEnumerable<_023_invTransItemsDelMethodAttributeDomain> Get()
        {
            return GetData(0);
        }

        public _023_invTransItemsDelMethodAttributeDomain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_023_invTransItemsDelMethodAttributeDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_023_invTransItemsDelMethodAttributeDomain> GetData(int id)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter { ParameterName = "ID", Value = id, Direction = ParameterDirection.Input });
            return _dbHelper.GetRecords("sp023invTransItemsDelMethodAttributeSelect", pars).Tables[0].AsEnumerable().Select(drow => new _023_invTransItemsDelMethodAttributeDomain
            {
                ID = drow.Field<int>("ID"),
                HeaderID_021 = drow.Field<int>("HeaderID_021"),
                DeliveryAttrID_008 = drow.Field<int>("DeliveryAttrID_008"),
                AttributeValue = drow.Field<string>("AttributeValue")
            });
        }
    }
}
