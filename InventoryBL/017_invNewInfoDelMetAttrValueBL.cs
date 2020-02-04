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
    public interface I_017_invNewInfoDelMetAttrValueBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {

    }


    public class _017_invNewInfoDelMetAttrValueBL : Common.BaseBL, I_017_invNewInfoDelMetAttrValueBL<_017_invNewInfoDelMetAttrValueDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_017_invNewInfoDelMetAttrValueDomain projectDomain, Command commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@DocEntryListID_007", Value = projectDomain.DocEntryListID_007, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@DelMethodAttrID_008", Value = projectDomain.DelMethodAttrID_008, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@AttributeValueID_008a", Value = projectDomain.AttributeValueID_008a, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@AttributeValue", Value = projectDomain.AttributeValue, Direction = ParameterDirection.Input }
                
            };

            return this.GetMessage(_dbHelper.Command("sp017invNewInfoDelMetAttrValueCommand", commandType.ToString(), sqlParameters).Tables[0]);


        }

        public MessageViewDomain Delete(int id)
        {
            //throw new NotImplementedException();
            return Command(new _017_invNewInfoDelMetAttrValueDomain() { ID = id }, Inventory_Domain_Layer.Command.Delete);
        }

        public IEnumerable<_017_invNewInfoDelMetAttrValueDomain> Get()
        {
            return GetData(0);
        }

        public _017_invNewInfoDelMetAttrValueDomain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_017_invNewInfoDelMetAttrValueDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<_017_invNewInfoDelMetAttrValueDomain> GetData(int id)
        {
            List<SqlParameter> pars = new List<SqlParameter>();
            pars.Add(new SqlParameter { ParameterName = "ID", Value = id, Direction = ParameterDirection.Input });
            /*return _dbHelper.GetRecords("sp016invDeliveryMethodEntryListSelect", pars).Tables[0].AsEnumerable().Select(drow => new _017_invNewInfoDelMetAttrValueDomain
            {
                ID = drow.Field<int>("ID"),
                DocEntryListID_007= drow.Field<int>("DocEntryListID_007"),
                DelMethodAttrID_008 = drow.Field<int>("DelMethodAttrID_008"),
                AttributeValue = drow.Field<string>("AttributeValue")
            });*/
            string tabledata = _dbHelper.GetRecords("sp017invNewInfoDelMetAttrValueSelect", pars).Tables[0].Rows[0][0].ToString();//, Newtonsoft.Json.Formatting.None);
            return JsonConvert.DeserializeObject<List<_017_invNewInfoDelMetAttrValueDomain>>(tabledata);
        }
    }
}
