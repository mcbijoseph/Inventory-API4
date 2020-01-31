using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory;
using Inventory_Domain_Layer;
using Inventory_Domain_Layer.Derived;
using System.Data;
using System.Data.SqlClient;
using Inventory.DAL;

namespace InventoryBL.Derived
{
    public interface IStockEntryBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {

    }
    public class StockEntryBL : Common.BaseBL, IStockEntryBL<Inventory_Domain_Layer.Derived.StockEntryDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();
        public MessageViewDomain Command(StockEntryDomain entity, Command commandType)
        {
            //throw new NotImplementedException();
            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter
                {
                    ParameterName = "@DocEntry",
                    Value = Newtonsoft.Json.JsonConvert.SerializeObject( entity.DocEntry),// projectDomain.ID,
                    Direction = ParameterDirection.Input
                },
                new SqlParameter
                {
                    ParameterName = "@ItemsEntry",
                    Value = Newtonsoft.Json.JsonConvert.SerializeObject( entity.ItemEntryList),// projectDomain.Name,
                    Direction = ParameterDirection.Input
                },
                new SqlParameter
                {
                    ParameterName = "@DeliveryEntry",
                    Value = Newtonsoft.Json.JsonConvert.SerializeObject( entity.DeliveryEntry ),// projectDomain.Name,
                    Direction = ParameterDirection.Input
                }
            };

            return this.GetMessage(_dbHelper.Command("spDeriveStockEntryCommand", commandType.ToString(), sqlParameters).Tables[0]);

        }

        public MessageViewDomain Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StockEntryDomain> Get()
        {
            throw new NotImplementedException();
        }

        public StockEntryDomain Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StockEntryDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }
        
    }
}
