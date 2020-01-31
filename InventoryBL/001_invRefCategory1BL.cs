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

    public interface I_001_invRefCategory1BL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {

    }


    public class _001_invRefCategory1BL : Common.BaseBL, I_001_invRefCategory1BL<_001_invRefCategory1Domain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_001_invRefCategory1Domain projectDomain, Command commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@Name", Value = projectDomain.Name, Direction = ParameterDirection.Input }
            };

            return this.GetMessage(_dbHelper.Command("sp001invRefCategory1Command", commandType.ToString(), sqlParameters).Tables[0]);

            
        }

        public MessageViewDomain Delete(int id)
        {
            // throw new NotImplementedException();
            return Command(new _001_invRefCategory1Domain() { ID = id }, Inventory_Domain_Layer.Command.Delete);
        }

        public IEnumerable<_001_invRefCategory1Domain> Get()
        {
            return GetData(0);
        }

        public _001_invRefCategory1Domain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_001_invRefCategory1Domain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// Reuse the query
        /// </summary>
        /// <param name="id">0 Means ALL</param>
        /// <returns>List</returns>
        private IEnumerable<_001_invRefCategory1Domain> GetData(int id)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter { ParameterName = "ID", Value = id, Direction = ParameterDirection.Input });

            return _dbHelper.GetRecords("sp001invRefCategory1Select", pars).Tables[0].AsEnumerable().Select
            (
                drow => new _001_invRefCategory1Domain
                {
                    ID = drow.Field<int>("ID"),
                    Name = drow.Field<string>("Name")
                }
            );
        }


    }
}
