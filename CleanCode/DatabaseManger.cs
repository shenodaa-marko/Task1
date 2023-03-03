using System;
using System.Data.SqlClient;

namespace CleanCode
{
    /// <summary>
    /// Mange database connection and command
    /// </summary>
    internal class DatabaseManger : IDisposable
    {
        #region Private Members

        private const string databaseConnection = "Data Source=server;Initial Catalog=db;User ID=user;Password=password";

        private readonly SqlConnection sqlConnection;

        private readonly SqlCommand sqlCommand;
        #endregion

        #region Constractor And Dispser
        /// <summary>
        /// Database manger constractor 
        /// </summary>
        /// <param name="sqlQuery">SQL query as string</param>
        public DatabaseManger(string sqlQuery)
        {
            sqlConnection = new SqlConnection(databaseConnection);
            sqlCommand = new SqlCommand(sqlQuery, sqlConnection);
        }

        public void Dispose()
        {
            sqlCommand.Dispose();
            sqlConnection.Dispose();
        }

        ~DatabaseManger()
        {
            Dispose();
        }
        #endregion

        #region DataBase Commands Methods

        /// <summary>
        /// Insert new data to database based on SQL command
        /// </summary>
        /// <returns></returns>
        public bool InsertData()
        {
            sqlConnection.Open();
            try
            {
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while save data....\n" + ex.Message);
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        /// <summary>
        /// Get data from database based on SQL command
        /// </summary>
        /// <returns></returns>
        public SqlDataReader SelectData()
        {
            return sqlCommand.ExecuteReader();
        }
        #endregion
    }
}