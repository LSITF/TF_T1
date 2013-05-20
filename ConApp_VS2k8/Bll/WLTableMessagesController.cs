using System.EnterpriseServices;
using System.Runtime.InteropServices;
using ConApp_VS2k8.Dal;
using ConApp_VS2k8.Dto;
using Lsi.Libs.LsiDbLayer;

namespace ConApp_VS2k8.Bll
{
    /// <summary>
    /// COM-visible wrapper of generic CRUD controller for WLTableMessages table
    /// for non-transactional actions (data read) 
    /// </summary>
    [Transaction(TransactionOption.Supported, Isolation = TransactionIsolationLevel.ReadUncommitted)]
    [ComVisible(true)]
    public sealed class WLTableMessagesControllerRO
    {
        #region GenericController
        /// <summary>
        /// Retrieves all items from the underlying table.
        /// </summary>
        /// <returns></returns>
        public WLTableMessagesCollection GetAll()
        {
            try
            {
                return new WLTableMessagesDb(ConnectionFactory.MainMySql).ReadAll(null);
            }
            catch (StoreProcException ex)
            {
                throw BusinessExceptionFactory.CreateNew(ex);
            }
        }

        /// <summary>
        /// Gets the filtered collection from the underlying table.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public WLTableMessagesCollection GetFiltered(WLTableMessagesFilter filter)
        {
            try
            {
                return new WLTableMessagesDb(ConnectionFactory.MainMySql).ReadAll(filter);
            }
            catch (StoreProcException ex)
            {
                throw BusinessExceptionFactory.CreateNew(ex);
            }
        }

        /// <summary>
        /// Retrieves a single item by its id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public WLTableMessagesDto GetOne(long id)
        {
            try
            {
                return new WLTableMessagesDb(ConnectionFactory.MainMySql).Read(id);
            }
            catch (StoreProcException ex)
            {
                throw BusinessExceptionFactory.CreateNew(ex);
            }
        }

        #endregion

        
    }

    /// <summary>
    /// COM-visible wrapper of generic CRUD controller for WLTableMessages table
    /// for transactional actions (data modification)
    /// </summary>
    [Transaction(TransactionOption.Required, Isolation = TransactionIsolationLevel.ReadCommitted)]
    [ComVisible(true)]
    public sealed class WLTableMessagesController 
    {
        #region GenericController

        /// <summary>
        /// Saves the specified dto.
        /// </summary>
        /// <param name="dto">The dto.</param>
        [AutoComplete]
        public long Save(WLTableMessagesDto dto)
        {
            return DoSave(dto);
        }

        internal long DoSave(WLTableMessagesDto dto)
        {
            try
            {
                new WLTableMessagesDb(ConnectionFactory.MainMySql).Save(dto);
            }
            catch (StoreProcException ex)
            {
                throw BusinessExceptionFactory.CreateNew(ex);
            }
            return dto.WLTableId;
        }

        /// <summary>
        /// Deletes the specified item by its id.
        /// </summary>
        /// <param name="id">The id.</param>
        [AutoComplete]
        public void Delete(long id)
        {
            DoDelete(id);
        }

        internal void DoDelete(long id)
        {
            try
            {
                new WLTableMessagesDb(ConnectionFactory.MainMySql).Delete(id);
            }
            catch (StoreProcException ex)
            {
                throw BusinessExceptionFactory.CreateNew(ex);
            }
        }
        #endregion
    }
}