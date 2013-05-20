using System;
using System.Data;
using System.Data.SqlClient;
using ConApp_VS2k8.Dto;
using Lsi.Libs.LsiDbLayer;

namespace ConApp_VS2k8.Dal
{
    public class WLTableMessagesBaseDb : IDb<WLTableMessagesDto, WLTableMessagesCollection, WLTableMessagesFilter>
    {
        private readonly MySql mySql;

        /// <summary>
        /// Initializes a new instance of the <see cref="WLTableMessagesBaseDb"/> class.
        /// </summary>
        /// <param name="mySql">My SQL.</param>
        protected WLTableMessagesBaseDb (MySql mySql)
        {
            this.mySql = mySql;
        }

        #region Internal tools
        /// <summary>
        /// Makes the coll by query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns></returns>
        private static WLTableMessagesCollection MakeCollByQuery(SqlQuery query)
        {
            WLTableMessagesCollection ret = new WLTableMessagesCollection();

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
        protected static WLTableMessagesDto MakeDtoByReader(SqlDataReader dr)
        {
            WLTableMessagesDto dto = new WLTableMessagesDto(
                MyConvert.ToLong(dr, "WLTableId"),
                MyConvert.ToString(dr, "BeachButlerMessage"),
                MyConvert.ToString(dr, "TableGenieLeftButtonMessage"),
                MyConvert.ToString(dr, "TableGenieMiddleButtonMessage"),
                MyConvert.ToString(dr, "TableGenieRightButtonMessage"),
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
        public WLTableMessagesCollection ReadAll(WLTableMessagesFilter filter)
        {
            if (filter == null)
                filter = new WLTableMessagesFilter (); 
            return DoReadAll(filter, mySql);
        }

        /// <summary>
        /// Gets the collection by filter.
        /// </summary>
        /// <param name="filter">filtr do wyszukiwania; null zwraca wszystkie
        /// <param name="needAnotherConnection">set to <c>true</c> if need another connection to DB
        /// (other DataReader is opened).</param>
        /// <returns>read collection</returns>
        public WLTableMessagesCollection ReadAll(WLTableMessagesFilter filter, bool needAnotherConnection)
        {
            if (filter == null)
                filter = new WLTableMessagesFilter (); 
				
            MySql conn = needAnotherConnection ? mySql.DuplicateConnection() : mySql;
            return DoReadAll(filter, conn);
        }

        /// <summary>
        /// Odczyt kolekcji z SEL_ALL (na podstawie filtru)
        /// </summary>
        /// <param name="filter">filtr do wyszukiwania
        /// <param name="mySql">Sql object.</param>
        /// <returns>read collection</returns>
        private static WLTableMessagesCollection DoReadAll (WLTableMessagesFilter filter, MySql mySql)
        {
            SqlQuery query = new SqlQuery("PA_WLTableMessages_SELALL", mySql);
            query.AddParam("@WLTableId", SqlDbType.BigInt, 0, filter.WLTableId, ParameterDirection.Input); 
            query.AddParam("@WLTableId_RngLow", SqlDbType.BigInt, 0, filter.WLTableId_RngLow, ParameterDirection.Input); 
            query.AddParam("@WLTableId_RngHigh", SqlDbType.BigInt, 0, filter.WLTableId_RngHigh, ParameterDirection.Input); 
            query.AddParam("@BeachButlerMessage", SqlDbType.NVarChar, 200, filter.BeachButlerMessage, ParameterDirection.Input); 
            query.AddParam("@BeachButlerMessage_LikeComp", SqlDbType.NVarChar, 200, filter.BeachButlerMessage_LikeComp, ParameterDirection.Input); 
            query.AddParam("@TableGenieLeftButtonMessage", SqlDbType.NVarChar, 200, filter.TableGenieLeftButtonMessage, ParameterDirection.Input); 
            query.AddParam("@TableGenieLeftButtonMessage_LikeComp", SqlDbType.NVarChar, 200, filter.TableGenieLeftButtonMessage_LikeComp, ParameterDirection.Input); 
            query.AddParam("@TableGenieMiddleButtonMessage", SqlDbType.NVarChar, 200, filter.TableGenieMiddleButtonMessage, ParameterDirection.Input); 
            query.AddParam("@TableGenieMiddleButtonMessage_LikeComp", SqlDbType.NVarChar, 200, filter.TableGenieMiddleButtonMessage_LikeComp, ParameterDirection.Input); 
            query.AddParam("@TableGenieRightButtonMessage", SqlDbType.NVarChar, 200, filter.TableGenieRightButtonMessage, ParameterDirection.Input); 
            query.AddParam("@TableGenieRightButtonMessage_LikeComp", SqlDbType.NVarChar, 200, filter.TableGenieRightButtonMessage_LikeComp, ParameterDirection.Input); 
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
        /// <returns>read WLTableMessagesDto</returns>
        /// <exception cref="NoSingleRowReturnedException">when 0 or more than one row is returned</exception>
        public WLTableMessagesDto Read (long id)
        {
            return DoRead (id, mySql);
        }
		
        /// <summary>
        /// Gets the dto.
        /// </summary>
        /// <param name="id">The id.</param>

        /// <param name="needAnotherConnection">set to <c>true</c> if need another connection to DB
        /// (other DataReader is opened).</param>
        /// <returns>read WLTableMessagesDto</returns>
        /// <exception cref="NoSingleRowReturnedException">when 0 or more than one row is returned</exception>
        public WLTableMessagesDto Read (long id, bool needAnotherConnection)
        {            
            MySql conn = needAnotherConnection ? mySql.DuplicateConnection() : mySql;
            return DoRead(id, conn);
        }

        /// <summary>
        /// Does the read.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="sql">The SQL.</param>
        /// <returns>read WLTableMessagesDto</returns>
        /// <exception cref="NoSingleRowReturnedException">when 0 or more than one row is returned</exception>
        private static WLTableMessagesDto DoRead (long id, MySql sql)
        {
            SqlQuery query = new SqlQuery("PA_WLTableMessages_SEL", sql);
                
            query.AddParam("@WLTableId", SqlDbType.BigInt, 0, id, ParameterDirection.Input); 

            WLTableMessagesDto dto;
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
                    throw new NoSingleRowReturnedException(0, "PA_WLTableMessages_SEL", query.ToString());

                if (rowsCalc != 1)
                    throw new NoSingleRowReturnedException(rowsCalc, "PA_WLTableMessages_SEL", query.ToString());

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
            SqlQuery query = new SqlQuery("PA_WLTableMessages_DEL", sql);

            query.AddParam("@WLTableId", SqlDbType.BigInt, 0, id, ParameterDirection.Input); 

            query.ExecuteStoreProc();
        }

        #endregion Interface functions - DELETE
		
        #region Interface functions - WRITE
        /// <summary>
        /// Saves the specified dto.
        /// </summary>
        /// <param name="dto">The dto.</param>
        public void Save (WLTableMessagesDto dto)
        {
            DoSave(dto, mySql); 
        }

        /// <summary>
        /// Saves the specified dto.
        /// </summary>
        /// <param name="dto">The dto.</param>
        /// <param name="mySql">My SQL.</param>
        private static void DoSave(WLTableMessagesDto dto, MySql mySql)
        {
            bool isNew = dto.IsNew; 
            string queryType = isNew ? "INS" : "UPD"; 
            
            SqlQuery query = new SqlQuery("PA_WLTableMessages_" + queryType, mySql);

            query.AddParam("@WLTableId", SqlDbType.BigInt, 0, dto.WLTableId, ParameterDirection.Input);
            query.AddParam("@BeachButlerMessage", SqlDbType.NVarChar, 200, dto.BeachButlerMessage, ParameterDirection.Input);
            query.AddParam("@TableGenieLeftButtonMessage", SqlDbType.NVarChar, 200, dto.TableGenieLeftButtonMessage, ParameterDirection.Input);
            query.AddParam("@TableGenieMiddleButtonMessage", SqlDbType.NVarChar, 200, dto.TableGenieMiddleButtonMessage, ParameterDirection.Input);
            query.AddParam("@TableGenieRightButtonMessage", SqlDbType.NVarChar, 200, dto.TableGenieRightButtonMessage, ParameterDirection.Input);
            query.AddParam("@WLDictChangeStatusId", SqlDbType.Int, 4, dto.WLDictChangeStatusId, ParameterDirection.Input);

            query.ExecuteStoreProc();


            if (dto.IsNew)
                dto.SetIsNew(false);
        }

        #endregion Interface functions - WRITE
    }
}