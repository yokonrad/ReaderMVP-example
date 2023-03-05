namespace MySQL
{
    public class Api
    {
        #region CheckConnection
        public static async Task<bool> CheckConnection()
        {
            return await Proxy.CheckConnectionAsync();
        }
        #endregion

        #region ClearConnection
        public static async Task<bool> ClearConnection()
        {
            return await Proxy.ClearConnectionAsync();
        }
        #endregion



        #region Connect
        public static async Task<bool> Connect(string server, string database, string user, string password)
        {
            if (await Proxy.InitAsync(server, database, user, password))
            {
                return await Proxy.OpenAsync();
            }

            return false;
        }
        #endregion

        #region Disconnect
        public static async Task<bool> Disconnect()
        {
            return await Proxy.CloseAsync();
        }
        #endregion

        #region Insert
        public static async Task<bool> Insert(string query)
        {
            return await Proxy.InsertAsync(query);
        }
        #endregion
    }
}
