using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_Domain_Layer;
using System.Data;
using Inventory.DAL;

namespace InventoryBL.Common
{
    public interface IBaseBL<TEntity> where TEntity : class
    {

        IEnumerable<TEntity> Get();
        TEntity Get(int id);
        IEnumerable<TEntity> Search(int offset, int limit, string orderBy);
        MessageViewDomain Command(TEntity entity, Command commandType);
        MessageViewDomain Delete(int id);
    }
    public class BaseBL
    {

        protected MessageViewDomain  GetMessage(DataTable dataTable)
        {
            return dataTable.AsEnumerable()
                .Select(dataRow => new MessageViewDomain 
                {
                    DataID = dataRow.Field<int>("DataID"),
                    Message = dataRow.Field<string>("Message"),
                    RetVal = dataRow.Field<int>("RetVal")
                }).FirstOrDefault();
        }


    }
}
