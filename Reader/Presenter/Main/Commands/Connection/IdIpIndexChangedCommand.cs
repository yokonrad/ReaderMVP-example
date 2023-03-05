using Reader.Model.Main;
using Reader.View;

namespace Reader.Presenter.Main.Commands.Connection
{
    public class IdIpIndexChangedCommand
    {
        private readonly IMainForm _mainForm;
        private readonly IViewController _viewController;
        private readonly IConnectionIpModel _connectionIpModel;

        public IdIpIndexChangedCommand(IMainForm mainForm, IViewController viewController, IConnectionIpModel connectionIpModel)
        {
            _mainForm = mainForm;
            _viewController = viewController;
            _connectionIpModel = connectionIpModel;
        }

        public void Execute(int index)
        {
            if (_viewController.IsLocked) return;

            try
            {
                if (_connectionIpModel.GetCount() >= index && index != 0)
                {
                    _mainForm.ConnectionIpProtocolIndex = Array.IndexOf(RFID.Api.ConnectIpProtocolItems(), _connectionIpModel.Get(index - 1).GetProtocol());
                    _mainForm.ConnectionIpHostNameText = _connectionIpModel.Get(index - 1).GetHostName();
                    _mainForm.ConnectionIpSocketPortText = Convert.ToString(_connectionIpModel.Get(index - 1).GetSocketPort());
                }
                else
                {
                    _mainForm.ConnectionIpProtocolIndex = -1;
                    _mainForm.ConnectionIpHostNameText = string.Empty;
                    _mainForm.ConnectionIpSocketPortText = string.Empty;
                }
            }
            catch (Exception exception)
            {
                _mainForm.LogDevice_Add(exception.Message, true);
            }
        }
    }
}
