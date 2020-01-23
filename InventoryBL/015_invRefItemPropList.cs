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
    public interface I_015_invRefItemPropListBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {

    }


    public class _015_invRefItemPropListBL : Common.BaseBL, I_015_invRefItemPropListBL<_015_invRefItemPropListDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_015_invRefItemPropListDomain projectDomain, string commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@Cat3ID_003", Value = projectDomain.Cat3ID_003, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@Prop2ID_005", Value = projectDomain.Prop2ID_005, Direction = ParameterDirection.Input }

            };

            return this.GetMessage(_dbHelper.Command("spProjectCommand", commandType, sqlParameters).Tables[0]);


        }

        public MessageViewDomain Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_015_invRefItemPropListDomain> Get()
        {
            return _dbHelper.GetRecords("sp015RefImtePropListSelect").Tables[0].AsEnumerable().Select(drow => new _015_invRefItemPropListDomain
            {
                ID = drow.Field<int>("ID"),
                 Cat3ID_003 = drow.Field<int>("Cat3ID_003"),
                  Prop2ID_005 = drow.Field<int>("Prop2ID_005")
            }).ToList();
        }

        public _015_invRefItemPropListDomain Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_015_invRefItemPropListDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }
    }
}
