using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Lsi.Libs.LsiDbLayer;

namespace ConApp_VS2k8
{
    public class ResponsesDAL
    {

        public static DataTable GetResponseRawDataTF(long top)
        {
            SqlQuery query = new SqlQuery("PV_LRSWEBGetResponseRawData_TF", ConnectionFactory.CreateMySql("SRV"));
            SqlParameter prm_ret_value = query.AddParam("@RETURN_VALUE", SqlDbType.Int, 4, DBNull.Value, ParameterDirection.ReturnValue);

            query.AddParam("@Top", SqlDbType.BigInt, 0, 19, top, ParameterDirection.Input);
            
            DataTable ret_data_table = query.ExecuteDataTable();
            int? func_ret = MyConvert.ToIntN(prm_ret_value.Value);
            if (func_ret != null && func_ret != 0)
                throw new SpNonZeroReturnException(func_ret.Value, "PV_LRSWEBGetResponseRawData_TF");

            return ret_data_table;
        }

    }
}
