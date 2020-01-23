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

    public interface I_004_invRefPropertyName1<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {

    }


    public class _004_invRefPropertyName1 : Common.BaseBL, I_004_invRefPropertyName1<_004_invRefPropertyName1Domain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_004_invRefPropertyName1Domain projectDomain, string commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                /***
                //TOD:
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@ProjectName", Value = projectDomain.ProjectName, Direction = ParameterDirection.Input }
                */
            };

            return this.GetMessage(_dbHelper.Command("spProjectCommand", commandType, sqlParameters).Tables[0]);


        }

        public MessageViewDomain Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_004_invRefPropertyName1Domain> Get()
        {
            throw new NotImplementedException();
        }

        public _004_invRefPropertyName1Domain Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_004_invRefPropertyName1Domain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }
    }
}
