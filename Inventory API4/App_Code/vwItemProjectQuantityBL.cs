using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.DAL;
using System.Data.SqlClient;
using Newtonsoft.Json;
using Inventory_API4.Models;
using InventoryBL.Common;

namespace InventoryBL
{
    public interface IvwItemProjectQuantityBL: Common.IBaseBL<vwItemProjectQuantity>
    {
        IEnumerable<vwItemProjectQuantity> GetRecords(int ProjectID);
    }
    public class vwItemProjectQuantityBL : IvwItemProjectQuantityBL
    {
        
        private IDBHelper _dbHelper;
        public vwItemProjectQuantityBL()
        {
            _dbHelper = new DBHelper();
        }
      
        public MessageViewDomain Command(vwItemProjectQuantity entity, Command commandType)
        {
            throw new NotImplementedException();
        }

        public MessageViewDomain Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<vwItemProjectQuantity> Get()
        {
            throw new NotImplementedException();
        }

        public vwItemProjectQuantity Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<vwItemProjectQuantity> GetRecords(int ProjectID)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter("@ProjectID", System.Data.SqlDbType.Int) { Value = ProjectID }
            };

            return JsonConvert.DeserializeObject<IEnumerable<vwItemProjectQuantity>>(_dbHelper.GetRecords("spGetItemWithAccountability", sqlParameters).Tables[0].Rows[0][0].ToString());
        }

        public IEnumerable<vwItemProjectQuantity> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        
    }
}
