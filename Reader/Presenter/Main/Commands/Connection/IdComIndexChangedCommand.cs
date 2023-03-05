using Reader.Model.Main;
using Reader.View;

namespace Reader.Presenter.Main.Commands.Connection
{
    public class IdComIndexChangedCommand
    {
        private readonly IMainForm _mainForm;
        private readonly IViewController _viewController;
        private readonly IConnectionComModel _connectionComModel;

        public IdComIndexChangedCommand(IMainForm mainForm, IViewController viewController, IConnectionComModel connectionComModel)
        {
            _mainForm = mainForm;
            _viewController = viewController;
            _connectionComModel = connectionComModel;
        }

        public void Execute(int index)
        {
            if (_viewController.IsLocked) return;

            try
            {
                if (_connectionComModel.GetCount() >= index && index != 0)
                {
                    _mainForm.ConnectionComBusAddressIndex = Array.IndexOf(RFID.Api.ConnectComBusAddressItems(), _connectionComModel.Get(index - 1).GetBusAddress());
                    _mainForm.ConnectionComComNumberIndex = Array.IndexOf(RFID.Api.ConnectComComNumberItems(), _connectionComModel.Get(index - 1).GetComNumber());
                    _mainForm.ConnectionComBaudRateIndex = Array.IndexOf(RFID.Api.ConnectComBaudRateItems(), _connectionComModel.Get(index - 1).GetBaudRate());
                }
                else
                {
                    _mainForm.ConnectionComBusAddressIndex = -1;
                    _mainForm.ConnectionComComNumberIndex = -1;
                    _mainForm.ConnectionComBaudRateIndex = -1;
                }
            }
            catch (Exception exception)
            {
                _mainForm.LogDevice_Add(exception.Message, true);
            }
        }
    }
}
