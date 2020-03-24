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
    public interface I_033_invRefCategory3DefaultAttributeBL<TEntity> : InventoryBL.Common.IBaseBL<TEntity> where TEntity : class
    {
    }

    public class _033_invRefCategory3DefaultAttributeBL : Common.BaseBL, I_033_invRefCategory3DefaultAttributeBL<_033_invRefCategory3DefaultAttributeDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_033_invRefCategory3DefaultAttributeDomain projectDomain, Command commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@Cat3ID_003", Value = projectDomain.Cat3ID_003, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@AttrId_006", Value = projectDomain.AttrId_006, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@isRequired", Value = projectDomain.isRequired, Direction = ParameterDirection.Input }
            };

            return this.GetMessage(_dbHelper.Command("sp003invRefCategory3Command", commandType.ToString(), sqlParameters).Tables[0]);


        }

        public MessageViewDomain Delete(int id)
        {
            // throw new NotImplementedException();
            return Command(new _033_invRefCategory3DefaultAttributeDomain() { ID = id }, Inventory_API4.Models.Command.Delete);
        }

        public IEnumerable<_033_invRefCategory3DefaultAttributeDomain> Get()
        {
            return GetData(0);
        }

        public _033_invRefCategory3DefaultAttributeDomain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_033_invRefCategory3DefaultAttributeDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reuse the query
        /// </summary>
        /// <param name="id">0 Means ALL</param>
        /// <returns>List</returns>
        private IEnumerable<_033_invRefCategory3DefaultAttributeDomain> GetData(int id)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter { ParameterName = "ID", Value = id, Direction = ParameterDirection.Input });

            /*return _dbHelper.GetRecords("sp001invRefCategory1Select", pars).Tables[0].AsEnumerable().Select
            (
                drow => new _001_invRefCategory1Domain
                {
                    ID = drow.Field<int>("ID"),
                    Name = drow.Field<string>("Name")
                }
            );*/
            string tabledata = _dbHelper.GetRecords("sp001invRefCategory1Select", pars).Tables[0].Rows[0][0].ToString();//, Newtonsoft.Json.Formatting.None);
            return JsonConvert.DeserializeObject<List<_033_invRefCategory3DefaultAttributeDomain>>(tabledata);

        }

        /*public object GetCategory3(int id)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter { ParameterName = "ID", Value = id, Direction = ParameterDirection.Input });

            *//*return _dbHelper.GetRecords("sp001invRefCategory1Select", pars).Tables[0].AsEnumerable().Select
            (
                drow => new _001_invRefCategory1Domain
                {
                    ID = drow.Field<int>("ID"),
                    Name = drow.Field<string>("Name")
                }
            );*//*
            string tabledata = _dbHelper.GetRecords("sp003invRefCategory3Select", pars).Tables[0].Rows[0][0].ToString();//, Newtonsoft.Json.Formatting.None);
            return JsonConvert.DeserializeObject(tabledata);

        }*/
    }
}