﻿using System;
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
    public interface I_005_invRefPropertyName2BL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {

    }


    public class _005_invRefPropertyName2BL : Common.BaseBL, I_005_invRefPropertyName2BL<_005_invRefPropertyName2Domain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_005_invRefPropertyName2Domain projectDomain, Command commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                
                //TOD:
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@Name", Value = projectDomain.Name, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@FullName", Value = projectDomain.FullName, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@Prop1ID_004", Value = projectDomain.Prop1ID_004, Direction = ParameterDirection.Input }
            };

            return this.GetMessage(_dbHelper.Command("sp005invRefPropertyName2Command", commandType.ToString(), sqlParameters).Tables[0]);


        }

        public MessageViewDomain Delete(int id)
        {
            ///throw new NotImplementedException();
            return Command(new _005_invRefPropertyName2Domain() { ID = id }, Inventory_Domain_Layer.Command.Delete);
        }

        public IEnumerable<_005_invRefPropertyName2Domain> Get()
        {
            return GetData(0);
        }

        public _005_invRefPropertyName2Domain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_005_invRefPropertyName2Domain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_005_invRefPropertyName2Domain> GetData(int id)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter { ParameterName = "ID", Value = id, Direction = ParameterDirection.Input });
            return _dbHelper.GetRecords("sp005invRefPropertyName2Select", pars).Tables[0].AsEnumerable().Select(drow => new _005_invRefPropertyName2Domain
            {
                ID = drow.Field<int>("ID"),
                Name = drow.Field<string>("Name"),
                FullName = drow.Field<string>("FullName"),
                Prop1ID_004 = drow.Field<int>("Prop1ID_004")
            });
        }
    }
}
