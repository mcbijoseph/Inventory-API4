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


    public interface I_002_invRefCategory2BL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {

    }


    public class _002_invRefCategory2BL : Common.BaseBL, I_002_invRefCategory2BL<_002_invRefCategory2Domain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_002_invRefCategory2Domain projectDomain, Command commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@ProjectName", Value = projectDomain.Name, Direction = ParameterDirection.Input }
                
            };

            return this.GetMessage(_dbHelper.Command("sp002invRefCategory2Command", commandType, sqlParameters).Tables[0]);


        }

        public MessageViewDomain Delete(int id)
        {
            ///throw new NotImplementedException();
            return Command(new _002_invRefCategory2Domain() { ID = id }, Inventory_Domain_Layer.Command.Delete);
        }

        public IEnumerable<_002_invRefCategory2Domain> Get()
        {
            return GetData(0);
        }

        public _002_invRefCategory2Domain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_002_invRefCategory2Domain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_002_invRefCategory2Domain> GetData(int id)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter { ParameterName = "ID", Value = id, Direction = ParameterDirection.Input });
            return _dbHelper.GetRecords("sp002invRefCategory2Select", pars).Tables[0].AsEnumerable().Select(drow => new _002_invRefCategory2Domain
            {
                ID = drow.Field<int>("ID"),
                Name = drow.Field<string>("Name"),
                Cat1ID_001 = drow.Field<int>("Cat1ID_001")
            });
        }
    }
}
