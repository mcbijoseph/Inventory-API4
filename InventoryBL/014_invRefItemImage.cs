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
    public interface I_014_invRefItemImageBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {

    }


    public class _014_invRefItemImageBL : Common.BaseBL, I_014_invRefItemImageBL<_014_invRefItemImageDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_014_invRefItemImageDomain projectDomain, string commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@Extension", Value = projectDomain.Extension, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@ImageName", Value = projectDomain.ImageName, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@isProfile", Value = projectDomain.isProfile, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@ItemID_011", Value = projectDomain.ItemID_011, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@Order", Value = projectDomain.Order, Direction = ParameterDirection.Input }

            };

            return this.GetMessage(_dbHelper.Command("sp014invRefItemImageCommand", commandType, sqlParameters).Tables[0]);


        }

        public MessageViewDomain Delete(int id)
        {
            ///throw new NotImplementedException();
            return Command(new _014_invRefItemImageDomain() { ID = id }, "delete");
        }

        public IEnumerable<_014_invRefItemImageDomain> Get()
        {
            return GetData(0);
        }

        public _014_invRefItemImageDomain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_014_invRefItemImageDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_014_invRefItemImageDomain> GetData(int id)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add( new SqlParameter { ParameterName = "ID", Value = id, Direction = ParameterDirection.Input });
            return _dbHelper.GetRecords("sp014invRefItemImageSelect", pars).Tables[0].AsEnumerable().Select(drow => new _014_invRefItemImageDomain
            {
                ID = drow.Field<int>("ID"),
                Extension = drow.Field<string>("Extension"),
                ImageName = drow.Field<string>("ImageName"),
                isProfile = drow.Field<bool>("isProfile"),
                ItemID_011 = drow.Field<int>("ItemID_011"),
                Order = drow.Field<int>("Order")
            });
        }
    }
}
