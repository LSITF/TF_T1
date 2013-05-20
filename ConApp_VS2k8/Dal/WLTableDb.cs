
using System;
using System.Data;
using System.Data.SqlClient;
using ConApp_VS2k8.Dto;
using Lsi.Libs.LsiDbLayer;

namespace ConApp_VS2k8.Dal
{
    public class WLTableDb : WLTableBaseDb
    {
        #region constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="WLTableDb"/> class.
        /// </summary>
        /// <param name="mySql">My SQL.</param>
        public WLTableDb (MySql mySql)
            : base (mySql)
        {
        }

        #endregion 

        #region User Code

        /// <summary>
        /// Returns collection of Exec the PV_WLWEBGetAvailableTables
        /// 
        /// </summary>
        /// <param name="wLSectionList">The wLSectionList.</param>
        /// <param name="wLLocationId">The wLLocationId.</param>
        /// <returns>Collection with resultSet</returns>
        public WLTableCollection CollExecWLWEBGetAvailableTables(string wLSectionList, long? wLLocationId)
        {
            SqlQuery query = new SqlQuery("PV_WLWEBGetAvailableTables", mySql);
            SqlParameter prm_ret_value = query.AddParam("@RETURN_VALUE", SqlDbType.Int, 4, DBNull.Value, ParameterDirection.ReturnValue);

            query.AddParam("@WLSectionList", SqlDbType.Text, 2147483647, wLSectionList, ParameterDirection.Input);
            query.AddParam("@WLLocationId", SqlDbType.BigInt, 0, 19, wLLocationId, ParameterDirection.Input);


            WLTableCollection ret_coll = new WLTableCollection();
            SqlDataReader dr = query.ExecuteReader();
            try
            {
                while (dr.Read())
                    ret_coll.Add(MakeDtoByReader(dr));
            }
            finally
            {
                dr.Close();
            }

            int? func_ret = MyConvert.ToIntN(prm_ret_value.Value);
            if (func_ret != null && func_ret != 0)
                throw new SpNonZeroReturnException(func_ret.Value, "PV_WLWEBGetAvailableTables");



            return ret_coll;
        }

        /// <summary>
        /// Returns collection of Exec the PV_WLWEBGetActiveTablesForTableInstruction
        /// 
        /// </summary>
        /// <param name="wLLocationID">The wLLocationID.</param>
        /// <returns>Collection with resultSet</returns>
        public WLTableCollection CollExecWLWEBGetActiveTablesForTableInstruction(long? wLLocationID)
        {
            SqlQuery query = new SqlQuery("PV_WLWEBGetActiveTablesForTableInstruction", mySql);
            SqlParameter prm_ret_value = query.AddParam("@RETURN_VALUE", SqlDbType.Int, 4, DBNull.Value, ParameterDirection.ReturnValue);

            query.AddParam("@WLLocationID", SqlDbType.BigInt, 0, 19, wLLocationID, ParameterDirection.Input);


            WLTableCollection ret_coll = new WLTableCollection();
            SqlDataReader dr = query.ExecuteReader();
            try
            {
                while (dr.Read())
                    ret_coll.Add(MakeDtoByReader(dr));
            }
            finally
            {
                dr.Close();
            }

            int? func_ret = MyConvert.ToIntN(prm_ret_value.Value);
            if (func_ret != null && func_ret != 0)
                throw new SpNonZeroReturnException(func_ret.Value, "PV_WLWEBGetActiveTablesForTableInstruction");



            return ret_coll;
        }

        /// <summary>
        /// Returns collection of Exec the PV_WLWEBGetActiveTablesForLocation
        /// 
        /// </summary>
        /// <param name="wLLocationID">The wLLocationID.</param>
        /// <returns>Collection with resultSet</returns>
        public WLTableCollection CollExecWLWEBGetActiveTablesForLocation(long? wLLocationID)
        {
            SqlQuery query = new SqlQuery("PV_WLWEBGetActiveTablesForLocation", mySql);
            SqlParameter prm_ret_value = query.AddParam("@RETURN_VALUE", SqlDbType.Int, 4, DBNull.Value, ParameterDirection.ReturnValue);

            query.AddParam("@WLLocationID", SqlDbType.BigInt, 0, 19, wLLocationID, ParameterDirection.Input);


            WLTableCollection ret_coll = new WLTableCollection();
            SqlDataReader dr = query.ExecuteReader();
            try
            {
                while (dr.Read())
                    ret_coll.Add(MakeDtoByReader(dr));
            }
            finally
            {
                dr.Close();
            }

            int? func_ret = MyConvert.ToIntN(prm_ret_value.Value);
            if (func_ret != null && func_ret != 0)
                throw new SpNonZeroReturnException(func_ret.Value, "PV_WLWEBGetActiveTablesForLocation");



            return ret_coll;
        }

        /// <summary>
        /// Returns collection of Exec the PV_WLWEBGetActiveTablesForEmployee
        /// 
        /// </summary>
        /// <param name="wLEmployeeId">The wLEmployeeId.</param>
        /// <returns>Collection with resultSet</returns>
        public WLTableCollection CollExecWLWEBGetActiveTablesForEmployee(long? wLEmployeeId)
        {
            SqlQuery query = new SqlQuery("PV_WLWEBGetActiveTablesForEmployee", mySql);
            SqlParameter prm_ret_value = query.AddParam("@RETURN_VALUE", SqlDbType.Int, 4, DBNull.Value, ParameterDirection.ReturnValue);

            query.AddParam("@WLEmployeeId", SqlDbType.BigInt, 0, 19, wLEmployeeId, ParameterDirection.Input);


            WLTableCollection ret_coll = new WLTableCollection();
            SqlDataReader dr = query.ExecuteReader();
            try
            {
                while (dr.Read())
                    ret_coll.Add(MakeDtoByReader(dr));
            }
            finally
            {
                dr.Close();
            }

            int? func_ret = MyConvert.ToIntN(prm_ret_value.Value);
            if (func_ret != null && func_ret != 0)
                throw new SpNonZeroReturnException(func_ret.Value, "PV_WLWEBGetActiveTablesForEmployee");



            return ret_coll;
        }

        /// <summary>
        /// Returns collection of Exec the PV_WLWEBGetActiveSectionTables
        /// 
        /// </summary>
        /// <param name="wLSectionId">The wLSectionId.</param>
        /// <returns>Collection with resultSet</returns>
        public WLTableCollection CollExecWLWEBGetActiveSectionTables(long? wLSectionId)
        {
            SqlQuery query = new SqlQuery("PV_WLWEBGetActiveSectionTables", mySql);
            SqlParameter prm_ret_value = query.AddParam("@RETURN_VALUE", SqlDbType.Int, 4, DBNull.Value, ParameterDirection.ReturnValue);

            query.AddParam("@WLSectionId", SqlDbType.BigInt, 0, 19, wLSectionId, ParameterDirection.Input);


            WLTableCollection ret_coll = new WLTableCollection();
            SqlDataReader dr = query.ExecuteReader();
            try
            {
                while (dr.Read())
                    ret_coll.Add(MakeDtoByReader(dr));
            }
            finally
            {
                dr.Close();
            }

            int? func_ret = MyConvert.ToIntN(prm_ret_value.Value);
            if (func_ret != null && func_ret != 0)
                throw new SpNonZeroReturnException(func_ret.Value, "PV_WLWEBGetActiveSectionTables");



            return ret_coll;
        }



        #endregion 
    }
}