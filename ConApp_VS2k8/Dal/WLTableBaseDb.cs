using System;
using System.Data;
using System.Data.SqlClient;
using ConApp_VS2k8.Dto;
using Lsi.Libs.LsiDbLayer;

namespace ConApp_VS2k8.Dal
{
    public class WLTableBaseDb : IDb<WLTableDto, WLTableCollection, WLTableFilter>
    {
        protected readonly MySql mySql;

        /// <summary>
        /// Initializes a new instance of the <see cref="WLTableBaseDb"/> class.
        /// </summary>
        /// <param name="mySql">My SQL.</param>
        protected WLTableBaseDb (MySql mySql)
        {
            this.mySql = mySql;
        }

        #region Internal tools
        /// <summary>
        /// Makes the coll by query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        private static WLTableCollection MakeCollByQuery(SqlQuery query)
        {
            WLTableCollection ret = new WLTableCollection();

            SqlDataReader dr = query.ExecuteReader();
            try
            {
                while (dr.Read())
                    ret.Add(MakeDtoByReader(dr));
            }
            finally
            {
                dr.Close();
            }

            return ret;
        }

        /// <summary>
        /// Makes the dto by reader.
        /// </summary>
        /// <param name="dr">The dataReader.</param>
        /// <returns></returns>
        protected static WLTableDto MakeDtoByReader(SqlDataReader dr)
        {
            WLTableDto dto = new WLTableDto(
                MyConvert.ToLong(dr, "Id"),
                MyConvert.ToString(dr, "Number"),
                MyConvert.ToLongN(dr, "WaiterWLEmployeeId"),
                MyConvert.ToLongN(dr, "ManagerWLEmployeeId"),
                MyConvert.ToLong(dr, "WLLocationId"),
                MyConvert.ToLong(dr, "WLDictServiceDeviceId"),
                MyConvert.ToLongN(dr, "BeachButlerWhoToPage"),
                MyConvert.ToLongN(dr, "TGLeftButtonWhoToPage"),
                MyConvert.ToLongN(dr, "TGMiddleButtonWhoToPage"),
                MyConvert.ToLongN(dr, "TGRightButtonWhoToPage"),
                MyConvert.ToString(dr, "SerialNo"),
                MyConvert.ToLongN(dr, "WLTableId"),
                MyConvert.ToLongN(dr, "ClientId"),
                MyConvert.ToInt(dr, "WLDictChangeStatusId"));
				
            dto.SetIsNew (false); 
            dto.OldValues.CopyProperties(dto);
            return dto;
        }

        #endregion internal tools
		


        #region Interface functions - READ COLLECTION
		
	
        /// <summary>
        /// Gets the collection by filter.
        /// </summary>
        /// <param name="filter">filtr do wyszukiwania; null zwraca wszystkie
        /// <returns>read collection</returns>
        public WLTableCollection ReadAll(WLTableFilter filter)
        {
            if (filter == null)
                filter = new WLTableFilter (); 
            return DoReadAll(filter, mySql);
        }

        /// <summary>
        /// Gets the collection by filter.
        /// </summary>
        /// <param name="filter">filtr do wyszukiwania; null zwraca wszystkie
        /// <param name="needAnotherConnection">set to <c>true</c> if need another connection to DB
        /// (other DataReader is opened).</param>
        /// <returns>read collection</returns>
        public WLTableCollection ReadAll(WLTableFilter filter, bool needAnotherConnection)
        {
            if (filter == null)
                filter = new WLTableFilter (); 
				
            MySql conn = needAnotherConnection ? mySql.DuplicateConnection() : mySql;
            return DoReadAll(filter, conn);
        }

        /// <summary>
        /// Odczyt kolekcji z SEL_ALL (na podstawie filtru)
        /// </summary>
        /// <param name="filter">filtr do wyszukiwania
        /// <param name="mySql">Sql object.</param>
        /// <returns>read collection</returns>
        private static WLTableCollection DoReadAll (WLTableFilter filter, MySql mySql)
        {
            SqlQuery query = new SqlQuery("PA_WLTable_SELALL", mySql);
            query.AddParam("@Id", SqlDbType.BigInt, 0, filter.Id, ParameterDirection.Input); 
            query.AddParam("@Id_RngLow", SqlDbType.BigInt, 0, filter.Id_RngLow, ParameterDirection.Input); 
            query.AddParam("@Id_RngHigh", SqlDbType.BigInt, 0, filter.Id_RngHigh, ParameterDirection.Input); 
            query.AddParam("@Number", SqlDbType.NVarChar, 50, filter.Number, ParameterDirection.Input); 
            query.AddParam("@Number_LikeComp", SqlDbType.NVarChar, 50, filter.Number_LikeComp, ParameterDirection.Input); 
            query.AddParam("@WaiterWLEmployeeId", SqlDbType.BigInt, 0, filter.WaiterWLEmployeeId, ParameterDirection.Input); 
            query.AddParam("@WaiterWLEmployeeId_RngLow", SqlDbType.BigInt, 0, filter.WaiterWLEmployeeId_RngLow, ParameterDirection.Input); 
            query.AddParam("@WaiterWLEmployeeId_RngHigh", SqlDbType.BigInt, 0, filter.WaiterWLEmployeeId_RngHigh, ParameterDirection.Input); 
            query.AddParam("@ManagerWLEmployeeId", SqlDbType.BigInt, 0, filter.ManagerWLEmployeeId, ParameterDirection.Input); 
            query.AddParam("@ManagerWLEmployeeId_RngLow", SqlDbType.BigInt, 0, filter.ManagerWLEmployeeId_RngLow, ParameterDirection.Input); 
            query.AddParam("@ManagerWLEmployeeId_RngHigh", SqlDbType.BigInt, 0, filter.ManagerWLEmployeeId_RngHigh, ParameterDirection.Input); 
            query.AddParam("@WLLocationId", SqlDbType.BigInt, 0, filter.WLLocationId, ParameterDirection.Input); 
            query.AddParam("@WLLocationId_RngLow", SqlDbType.BigInt, 0, filter.WLLocationId_RngLow, ParameterDirection.Input); 
            query.AddParam("@WLLocationId_RngHigh", SqlDbType.BigInt, 0, filter.WLLocationId_RngHigh, ParameterDirection.Input); 
            query.AddParam("@WLDictServiceDeviceId", SqlDbType.BigInt, 0, filter.WLDictServiceDeviceId, ParameterDirection.Input); 
            query.AddParam("@WLDictServiceDeviceId_RngLow", SqlDbType.BigInt, 0, filter.WLDictServiceDeviceId_RngLow, ParameterDirection.Input); 
            query.AddParam("@WLDictServiceDeviceId_RngHigh", SqlDbType.BigInt, 0, filter.WLDictServiceDeviceId_RngHigh, ParameterDirection.Input); 
            query.AddParam("@BeachButlerWhoToPage", SqlDbType.BigInt, 0, filter.BeachButlerWhoToPage, ParameterDirection.Input); 
            query.AddParam("@BeachButlerWhoToPage_RngLow", SqlDbType.BigInt, 0, filter.BeachButlerWhoToPage_RngLow, ParameterDirection.Input); 
            query.AddParam("@BeachButlerWhoToPage_RngHigh", SqlDbType.BigInt, 0, filter.BeachButlerWhoToPage_RngHigh, ParameterDirection.Input); 
            query.AddParam("@TGLeftButtonWhoToPage", SqlDbType.BigInt, 0, filter.TGLeftButtonWhoToPage, ParameterDirection.Input); 
            query.AddParam("@TGLeftButtonWhoToPage_RngLow", SqlDbType.BigInt, 0, filter.TGLeftButtonWhoToPage_RngLow, ParameterDirection.Input); 
            query.AddParam("@TGLeftButtonWhoToPage_RngHigh", SqlDbType.BigInt, 0, filter.TGLeftButtonWhoToPage_RngHigh, ParameterDirection.Input); 
            query.AddParam("@TGMiddleButtonWhoToPage", SqlDbType.BigInt, 0, filter.TGMiddleButtonWhoToPage, ParameterDirection.Input); 
            query.AddParam("@TGMiddleButtonWhoToPage_RngLow", SqlDbType.BigInt, 0, filter.TGMiddleButtonWhoToPage_RngLow, ParameterDirection.Input); 
            query.AddParam("@TGMiddleButtonWhoToPage_RngHigh", SqlDbType.BigInt, 0, filter.TGMiddleButtonWhoToPage_RngHigh, ParameterDirection.Input); 
            query.AddParam("@TGRightButtonWhoToPage", SqlDbType.BigInt, 0, filter.TGRightButtonWhoToPage, ParameterDirection.Input); 
            query.AddParam("@TGRightButtonWhoToPage_RngLow", SqlDbType.BigInt, 0, filter.TGRightButtonWhoToPage_RngLow, ParameterDirection.Input); 
            query.AddParam("@TGRightButtonWhoToPage_RngHigh", SqlDbType.BigInt, 0, filter.TGRightButtonWhoToPage_RngHigh, ParameterDirection.Input); 
            query.AddParam("@SerialNo", SqlDbType.NVarChar, 20, filter.SerialNo, ParameterDirection.Input); 
            query.AddParam("@SerialNo_LikeComp", SqlDbType.NVarChar, 20, filter.SerialNo_LikeComp, ParameterDirection.Input); 
            query.AddParam("@WLTableId", SqlDbType.BigInt, 0, filter.WLTableId, ParameterDirection.Input); 
            query.AddParam("@WLTableId_RngLow", SqlDbType.BigInt, 0, filter.WLTableId_RngLow, ParameterDirection.Input); 
            query.AddParam("@WLTableId_RngHigh", SqlDbType.BigInt, 0, filter.WLTableId_RngHigh, ParameterDirection.Input); 
            query.AddParam("@ClientId", SqlDbType.BigInt, 0, filter.ClientId, ParameterDirection.Input); 
            query.AddParam("@ClientId_RngLow", SqlDbType.BigInt, 0, filter.ClientId_RngLow, ParameterDirection.Input); 
            query.AddParam("@ClientId_RngHigh", SqlDbType.BigInt, 0, filter.ClientId_RngHigh, ParameterDirection.Input); 
            query.AddParam("@WLDictChangeStatusId", SqlDbType.Int, 4, filter.WLDictChangeStatusId, ParameterDirection.Input); 
            query.AddParam("@WLDictChangeStatusId_RngLow", SqlDbType.Int, 4, filter.WLDictChangeStatusId_RngLow, ParameterDirection.Input); 
            query.AddParam("@WLDictChangeStatusId_RngHigh", SqlDbType.Int, 4, filter.WLDictChangeStatusId_RngHigh, ParameterDirection.Input); 

            query.AddParam("@Ord__1", SqlDbType.TinyInt, 1, (byte) filter.Ord1, ParameterDirection.Input); 
            query.AddParam("@Ord__2", SqlDbType.TinyInt, 1, (byte) filter.Ord2, ParameterDirection.Input); 
            query.AddParam("@Ord__3", SqlDbType.TinyInt, 1, (byte) filter.Ord3, ParameterDirection.Input); 
			
            return MakeCollByQuery(query); 
        }
		
        #endregion 
		
        #region Interface functions - READ SINGLE DTO
        
        /// <summary>
        /// Gets the dto.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>read WLTableDto</returns>
        /// <exception cref="NoSingleRowReturnedException">when 0 or more than one row is returned</exception>
        public WLTableDto Read (long id)
        {
            return DoRead (id, mySql);
        }
		
        /// <summary>
        /// Gets the dto.
        /// </summary>
        /// <param name="id">The id.</param>

        /// <param name="needAnotherConnection">set to <c>true</c> if need another connection to DB
        /// (other DataReader is opened).</param>
        /// <returns>read WLTableDto</returns>
        /// <exception cref="NoSingleRowReturnedException">when 0 or more than one row is returned</exception>
        public WLTableDto Read (long id, bool needAnotherConnection)
        {            
            MySql conn = needAnotherConnection ? mySql.DuplicateConnection() : mySql;
            return DoRead(id, conn);
        }

        /// <summary>
        /// Does the read.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="sql">The SQL.</param>
        /// <returns>read WLTableDto</returns>
        /// <exception cref="NoSingleRowReturnedException">when 0 or more than one row is returned</exception>
        private static WLTableDto DoRead (long id, MySql sql)
        {
            SqlQuery query = new SqlQuery("PA_WLTable_SEL", sql);
                
            query.AddParam("@Id", SqlDbType.BigInt, 0, id, ParameterDirection.Input); 

            WLTableDto dto;
            SqlDataReader dr = query.ExecuteReader();
            
            try
            {
                int rowsCalc;

                if (dr.Read())
                {
                    dto = MakeDtoByReader(dr);

                    rowsCalc = 1;
                    while (dr.Read())
                        rowsCalc++;
                }
                else
                    throw new NoSingleRowReturnedException(0, "PA_WLTable_SEL", query.ToString());

                if (rowsCalc != 1)
                    throw new NoSingleRowReturnedException(rowsCalc, "PA_WLTable_SEL", query.ToString());

            }
            finally
            {
                dr.Close();
            }

            return dto;
        }

        #endregion Interface functions - READ


        #region Interface functions - DELETE

        /// <summary>
        /// Deletes the dto.
        /// </summary>
        /// <param name="id">The id.</param>
        public void Delete (long id)
        {
            DoDelete(id, this.mySql); 
        }

        /// <summary>
        /// Does the delete.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="sql">The sql object.</param>
        private static void DoDelete(long id, MySql sql)
        {
            SqlQuery query = new SqlQuery("PA_WLTable_DEL", sql);

            query.AddParam("@Id", SqlDbType.BigInt, 0, id, ParameterDirection.Input); 

            query.ExecuteStoreProc();
        }

        #endregion Interface functions - DELETE
		
        #region Interface functions - WRITE
        /// <summary>
        /// Saves the specified dto.
        /// </summary>
        /// <param name="dto">The dto.</param>
        public void Save (WLTableDto dto)
        {
            DoSave(dto, mySql); 
        }

        /// <summary>
        /// Saves the specified dto.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <param name="mySql">My SQL.</param>
        private static void DoSave(WLTableDto dto, MySql mySql)
        {
            bool isNew = dto.IsNew; 
            string queryType = isNew ? "INS" : "UPD"; 
            
            SqlQuery query = new SqlQuery("PA_WLTable_" + queryType, mySql);

            SqlParameter prmId = query.AddParam("@Id", SqlDbType.BigInt, 0, dto.Id, 
                                                isNew ? ParameterDirection.Output : ParameterDirection.Input);
            query.AddParam("@Number", SqlDbType.NVarChar, 50, dto.Number, ParameterDirection.Input);
            query.AddParam("@WaiterWLEmployeeId", SqlDbType.BigInt, 0, dto.WaiterWLEmployeeId, ParameterDirection.Input);
            query.AddParam("@ManagerWLEmployeeId", SqlDbType.BigInt, 0, dto.ManagerWLEmployeeId, ParameterDirection.Input);
            query.AddParam("@WLLocationId", SqlDbType.BigInt, 0, dto.WLLocationId, ParameterDirection.Input);
            query.AddParam("@WLDictServiceDeviceId", SqlDbType.BigInt, 0, dto.WLDictServiceDeviceId, ParameterDirection.Input);
            query.AddParam("@BeachButlerWhoToPage", SqlDbType.BigInt, 0, dto.BeachButlerWhoToPage, ParameterDirection.Input);
            query.AddParam("@TGLeftButtonWhoToPage", SqlDbType.BigInt, 0, dto.TGLeftButtonWhoToPage, ParameterDirection.Input);
            query.AddParam("@TGMiddleButtonWhoToPage", SqlDbType.BigInt, 0, dto.TGMiddleButtonWhoToPage, ParameterDirection.Input);
            query.AddParam("@TGRightButtonWhoToPage", SqlDbType.BigInt, 0, dto.TGRightButtonWhoToPage, ParameterDirection.Input);
            query.AddParam("@SerialNo", SqlDbType.NVarChar, 20, dto.SerialNo, ParameterDirection.Input);
            query.AddParam("@WLTableId", SqlDbType.BigInt, 0, dto.WLTableId, ParameterDirection.Input);
            query.AddParam("@ClientId", SqlDbType.BigInt, 0, dto.ClientId, ParameterDirection.Input);
            query.AddParam("@WLDictChangeStatusId", SqlDbType.Int, 4, dto.WLDictChangeStatusId, ParameterDirection.Input);

            query.ExecuteStoreProc();
            dto.Id = MyConvert.ToLong(prmId.Value);


            if (dto.IsNew)
                dto.SetIsNew(false);
        }

        #endregion Interface functions - WRITE
    }
}