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
    public interface I_010_invRefDeliveryMethodBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {

    }


    public class _010_invRefDeliveryMethodBL : Common.BaseBL, I_010_invRefDeliveryMethodBL<_010_invRefDeliveryMethodDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_010_invRefDeliveryMethodDomain projectDomain, Command commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                
                //TOD:
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@Name", Value = projectDomain.Name, Direction = ParameterDirection.Input }

            };

            return this.GetMessage(_dbHelper.Command("sp010invRefDeliveryMethodCommand", commandType.ToString(), sqlParameters).Tables[0]);


        }

        public MessageViewDomain Delete(int id)
        {
            ///throw new NotImplementedException();
            return Command(new _010_invRefDeliveryMethodDomain() { ID = id }, Inventory_Domain_Layer.Command.Delete);
        }

        public IEnumerable<_010_invRefDeliveryMethodDomain> Get()
        {
            return GetData(0);
        }

        public _010_invRefDeliveryMethodDomain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_010_invRefDeliveryMethodDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_010_invRefDeliveryMethodDomain> GetData(int id)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter { ParameterName = "ID", Value = id, Direction = ParameterDirection.Input });
            return _dbHelper.GetRecords("sp010invRefDeliveryMethodSelect", pars).Tables[0].AsEnumerable().Select(drow => new _010_invRefDeliveryMethodDomain
            {
                ID = drow.Field<int>("ID"),
                Name = drow.Field<string>("Name")
            });
        }
    }
}
