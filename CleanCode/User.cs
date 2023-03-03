using System;
using System.Data.SqlClient;

namespace CleanCode
{
    /// <summary>
    /// CleanCode Fix 
    /// </summary>
    public class User
    {
        #region Private Members

        private string commandQuery;

        private DatabaseManger databaseManger;
        #endregion

        #region Public Members
        public string UserName { get; set; }

        public int UserAge { get; set; }
        #endregion

        #region User database Methods

        /// <summary>
        /// Insert new user to database
        /// </summary>
        /// <param name="newUser">The new user object to insert to database</param>
        /// <returns></returns>
        public bool SaveUserToDataBase(User newUser)
        {
            commandQuery = $"INSERT INTO Users (Name,Age) VALUES ('{newUser.UserName}',{newUser.UserAge})";

            using (databaseManger = new DatabaseManger(commandQuery))
                return databaseManger.InsertData();
        }

        /// <summary>
        /// Get all users form the database
        /// </summary>
        public void GetUsersList()
        {
            commandQuery = "SELECT * FROM Users";

            using (databaseManger = new DatabaseManger(commandQuery))
            using (SqlDataReader sqlDataReader = databaseManger.SelectData())
            {
                while (sqlDataReader.Read())
                    Console.WriteLine(sqlDataReader["Name"] + ", " + sqlDataReader["Age"]);
            }
        }
        #endregion

        #region User genral Methods

        public void DoSomething()
        {
            Console.WriteLine("Doing something...");
        }
        #endregion
    }
}