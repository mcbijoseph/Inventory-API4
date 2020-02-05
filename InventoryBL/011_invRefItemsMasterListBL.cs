using System;
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
    public interface I_011_invRefItemsMasterListBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {

    }


    public class _011_invRefItemsMasterListBL : Common.BaseBL, I_011_invRefItemsMasterListBL<_011_invRefItemsMasterListDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_011_invRefItemsMasterListDomain projectDomain, Command commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {

                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@Code", Value = projectDomain.Code, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@Tag", Value = projectDomain.Tag, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@hasAttribute", Value = projectDomain.hasAttribute, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@ItemPropList", Value = JsonConvert.SerializeObject( projectDomain.Category3.Property2[0].ItemPropList) , Direction = ParameterDirection.Input }
            };

            return this.GetMessage(_dbHelper.Command("sp011invRefITemsMAsterListCommand", commandType.ToString(), sqlParameters).Tables[0]);


        }

        public MessageViewDomain Delete(int id)
        {
            ///throw new NotImplementedException();
            return Command(new _011_invRefItemsMasterListDomain() { ID = id }, Inventory_Domain_Layer.Command.Delete);
        }

        public IEnumerable<_011_invRefItemsMasterListDomain> Get()
        {
            return GetData(0);
        }

        public _011_invRefItemsMasterListDomain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_011_invRefItemsMasterListDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_011_invRefItemsMasterListDomain> GetData(int id)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter { ParameterName = "ID", Value = id, Direction = ParameterDirection.Input });
            /*return _dbHelper.GetRecords("sp011invRefITemsMAsterListSelect", pars).Tables[0].AsEnumerable().Select(drow => new _011_invRefItemsMasterListDomain
            {
                ID = drow.Field<int>("ID"),
                Code = drow.Field<string>("Code"),
                Tag = drow.Field<string>("Tag")
            });*/

            string tabledata = _dbHelper.GetRecords("sp011invRefITemsMAsterListSelect", pars).Tables[0].Rows[0][0].ToString();//, Newtonsoft.Json.Formatting.None);
            return JsonConvert.DeserializeObject<List<_011_invRefItemsMasterListDomain>>(tabledata);
        }
    }
}
