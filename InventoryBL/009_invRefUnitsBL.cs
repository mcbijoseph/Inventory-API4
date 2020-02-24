using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.DAL;
using System.Data;
using System.Data.SqlClient;
using Inventory_API4.Models;

namespace InventoryBL
{

    public interface I_009_invRefUnitsBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {

    }


    public class _009_invRefUnitsBL : Common.BaseBL, I_009_invRefUnitsBL<_009_invRefUnitsDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_009_invRefUnitsDomain projectDomain, Command commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                
                //TOD:
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@ShortName", Value = projectDomain.ShortName, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@FullName", Value = projectDomain.FullName, Direction = ParameterDirection.Input }

            };

            return this.GetMessage(_dbHelper.Command("sp009invRefUnitsCommand", commandType.ToString(), sqlParameters).Tables[0]);


        }

        public MessageViewDomain Delete(int id)
        {
            ///throw new NotImplementedException();
            return Command(new _009_invRefUnitsDomain() { ID = id }, Inventory_Domain_Layer.Command.Delete);
        }

        public IEnumerable<_009_invRefUnitsDomain> Get()
        {
            return GetData(0);
        }

        public _009_invRefUnitsDomain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_009_invRefUnitsDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_009_invRefUnitsDomain> GetData(int id)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter { ParameterName = "ID", Value = id, Direction = ParameterDirection.Input });
            return _dbHelper.GetRecords("sp009invRefUnitsSelect", pars).Tables[0].AsEnumerable().Select(drow => new _009_invRefUnitsDomain
            {
                ID = drow.Field<int>("ID"),
                ShortName = drow.Field<string>("ShortName"),
                FullName = drow.Field<string>("FullName")
            });
        }
    }
}
