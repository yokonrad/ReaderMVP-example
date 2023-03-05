using MySql.Data.MySqlClient;
using System.Data;
using System.Runtime.CompilerServices;

namespace MySQL
{
    internal class Mysql
    {
        #region helper functions
        private static string? GetCallerName([CallerMemberName] string? caller = null)
        {
            return $"{typeof(Mysql).FullName}.{caller}";
        }
        #endregion

        #region variables
        private static MySqlConnection mySqlConnection = new();
        #endregion



        #region CheckConnection
        internal static bool CheckConnection()
        {
            return mySqlConnection.State == ConnectionState.Open;
        }
        #endregion

        #region ClearConnection
        internal static bool ClearConnection()
        {
            mySqlConnection.Dispose();

            return CheckConnection();
        }
        #endregion



        #region Init
        internal static bool Init(string server, string database, string userid, string password)
        {
            try
            {
                mySqlConnection = new MySqlConnection(new MySqlConnectionStringBuilder
                {
                    Server = server,
                    Database = database,
                    UserID = userid,
                    Password = password,
                }.ConnectionString);

                if (mySqlConnection.ConnectionString is not null)
                {
                    return true;
                }

                return false;
            }
            catch (Exception exception)
            {
                throw new Exception($"Error in {GetCallerName()}: {exception.Message}");
            }
        }
        #endregion

        #region Open
        internal static bool Open()
        {
            try
            {
                mySqlConnection.Open();

                if (mySqlConnection.State == ConnectionState.Open)
                {
                    return true;
                }

                return false;
            }
            catch (Exception exception)
            {
                throw new Exception($"Error in {GetCallerName()}: {exception.Message}");
            }
        }
        #endregion

        #region Close
        internal static bool Close()
        {
            try
            {
                mySqlConnection.Close();

                if (mySqlConnection.State == ConnectionState.Closed)
                {
                    return true;
                }

                return false;
            }
            catch (Exception exception)
            {
                throw new Exception($"Error in {GetCallerName()}: {exception.Message}");
            }
        }
        #endregion

        #region Insert
        internal static bool Insert(string query)
        {
            try
            {
                MySqlCommand mySqlCommand = new();

                if (mySqlConnection.State == ConnectionState.Open)
                {
                    mySqlCommand.Connection = mySqlConnection;
                    mySqlCommand.CommandText = query;
                }

                if (mySqlCommand.CommandText is not null && mySqlCommand.ExecuteNonQuery() > 0)
                {
                    return true;
                }

                return false;
            }
            catch (Exception exception)
            {
                throw new Exception($"Error in {GetCallerName()}: {exception.Message}");
            }
        }
        #endregion
    }
}