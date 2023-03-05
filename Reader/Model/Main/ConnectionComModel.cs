namespace Reader.Model.Main
{
    public interface IConnectionComModel
    {
        bool Add(int busAddress, string comNumber, int baudRate);
        ConnectionComModel.ConnectionCom Get(int index);
        int GetCount();
        object[] GetItems();
    }

    public class ConnectionComModel : IConnectionComModel
    {
        #region structs
        public readonly struct ConnectionCom
        {
            private readonly int _busAddress;
            private readonly string _comNumber;
            private readonly int _baudRate;

            public ConnectionCom(int busAddress, string comNumber, int baudRate)
            {
                _busAddress = busAddress;
                _comNumber = comNumber;
                _baudRate = baudRate;
            }

            public int GetBusAddress() => _busAddress;

            public string GetComNumber() => _comNumber;

            public int GetBaudRate() => _baudRate;
        }
        #endregion

        #region variables
        private readonly List<ConnectionCom> _listConnectionCom;
        private readonly IValidateModel _validateModel;
        #endregion

        public ConnectionComModel()
        {
            _listConnectionCom = new();
            _validateModel = new ValidateModel();
        }

        public bool Add(int busAddress, string comNumber, int baudRate)
        {
            if (!_validateModel.ConnectCom(Convert.ToString(busAddress), comNumber, Convert.ToString(baudRate))) return false;

            _listConnectionCom.Add(new ConnectionCom(busAddress, comNumber, baudRate));

            return true;
        }

        public ConnectionCom Get(int index)
        {
            return _listConnectionCom.ElementAt(index);
        }

        public int GetCount()
        {
            return _listConnectionCom.Count;
        }

        public object[] GetItems()
        {
            List<object> list = new() { "" };

            for (int i = 0; i < _listConnectionCom.Count; i++) list.Add(i + 1);

            return list.ToArray<object>();
        }
    }
}
