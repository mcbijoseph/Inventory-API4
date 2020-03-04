using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.DAL;
using System.Data;
using System.Data.SqlClient;
using Inventory_API4.Models;
using Newtonsoft.Json;


namespace InventoryBL
{

    public interface I_003_invRefItemFullNameBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {

    }


    public class _003_invRefItemFullNameBL : Common.BaseBL, I_003_invRefItemFullNameBL<_003_invRefItemFullNameDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_003_invRefItemFullNameDomain projectDomain, Command commandType)
        {
            if (projectDomain.ItemsMasterListInfo == null)
                projectDomain.ItemsMasterListInfo = new object();
            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@Name", Value = projectDomain.Name, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@Cat2ID_002", Value = projectDomain.Cat2ID_002, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@hasAttribute", Value = projectDomain.hasAttribute, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@Category3Defaults", Value = JsonConvert.SerializeObject(projectDomain.Category3Defaults), Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@ItemsMasterListInfo", Value = JsonConvert.SerializeObject(projectDomain.ItemsMasterListInfo), Direction = ParameterDirection.Input }
            };

            return this.GetMessage(_dbHelper.Command("sp003invRefCategory3Command", commandType.ToString(), sqlParameters).Tables[0]);


        }

        public MessageViewDomain Delete(int id)
        {
            ///throw new NotImplementedException();
            return Command(new _003_invRefItemFullNameDomain() { ID = id }, Inventory_API4.Models.Command.Delete );
        }

        public IEnumerable<_003_invRefItemFullNameDomain> Get()
        {
            return GetData(0);
        }

        public _003_invRefItemFullNameDomain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_003_invRefItemFullNameDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_003_invRefItemFullNameDomain> GetData(int id)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter { ParameterName = "ID", Value = id, Direction = ParameterDirection.Input });
            /*return _dbHelper.GetRecords("sp003invRefCategory3Select", pars).Tables[0].AsEnumerable().Select(drow => new _003_invRefItemFullNameDomain
            {
                ID = drow.Field<int>("ID"),
                Name = drow.Field<string>("Name"),
                Cat2ID_002 = drow.Field<int>("Cat2ID_002")
            });*/

            string tabledata = _dbHelper.GetRecords("sp003invRefCategory3Select", pars).Tables[0].Rows[0][0].ToString();//, Newtonsoft.Json.Formatting.None);
            return JsonConvert.DeserializeObject<List<_003_invRefItemFullNameDomain>>(tabledata);
        }
    }
}
