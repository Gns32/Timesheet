using System;
using System.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataFramework
{
    public class DatabaseContext : IDisposable
    {
        private SqlDataReader _reader;
        private SqlCommand _command;

        private SqlConnection _connection;
        private SqlTransaction _transaction;

        public DatabaseContext(string ConnectionStringName)
        {
            var connectionStringValue = GetConnectionString(ConnectionStringName);
           // Console.Write("Hello");
           // Console.Write(connectionStringValue);

            if (string.IsNullOrEmpty(connectionStringValue))
            {
                throw new Exception("Connection String '" + ConnectionStringName + "' not found");
            }

            this._connection = new SqlConnection(connectionStringValue);
           //  Console.WriteLine( "opening connection");
            this._connection.Open();
           //  Console.WriteLine( "connection successful");


            

        }

        private static string GetConnectionString(string connectionStringName)
        {
            if (string.IsNullOrEmpty(connectionStringName))
            {
                throw new ArgumentNullException(nameof(connectionStringName));
            }


            if (ConfigurationManager.ConnectionStrings.Count == 0)
            {
                return string.Empty;
            }

            var connectionString = ConfigurationManager.ConnectionStrings[connectionStringName];
            return connectionString == null ? string.Empty : connectionString.ConnectionString;
        }

        public List<T> ExecuteStoredProcedure<T>(string storedProcedureName, object[] parameters)
            where T : new()
        {
            this.ExecuteStoredProcedure(storedProcedureName, parameters);

            return this.GetResultSet<T>();
        }

        public void ExecuteStoredProcedure(string storedProcedureName, object[] parameters)
        {
            this.Close();

            this._command = this._connection.CreateCommand();
            this._command.Transaction = this._transaction;
            this._command.CommandText = storedProcedureName;
            this._command.CommandTimeout = 3600;
            this._command.CommandType = CommandType.StoredProcedure;
            //this._command.Parameters.Add("@Emp_id", parameters);
            foreach (var param in parameters)
            {
                this._command.Parameters.Add(param);
            }
            
            this._reader = this._command.ExecuteReader();
        }

        public List<T> GetResultSet<T>()
            where T : new()
        {
            if (this._reader == null)
            {
                return null;
            }

            var results = new List<T>();

            // For this type first map the columns to their ordinals, then we go through the properties on the object and where we have a matching property
            // with a setter that corresponds to the property then we can map properties to ordinals to load the data
            var ordinalMap = new Dictionary<string, int>();
            var columnName = string.Empty;
            for (var i = 0; i < this._reader.FieldCount; i++)
            {
                try
                {
                    columnName = this._reader.GetName(i);
                    ordinalMap.Add(columnName, i);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error adding column " + columnName + " on " + typeof(T).Name, ex);
                }
            }

            var allProperties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var propertyMap = allProperties.Where(property => ordinalMap.ContainsKey(property.Name) && property.CanWrite)
                .ToDictionary(property => property, property => ordinalMap[property.Name]);

            while (this._reader.Read())
            {
                var result = new T();
                foreach (var property in propertyMap)
                {
                    try
                    {
                        var value = this._reader.IsDBNull(property.Value) ? null : this._reader.GetValue(property.Value);
                        property.Key.SetValue(result, value);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error parsing " + property.Key.Name + " on " + typeof(T).Name, ex);
                    }
                }

                results.Add(result);
            }

            return results;
        }


        public void BeginTransaction()
        {
            if (this._connection == null)
            {
                throw new Exception("No connection to start transaction on");
            }

            if (this._transaction != null)
            {
                throw new Exception("Transaction already in progress");
            }

            this._transaction = this._connection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (this._connection == null)
            {
                throw new Exception("No connection to start transaction on");
            }

            if (this._transaction == null)
            {
                throw new Exception("No transaction in progress");
            }

            this._transaction.Commit();
            this._transaction = null;
        }

        public void RollbackTransaction()
        {
            if (this._connection == null)
            {
                throw new Exception("No connection to start transaction on");
            }

            if (this._transaction == null)
            {
                throw new Exception("No transaction in progress");
            }

            this._transaction.Rollback();
            this._transaction = null;
        }

        public bool NextResultSet()
        {
            return this._reader.NextResult();
        }

        public void Close(bool closeConnection = false)
        {
            if (this._transaction != null && closeConnection)
            {
                try
                {
                    this._transaction.Rollback();
                    this._transaction.Dispose();
                }
                catch
                {
                    // ignored
                }

                this._transaction = null;
            }

            this._reader?.Close();
            this._command?.Dispose();

            if (closeConnection)
            {
                if (this._connection != null)
                {
                    try
                    {
                        this._connection.Close();
                        this._connection.Dispose();
                    }
                    catch
                    {
                        // ignored
                    }
                }

                this._connection = null;
            }

            this._reader = null;
            this._command = null;
        }




        public void Dispose()
        {
            this.Close(true);
        }
    }
}
