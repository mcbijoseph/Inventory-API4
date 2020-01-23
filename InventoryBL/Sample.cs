using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Inventory.DAL;
using Inventory_Domain_Layer;

namespace FormContBL
{
    public interface IMDSControlNumber
    {
        List<MDSControlNumbersDomain> Get();
    }

    public class MDSControlNumber : IMDSControlNumber
    {
        public MDSControlNumber()
        {

        }

        public List<MDSControlNumbersDomain> Get()
        {
            SQL sql = new SQL("");
            System.Data.DataSet ds = sql.Execute("spGetALLMDSFormsNo", null) as System.Data.DataSet;


            return ds.Tables[0].AsEnumerable().Select(drow => new MDSControlNumbersDomain
            {
                ID = drow.Field<int>("ID"),
                FormNo = drow.Field<string>("FormNo"),
                isDeleted = drow.Field<bool>("isDeleted")
            }).ToList();
            //throw new NotImplementedException();
        }
    }
}
