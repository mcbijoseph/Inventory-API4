
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

namespace InventoryBL.Test
{
    public interface I_007_invRefDocEntryListSampleBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {

    }
    public class _007_invRefDocEntryListSampleBL : Common.BaseBL, I_007_invRefDocEntryListSampleBL<Inventory_Domain_Layer.Test._007_invRefDocEntryListDomainSample>
    {
        private IDBHelper _dbHelper = new DBHelper();
        public MessageViewDomain Command(Inventory_Domain_Layer.Test._007_invRefDocEntryListDomainSample entity, Command commandType)
        {
            //throw new NotImplementedException();
            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter
                {
                    ParameterName = "@DocEntry",
                    Value = Newtonsoft.Json.JsonConvert.SerializeObject( entity),// projectDomain.ID,
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

        public IEnumerable<Inventory_Domain_Layer.Test._007_invRefDocEntryListDomainSample> Get()
        {
            throw new NotImplementedException();
        }

        public Inventory_Domain_Layer.Test._007_invRefDocEntryListDomainSample Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Inventory_Domain_Layer.Test._007_invRefDocEntryListDomainSample> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

    }
}
