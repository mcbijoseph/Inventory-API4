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
    public interface I_024_invTransInfoDelMetAttrValueBL<TEntity> : Common.IBaseBL<TEntity> where TEntity : class
    {

    }

    public class _024_invTransInfoDelMetAttrValueBL : Common.BaseBL, I_024_invTransInfoDelMetAttrValueBL<_024_invTransInfoDelMetAttrValueDomain>
    {
        private IDBHelper _dbHelper = new DBHelper();

        public MessageViewDomain Command(_024_invTransInfoDelMetAttrValueDomain projectDomain, Command commandType)
        {

            var sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter { ParameterName = "@ID", Value = projectDomain.ID, Direction = ParameterDirection.Input  },
                new SqlParameter { ParameterName = "@TransMasterID_021", Value = projectDomain.TransMasterID_021, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@DeliveryAttrID_008", Value = projectDomain.DeliveryAttrID_008, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@AttributeValueID", Value = projectDomain.AttributeValueID, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@AttributeValue", Value = projectDomain.AttributeValue, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@isDestination", Value = projectDomain.isDestination, Direction = ParameterDirection.Input }
            };

            return this.GetMessage(_dbHelper.Command("sp024invTransInfoDelMetAttrValueCommand", commandType.ToString(), sqlParameters).Tables[0]);


        }

        public MessageViewDomain Delete(int id)
        {
            // throw new NotImplementedException();
            return Command(new _024_invTransInfoDelMetAttrValueDomain() { ID = id }, Inventory_API4.Models.Command.Delete);
        }

        public IEnumerable<_024_invTransInfoDelMetAttrValueDomain> Get()
        {
            return GetData(0);
        }

        public _024_invTransInfoDelMetAttrValueDomain Get(int id)
        {
            return GetData(id).FirstOrDefault();
        }

        public IEnumerable<_024_invTransInfoDelMetAttrValueDomain> Search(int offset, int limit, string orderBy)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Reuse the query
        /// </summary>
        /// <param name="id">0 Means ALL</param>
        /// <returns>List</returns>
        private IEnumerable<_024_invTransInfoDelMetAttrValueDomain> GetData(int id)
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
            string tabledata = _dbHelper.GetRecords("sp024invTransInfoDelMetAttrValueSelect", pars).Tables[0].Rows[0][0].ToString() ?? "{}";//, Newtonsoft.Json.Formatting.None);
            return JsonConvert.DeserializeObject<List<_024_invTransInfoDelMetAttrValueDomain>>(tabledata);

        }
    }
}
