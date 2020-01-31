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
    public interface I_021_invTransferedItemsHeaderBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {

    }

    public class _021_invTransferedItemsHeaderBL : Common.BaseBL, I_021_invTransferedItemsHeaderBL<_021_invTransferedItemsHeaderDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_021_invTransferedItemsHeaderDomain projectDomain, Command commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@Ctrlnumber", Value = projectDomain.Ctrlnumber, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@ProjectID_ENGGDB", Value = projectDomain.ProjectID_ENGGDB, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@WarehouseInCharge_HRMSDB", Value = projectDomain.WarehouseInCharge_HRMSDB, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@DatePrepared", Value = projectDomain.DatePrepared, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@ReceiverWarehouseInCharge_HRMSDB", Value = projectDomain.ReceiverWarehouseInCharge_HRMSDB, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@ReceiverProjectID_ENGGDB", Value = projectDomain.ReceiverProjectID_ENGGDB, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@ReceivedDate", Value = projectDomain.ReceivedDate, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@DocEntryListID_007", Value = projectDomain.DocEntryListID_007, Direction = ParameterDirection.Input }

            };

            return this.GetMessage(_dbHelper.Command("sp021invTransferedItemsHeaderCommand", commandType.ToString(), sqlParameters).Tables[0]);


        }

        public MessageViewDomain Delete(int id)
        {
            //throw new NotImplementedException();
            return Command(new _021_invTransferedItemsHeaderDomain() { ID = id }, Inventory_Domain_Layer.Command.Delete);
        }

        public IEnumerable<_021_invTransferedItemsHeaderDomain> Get()
        {
            return GetData(0);
        }

        public _021_invTransferedItemsHeaderDomain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_021_invTransferedItemsHeaderDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_021_invTransferedItemsHeaderDomain> GetData(int id)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter { ParameterName = "ID", Value = id, Direction = ParameterDirection.Input });
            return _dbHelper.GetRecords("sp021invTransferedItemsHeaderSelect", pars).Tables[0].AsEnumerable().Select(drow => new _021_invTransferedItemsHeaderDomain
            {
                ID = drow.Field<int>("ID"),
                Ctrlnumber = drow.Field<string>("Ctrlnumber"),
                ProjectID_ENGGDB = drow.Field<int>("ProjectID_ENGGDB"),
                WarehouseInCharge_HRMSDB = drow.Field<int>("WarehouseInCharge_HRMSDB"),
                DatePrepared = drow.Field<DateTime>("DatePrepared"),
                ReceiverWarehouseInCharge_HRMSDB = drow.Field<int>("ReceiverWarehouseInCharge_HRMSDB"),
                ReceiverProjectID_ENGGDB = drow.Field<int>("ReceiverProjectID_ENGGDB"),
                ReceivedDate = drow.Field<DateTime>("ReceivedDate"),
                DocEntryListID_007 = drow.Field<int>("DocEntryListID_007")
            });
        }
    }
}
