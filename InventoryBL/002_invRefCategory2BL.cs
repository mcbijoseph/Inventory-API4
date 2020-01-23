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


    public interface I_002_invRefCategory2BL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {

    }


    public class _002_invRefCategory2BL : Common.BaseBL, I_002_invRefCategory2BL<_002_invRefCategory2Domain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_002_invRefCategory2Domain projectDomain, string commandType)
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

        public IEnumerable<_002_invRefCategory2Domain> Get()
        {
            throw new NotImplementedException();
        }

        public _002_invRefCategory2Domain Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_002_invRefCategory2Domain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }
    }
}
