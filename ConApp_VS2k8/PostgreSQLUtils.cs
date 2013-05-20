using System;
using System.Data;
using System.Data.Odbc;
using Lsi.Libs.LsiDbLayer;
using Lsi.Libs.LsiNLogger;

namespace ConApp_VS2k8
{
    public class PostgreSQLUtils
    {
        public static IDbConnection CreateOdbcConnection(string connectionString)
        {
            IDbConnection dbcon = new OdbcConnection(connectionString);
            return dbcon;
        }
    }

    public class PostgreDataController
    {
        private const string clientInsertTemplate = @"INSERT INTO CLIENTS (NAME, DESCRIPTION) VALUES (?, ?); SELECT cast(currval('clients_uid_seq') as int);";
        private const string locationInsertTemplate = @"INSERT INTO Locations(CLIENT, LOCATION, DESCRIPTION) VALUES (?, ?, ?); SELECT cast(currval('locations_uid_seq') as int);";
        private const string baseInsertTemplate = @"INSERT INTO BASES(SERIALNO, LOCATION) VALUES(?, ?);";
        private IDbTransaction transaction = null;
        private IDbConnection connection;
        private string _connectionString;

        public PostgreDataController()
        {
            
        }

        public PostgreDataController(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int? StartInsertClient(string name)
        {
            LsiLogger.Trace("Start Inserting client to srv postgre db");
            int? id = MyConvert.ToIntN(DoExecuteScalar(clientInsertTemplate, name, name));
            LsiLogger.Trace("End Inserting client to srv postgre db");
            return id;
        }

        public int? StartInsertLocation(int clientUid, int lrsRestaurantId, string name)
        {
            LsiLogger.Trace("Start Inserting location to srv postgre db");
            int? id = MyConvert.ToIntN(DoExecuteScalar(locationInsertTemplate, clientUid, lrsRestaurantId, name));
            LsiLogger.Trace("End Inserting location to srv postgre db");
            return id;
        }

        public void StartInsertBases(int serialNo, int locationUid)
        {
            LsiLogger.Trace("Start Inserting Bases to srv postgre db");
            DoExecuteScalar(baseInsertTemplate, serialNo, locationUid);
            LsiLogger.Trace("End Inserting Bases to srv postgre db");
        }

        private object DoExecuteScalar(string template, params object[] pars)
        {
            connection = PostgreSQLUtils.CreateOdbcConnection(_connectionString);
            if (connection == null)
            {
                throw new Exception("Can not connect with survey postgre");
            }
            IDbCommand cmd = connection.CreateCommand();
            cmd.Connection = connection;
            cmd.CommandText = template;
            if (pars != null && pars.Length > 0)
            {
                for (int i = 0; i < pars.Length; i++)
                {
                    var param = cmd.CreateParameter();
                    param.Value = pars[i];
                    cmd.Parameters.Add(param);
                }
            }

            connection.Open();
            transaction = connection.BeginTransaction();
            cmd.Transaction = transaction;
            object returnValue = cmd.ExecuteScalar();
            cmd.Dispose();
            return returnValue;
        }

        public void CommitTransaction()
        {
            transaction.Commit();
            connection.Close();
        }

        public void RollbackTransaction()
        {
            if (transaction != null)
            {
                transaction.Rollback();
            }
            if (connection != null)
            {
                connection.Close();
            }
        }
    }
}
