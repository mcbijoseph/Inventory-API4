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

    public interface I_003_invRefCategory3BL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {

    }


    public class _003_invRefCategory3BL : Common.BaseBL, I_003_invRefCategory3BL<_003_invRefCategory3Domain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_003_invRefCategory3Domain projectDomain, string commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@ProjectName", Value = projectDomain.Name, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@Cat2ID_002", Value = projectDomain.Cat2ID_002, Direction = ParameterDirection.Input }
            };

            return this.GetMessage(_dbHelper.Command("sp003invRefCategory3Command", commandType, sqlParameters).Tables[0]);


        }

        public MessageViewDomain Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_003_invRefCategory3Domain> Get()
        {
            return GetData(0);
        }

        public _003_invRefCategory3Domain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_003_invRefCategory3Domain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_003_invRefCategory3Domain> GetData(int id)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter { ParameterName = "ID", Value = id, Direction = ParameterDirection.Input });
            return _dbHelper.GetRecords("sp003invRefCategory3Select", pars).Tables[0].AsEnumerable().Select(drow => new _003_invRefCategory3Domain
            {
                ID = drow.Field<int>("ID"),
                Name = drow.Field<string>("Name"),
                Cat2ID_002 = drow.Field<int>("Cat2ID_002")
            });
        }
    }
}
