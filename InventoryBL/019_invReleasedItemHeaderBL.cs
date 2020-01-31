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
    public interface I_019_invReleasedItemHeaderBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {

    }

    public class _019_invReleasedItemHeaderBL : Common.BaseBL, I_019_invReleasedItemHeaderBL<_019_invReleasedItemHeaderDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_019_invReleasedItemHeaderDomain projectDomain, Command commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@Ctrlnumber", Value = projectDomain.Ctrlnumber, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@ProjectID_ENGGDB", Value = projectDomain.ProjectID_ENGGDB, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@Date", Value = projectDomain.Date, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@RequestbyHRMSDB", Value = projectDomain.RequestbyHRMSDB, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@ApprovedbyHRMSDB", Value = projectDomain.ApprovedbyHRMSDB, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@ReceivedbyHRMSDB", Value = projectDomain.ReceivedbyHRMSDB, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@ReceivedDate", Value = projectDomain.ReceivedDate, Direction = ParameterDirection.Input }
            };

            return this.GetMessage(_dbHelper.Command("sp019invReleasedItemHeaderCommand", commandType.ToString(), sqlParameters).Tables[0]);


        }

        public MessageViewDomain Delete(int id)
        {
            //throw new NotImplementedException();
            return Command(new _019_invReleasedItemHeaderDomain() { ID = id }, Inventory_Domain_Layer.Command.Delete);
        }

        public IEnumerable<_019_invReleasedItemHeaderDomain> Get()
        {
            return GetData(0);
        }

        public _019_invReleasedItemHeaderDomain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_019_invReleasedItemHeaderDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_019_invReleasedItemHeaderDomain> GetData(int id)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter { ParameterName = "ID", Value = id, Direction = ParameterDirection.Input });
            return _dbHelper.GetRecords("sp019invReleasedItemHeaderSelect", pars).Tables[0].AsEnumerable().Select(drow => new _019_invReleasedItemHeaderDomain
            {
                ID = drow.Field<int>("ID"),
                Ctrlnumber = drow.Field<string>("Ctrlnumber"),
                ProjectID_ENGGDB = drow.Field<int>("ProjectID_ENGGDB"),
                Date = drow.Field<DateTime>("Date"),
                RequestbyHRMSDB = drow.Field<int>("RequestbyHRMSDB"),
                ApprovedbyHRMSDB = drow.Field<int>("ApprovedbyHRMSDB"),
                ReceivedbyHRMSDB = drow.Field<int>("ReceivedbyHRMSDB"),
                ReceivedDate = drow.Field<DateTime>("ReceivedDate")
            });
        }
    }
}
