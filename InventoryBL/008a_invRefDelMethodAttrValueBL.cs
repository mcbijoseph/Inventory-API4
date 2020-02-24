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
    public interface I_008a_invRefDelMethodAttrValueBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {

    }

    public class _008a_invRefDelMethodAttrValueBL : Common.BaseBL, I_008a_invRefDelMethodAttrValueBL<_008a_invRefDelMethodAttrValueDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_008a_invRefDelMethodAttrValueDomain projectDomain, Command commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@DelMethodAttrID_008", Value = projectDomain.DelMethodAttrID_008, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@AttrValueName", Value = projectDomain.AttrValueName, Direction = ParameterDirection.Input }

            };

            return this.GetMessage(_dbHelper.Command("sp008ainvRefDelMethodAttrValueCommand", commandType.ToString(), sqlParameters).Tables[0]);


        }

        public MessageViewDomain Delete(int id)
        {
            //throw new NotImplementedException();
            return Command(new _008a_invRefDelMethodAttrValueDomain() { ID = id }, Inventory_Domain_Layer.Command.Delete);
        }

        public IEnumerable<_008a_invRefDelMethodAttrValueDomain> Get()
        {
            return GetData(0);
        }

        public _008a_invRefDelMethodAttrValueDomain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_008a_invRefDelMethodAttrValueDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_008a_invRefDelMethodAttrValueDomain> GetData(int id)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter { ParameterName = "ID", Value = id, Direction = ParameterDirection.Input });
            /*return _dbHelper.GetRecords("sp024invRefCourierListSelect", pars).Tables[0].AsEnumerable().Select(drow => new _008a_invRefDelMethodAttrValueDomain
            {
                ID = drow.Field<int>("ID"),
                CourierName = drow.Field<string>("CourierName")
            });*/
            string tabledata = _dbHelper.GetRecords("sp008ainvRefDelMethodAttrValueSelect", pars).Tables[0].Rows[0][0].ToString();//, Newtonsoft.Json.Formatting.None);
            return JsonConvert.DeserializeObject<List<_008a_invRefDelMethodAttrValueDomain>>(tabledata);
        }
    }
}
