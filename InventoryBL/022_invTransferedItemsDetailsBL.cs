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
    public interface I_022_invTransferedItemsDetailsBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {

    }

    public class _022_invTransferedItemsDetailsBL : Common.BaseBL, I_022_invTransferedItemsDetailsBL<_022_invTransferedItemsDetailsDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_022_invTransferedItemsDetailsDomain projectDomain, Command commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@HeaderID_021", Value = projectDomain.HeaderID_021, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@ItemID_011", Value = projectDomain.ItemID_011, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@UnitID_009", Value = projectDomain.UnitID_009, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@Quantity", Value = projectDomain.Quantity, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@ItemConditionId_018", Value = projectDomain.ItemConditionId_018, Direction = ParameterDirection.Input }

            };

            return this.GetMessage(_dbHelper.Command("sp022invTransferedItemsDetailsCommand", commandType.ToString(), sqlParameters).Tables[0]);


        }

        public MessageViewDomain Delete(int id)
        {
            //throw new NotImplementedException();
            return Command(new _022_invTransferedItemsDetailsDomain() { ID = id }, Inventory_Domain_Layer.Command.Delete);
        }

        public IEnumerable<_022_invTransferedItemsDetailsDomain> Get()
        {
            return GetData(0);
        }

        public _022_invTransferedItemsDetailsDomain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_022_invTransferedItemsDetailsDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_022_invTransferedItemsDetailsDomain> GetData(int id)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter { ParameterName = "ID", Value = id, Direction = ParameterDirection.Input });
            return _dbHelper.GetRecords("sp022invTransferedItemsDetailsSelect", pars).Tables[0].AsEnumerable().Select(drow => new _022_invTransferedItemsDetailsDomain
            {
                ID = drow.Field<int>("ID"),
                HeaderID_021 = drow.Field<int>("HeaderID_021"),
                ItemID_011 = drow.Field<int>("ItemID_011"),
                UnitID_009 = drow.Field<int>("UnitID_009"),
                Quantity = drow.Field<decimal>("Quantity"),
                ItemConditionId_018 = drow.Field<int>("ItemConditionId_018")
            });
        }
    }
}
