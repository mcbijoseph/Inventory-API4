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
    public interface I_024_RefCourierListBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {

    }

    public class _024_RefCourierListBL : Common.BaseBL, I_024_RefCourierListBL<_024_RefCourierListDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_024_RefCourierListDomain projectDomain, Command commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@Name", Value = projectDomain.Name, Direction = ParameterDirection.Input }
                
            };

            return this.GetMessage(_dbHelper.Command("sp024invRefCourierListCommand", commandType.ToString(), sqlParameters).Tables[0]);


        }

        public MessageViewDomain Delete(int id)
        {
            //throw new NotImplementedException();
            return Command(new _024_RefCourierListDomain() { ID = id }, Inventory_Domain_Layer.Command.Delete);
        }

        public IEnumerable<_024_RefCourierListDomain> Get()
        {
            return GetData(0);
        }

        public _024_RefCourierListDomain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_024_RefCourierListDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_024_RefCourierListDomain> GetData(int id)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter { ParameterName = "ID", Value = id, Direction = ParameterDirection.Input });
            return _dbHelper.GetRecords("sp024invRefCourierListSelect", pars).Tables[0].AsEnumerable().Select(drow => new _024_RefCourierListDomain
            {
                ID = drow.Field<int>("ID"),
                Name = drow.Field<string>("Name")
            });
        }
    }
}
