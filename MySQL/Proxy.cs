namespace MySQL
{
    internal class Proxy
    {
        #region CheckConnectionAsync
        internal static async Task<bool> CheckConnectionAsync()
        {
            return await Task.Run(() => Mysql.CheckConnection());
        }
        #endregion

        #region ClearConnectionAsync
        internal static async Task<bool> ClearConnectionAsync()
        {
            return await Task.Run(() => Mysql.ClearConnection());
        }
        #endregion



        #region InitAsync
        internal static async Task<bool> InitAsync(string server, string database, string userid, string password)
        {
            return await Task.Run(() => Mysql.Init(server, database, userid, password));
        }
        #endregion

        #region OpenAsync
        internal static async Task<bool> OpenAsync()
        {
            return await Task.Run(() => Mysql.Open());
        }
        #endregion

        #region CloseAsync
        internal static async Task<bool> CloseAsync()
        {
            return await Task.Run(() => Mysql.Close());
        }
        #endregion

        #region InsertAsync
        internal static async Task<bool> InsertAsync(string query)
        {
            return await Task.Run(() => Mysql.Insert(query));
        }
        #endregion
    }
}
