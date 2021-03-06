﻿using System;
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

    public interface I_004_invRefPropertyName1BL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {

    }


    public class _004_invRefPropertyName1BL : Common.BaseBL, I_004_invRefPropertyName1BL<_004_invRefPropertyName1Domain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_004_invRefPropertyName1Domain projectDomain, Command commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@Name", Value = projectDomain.Name, Direction = ParameterDirection.Input }
                
            };

            return this.GetMessage(_dbHelper.Command("sp004invRefPropertyName1Command", commandType.ToString(), sqlParameters).Tables[0]);


        }

        public MessageViewDomain Delete(int id)
        {
            ///throw new NotImplementedException();
            return Command(new _004_invRefPropertyName1Domain() { ID = id }, Inventory_Domain_Layer.Command.Delete);
        }

        public IEnumerable<_004_invRefPropertyName1Domain> Get()
        {
            return GetData(0);
        }

        public _004_invRefPropertyName1Domain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_004_invRefPropertyName1Domain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_004_invRefPropertyName1Domain> GetData(int id)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter { ParameterName = "ID", Value = id, Direction = ParameterDirection.Input });
            /*return _dbHelper.GetRecords("sp004invRefPropertyName1Select",pars).Tables[0].AsEnumerable().Select(drow => new _004_invRefPropertyName1Domain
            {
                ID = drow.Field<int>("ID"),
                Name = drow.Field<string>("Name"),
            });*/
            string tabledata = _dbHelper.GetRecords("sp004invRefPropertyName1Select", pars).Tables[0].Rows[0][0].ToString();//, Newtonsoft.Json.Formatting.None);
            return JsonConvert.DeserializeObject<List<_004_invRefPropertyName1Domain>>(tabledata);
        }
    }
}
