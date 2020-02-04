using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.DAL;
using System.Data;
using System.Data.SqlClient;
using Inventory_Domain_Layer;
using Newtonsoft.Json;

namespace InventoryBL
{
    public interface I_027_invWithdrawMasterListBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {
    }

    public class _027_invWithdrawMasterListBL : Common.BaseBL, I_027_invWithdrawMasterListBL<_027_invWithdrawMasterListDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_027_invWithdrawMasterListDomain projectDomain, Command commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@CtrlNumber", Value = projectDomain.CtrlNumber, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@WidraweeNameID_Hrms", Value = projectDomain.WidraweeNameID_Hrms, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@ProjectNameID_EnggDB", Value = projectDomain.ProjectNameID_EnggDB, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@RequestedByID_HrmsDB", Value = projectDomain.RequestedByID_HrmsDB, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@ApprovedByID_HrmsDB", Value = projectDomain.ApprovedByID_HrmsDB, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@RecievedByID_HrmsDB", Value = projectDomain.RecievedByID_HrmsDB, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@Date", Value = projectDomain.Date, Direction = ParameterDirection.Input }
            };

            return this.GetMessage(_dbHelper.Command("sp027invWithdrawMasterListCommand", commandType.ToString(), sqlParameters).Tables[0]);


        }

        public MessageViewDomain Delete(int id)
        {
            // throw new NotImplementedException();
            return Command(new _027_invWithdrawMasterListDomain() { ID = id }, Inventory_Domain_Layer.Command.Delete);
        }

        public IEnumerable<_027_invWithdrawMasterListDomain> Get()
        {
            return GetData(0);
        }

        public _027_invWithdrawMasterListDomain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_027_invWithdrawMasterListDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reuse the query
        /// </summary>
        /// <param name="id">0 Means ALL</param>
        /// <returns>List</returns>
        private IEnumerable<_027_invWithdrawMasterListDomain> GetData(int id)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter { ParameterName = "ID", Value = id, Direction = ParameterDirection.Input });

            /*return _dbHelper.GetRecords("sp001invRefCategory1Select", pars).Tables[0].AsEnumerable().Select
            (
                drow => new _027_invWithdrawMasterListDomain
                {
                    ID = drow.Field<int>("ID"),
                    Name = drow.Field<string>("Name")
                }
            );*/
            string tabledata = _dbHelper.GetRecords("sp027invWithdrawMasterListSelect", pars).Tables[0].Rows[0][0].ToString() ?? "{}";//, Newtonsoft.Json.Formatting.None);
            return JsonConvert.DeserializeObject<List<_027_invWithdrawMasterListDomain>>(tabledata);

        }
    }
}
