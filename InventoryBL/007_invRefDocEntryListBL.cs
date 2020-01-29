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
    public interface I_007_invRefDocEntryListBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {

    }


    public class _007_invRefDocEntryListBL : Common.BaseBL, I_007_invRefDocEntryListBL<_007_invRefDocEntryListDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_007_invRefDocEntryListDomain projectDomain, string commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@SupID_VendorDB", Value = projectDomain.SupID_VendorDB, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@ProjectID_EnggDB", Value = projectDomain.ProjectID_EnggDB, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@DocumentNumber", Value = projectDomain.DocumentNumber, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@DeliveryDate", Value = projectDomain.DeliveryDate, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@EntryDate", Value = projectDomain.EntryDate, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@ReceiverID_HRDB", Value = projectDomain.ReceiverID_HRDB, Direction = ParameterDirection.Input }

            };

            return this.GetMessage(_dbHelper.Command("sp007RefDocEntryListCommand", commandType, sqlParameters).Tables[0]);
        }

        public MessageViewDomain Delete(int id)
        {
            ///throw new NotImplementedException();
            return Command(new _007_invRefDocEntryListDomain() { ID = id }, "delete");
        }

        public IEnumerable<_007_invRefDocEntryListDomain> Get()
        {
            return GetData(0);
        }

        public _007_invRefDocEntryListDomain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_007_invRefDocEntryListDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_007_invRefDocEntryListDomain> GetData(int id)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter { ParameterName = "ID", Value = id, Direction = ParameterDirection.Input });
            return _dbHelper.GetRecords("sp007invRefDocEntryListSelect", pars).Tables[0].AsEnumerable().Select(drow => new _007_invRefDocEntryListDomain
            {
                ID = drow.Field<int>("ID"),
                SupID_VendorDB = drow.Field<int>("SupID_VendorDB"),
                ProjectID_EnggDB = drow.Field<int>("ProjectID_EnggDB"),
                DocumentNumber = drow.Field<string>("DocumentNumber"),
                DeliveryDate = drow.Field<DateTime>("DeliveryDate"),
                EntryDate = drow.Field<DateTime>("EntryDate"),
                ReceiverID_HRDB = drow.Field<int>("ReceiverID_HRDB")
            });
        }
    }
}
