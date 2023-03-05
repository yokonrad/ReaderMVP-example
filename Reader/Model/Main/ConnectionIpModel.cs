namespace Reader.Model.Main
{
    public interface IConnectionIpModel
    {
        bool Add(string protocol, string hostName, int socketPort);
        ConnectionIpModel.ConnectionIp Get(int index);
        int GetCount();
        object[] GetItems();
    }

    public class ConnectionIpModel : IConnectionIpModel
    {
        #region structs
        public readonly struct ConnectionIp
        {
            private readonly string _protocol;
            private readonly string _hostName;
            private readonly int _socketPort;

            public ConnectionIp(string protocol, string hostName, int socketPort)
            {
                _protocol = protocol;
                _hostName = hostName;
                _socketPort = socketPort;
            }

            public string GetProtocol() => _protocol;

            public string GetHostName() => _hostName;

            public int GetSocketPort() => _socketPort;
        }
        #endregion

        #region variables
        private readonly List<ConnectionIp> _listConnectionsIp;
        private readonly IValidateModel _validateModel;
        #endregion

        public ConnectionIpModel()
        {
            _listConnectionsIp = new();
            _validateModel = new ValidateModel();
        }

        public bool Add(string protocol, string hostName, int socketPort)
        {
            if (!_validateModel.ConnectIp(protocol, hostName, Convert.ToString(socketPort))) return false;

            _listConnectionsIp.Add(new ConnectionIp(protocol, hostName, socketPort));

            return true;
        }

        public ConnectionIp Get(int index)
        {
            return _listConnectionsIp.ElementAt(index);
        }

        public int GetCount()
        {
            return _listConnectionsIp.Count;
        }

        public object[] GetItems()
        {
            List<object> list = new() { "" };

            for (int i = 0; i < _listConnectionsIp.Count; i++) list.Add(i + 1);

            return list.ToArray<object>();
        }
    }
}
