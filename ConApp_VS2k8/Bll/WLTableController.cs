using System;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using System.Transactions;
using ConApp_VS2k8.Dal;
using ConApp_VS2k8.Dto;
using Lsi.Libs.LsiDbLayer;
using IsolationLevel=System.Data.IsolationLevel;

namespace ConApp_VS2k8.Bll
{
    /// <summary>
    /// COM-visible wrapper of generic CRUD controller for WLTable table
    /// for non-transactional actions (data read) 
    /// </summary>
    [Transaction(TransactionOption.Supported, Isolation = TransactionIsolationLevel.ReadUncommitted)]
    [ComVisible(true)]
    public sealed class WLTableControllerRO
    {
        #region GenericController
        /// <summary>
        /// Retrieves all items from the underlying table.
        /// </summary>
        /// <returns></returns>
        public WLTableCollection GetAll()
        {
            try
            {
                return new WLTableDb(ConnectionFactory.MainMySql).ReadAll(null);
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
        public WLTableCollection GetFiltered(WLTableFilter filter)
        {
            try
            {
                return new WLTableDb(ConnectionFactory.MainMySql).ReadAll(filter);
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
        public WLTableDto GetOne(long id)
        {
            try
            {
                return new WLTableDb(ConnectionFactory.MainMySql).Read(id);
            }
            catch (StoreProcException ex)
            {
                throw BusinessExceptionFactory.CreateNew(ex);
            }
        }
        #endregion
    }

    /// <summary>
    /// COM-visible wrapper of generic CRUD controller for WLTable table
    /// for transactional actions (data modification)
    /// </summary>
    [Transaction(TransactionOption.Required, Isolation = TransactionIsolationLevel.ReadCommitted)]
    [ComVisible(true)]
    public sealed class WLTableController
    {
        #region GenericController

        /// <summary>
        /// Saves the specified dto.
        /// </summary>
        /// <param name="dto">The dto.</param>
        [AutoComplete]
        public long Save(WLTableDto dto)
        {
            return DoSave(dto);
        }

        internal long DoSave(WLTableDto dto)
        {
            try
            {
                new WLTableDb(ConnectionFactory.MainMySql).Save(dto);
                return dto.Id;
            }
            catch (StoreProcException ex)
            {
                throw BusinessExceptionFactory.CreateNew(ex);
            }
        }

        /// <summary>
        /// Deletes the specified item by its id.
        /// </summary>
        /// <param name="id">The id.</param>
        public void Delete(long id)
        {
            DoDelete(id);
        }

        internal void DoDelete(long id)
        {
            try
            {
                new WLTableDb(ConnectionFactory.MainMySql).Delete(id);
            }
            catch (StoreProcException ex)
            {
                throw BusinessExceptionFactory.CreateNew(ex);
            }
        }

        
        #endregion


        public void DoubleSave(WLTableDto dto1, WLTableDto dto2)
        {
            //TransactionOptions options = new TransactionOptions();
            //options.IsolationLevel = (System.Transactions.IsolationLevel) IsolationLevel.ReadCommitted;
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                DoSave(dto1);
                //throw new Exception("Error");
                DoSave(dto2);
                scope.Complete();
            }
        }
    }
}