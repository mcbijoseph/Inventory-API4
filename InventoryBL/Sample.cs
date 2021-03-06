﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Inventory.DAL;
using Inventory_Domain_Layer;

namespace FormContBL
{
    public interface IProjectBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {

    }

    public class ProjectBL : BaseBL, IProjectBL<ProjectDomainModel>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomainModel Command(ProjectDomainModel projectDomain, string commandType)
        {
            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@ProjectName", Value = projectDomain.ProjectName, Direction = ParameterDirection.Input }
            };

            return this.GetMessage(_dbHelper.Command("spProjectCommand", commandType, sqlParameters).Tables[0]);

        }

        public MessageViewDomainModel Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProjectDomainModel> Get()
        {
            throw new NotImplementedException();
        }

        public ProjectDomainModel Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProjectDomainModel> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }
    }
}
