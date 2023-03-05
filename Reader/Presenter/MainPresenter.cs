using Reader.Model.Main;
using Reader.Presenter.Main;
using Reader.Presenter.Main.Commands.Connection;
using Reader.Presenter.Main.Commands.Form;
using Reader.Presenter.Main.Commands.Read;
using Reader.Presenter.Main.Commands.SettingHw;
using Reader.Presenter.Main.Commands.SettingSw;
using Reader.View;

namespace Reader.Presenter
{
    public class MainPresenter
    {
        private readonly CancellationToken _ct;
        private readonly CancellationTokenSource _cts;

        private readonly IMainForm _mainForm;
        private readonly IConnectionComModel _connectionComModel;
        private readonly IConnectionIpModel _connectionIpModel;
        private readonly ISettingSwModel _settingSwModel;
        private readonly IValidateModel _validateModel;

        private readonly IViewController _viewController;
        private readonly IReadController _readController;

        private readonly LoadCommand _loadCommand;
        private readonly FormClosedCommand _formClosedCommand;
        private readonly KeyDownCommand _keyDownCommand;

        private readonly IdComIndexChangedCommand _idComIndexChangedCommand;
        private readonly IdIpIndexChangedCommand _idIpIndexChangedCommand;
        private readonly ConnectComCommand _connectComCommand;
        private readonly ConnectIpCommand _connectIpCommand;
        private readonly DisconnectCommand _disconnectCommand;

        private readonly SetBuzzerCommand _setBuzzerCommand;
        private readonly SetPowerCommand _setPowerCommand;
        private readonly SetTagFilterCommand _setTagFilterCommand;
        private readonly OpenAdvancedCommand _openAdvancedCommand;

        private readonly SetSoundCommand _setSoundCommand;
        private readonly SetMysqlCommand _setMysqlCommand;

        private readonly Transponder _transponder;

        private readonly ReadStartCommand _readStartCommand;
        private readonly ReadStopCommand _readStopCommand;
        private readonly ReadResetCommand _readResetCommand;

        public MainPresenter(IMainForm mainForm, IConnectionComModel connectionComModel, IConnectionIpModel connectionIpModel, ISettingSwModel settingSwModel, IValidateModel validateModel)
        {
            _ct = new CancellationToken();
            _cts = new CancellationTokenSource();
            _ct = _cts.Token;

            _mainForm = mainForm;
            _connectionComModel = connectionComModel;
            _connectionIpModel = connectionIpModel;
            _settingSwModel = settingSwModel;
            _validateModel = validateModel;

            _viewController = new ViewController(_mainForm);
            _readController = new ReadController();

            _loadCommand = new(_viewController);
            _formClosedCommand = new(_cts);

            _idComIndexChangedCommand = new(_mainForm, _viewController, _connectionComModel);
            _idIpIndexChangedCommand = new(_mainForm, _viewController, _connectionIpModel);
            _connectComCommand = new(_mainForm, _viewController, _validateModel, _ct);
            _connectIpCommand = new(_mainForm, _viewController, _validateModel, _ct);
            _disconnectCommand = new(_mainForm, _viewController);

            _setBuzzerCommand = new(_mainForm, _viewController, _validateModel);
            _setPowerCommand = new(_mainForm, _viewController, _validateModel);
            _setTagFilterCommand = new(_mainForm, _viewController, _validateModel);
            _openAdvancedCommand = new(_mainForm, _viewController);

            _setSoundCommand = new(_mainForm, _viewController, _readController);
            _setMysqlCommand = new(_mainForm, _viewController, _readController);

            _transponder = new(_mainForm);

            _readStartCommand = new(_mainForm, _viewController, _readController, _transponder);
            _readStopCommand = new(_mainForm, _viewController, _readController);
            _readResetCommand = new(_mainForm, _viewController, _transponder);

            _keyDownCommand = new(_mainForm, _viewController, _readStartCommand, _readStopCommand, _readResetCommand, _setSoundCommand, _setMysqlCommand);

            FormEventsBind();
            ConnectionComControlsSet();
            ConnectionComEventsBind();
            ConnectionIpControlsSet();
            ConnectionIpEventsBind();
            SettingHwControlsSet();
            SettingHwEventsBind();
            SettingSwControlsSet();
            SettingSwEventsBind();
            ReadEventsBind();
        }

        #region Form functions
        private void FormEventsBind()
        {
            _mainForm.Load += FormViewOnLoad;
            _mainForm.FormClosed += FormViewOnFormClosed;
            _mainForm.KeyDown += FormViewOnKeyDown;
        }
        #endregion
        #region Form handlers
        private async void FormViewOnLoad(object? sender, EventArgs e)
        {
            await _loadCommand.Execute();
        }

        private void FormViewOnFormClosed(object? sender, FormClosedEventArgs e)
        {
            _formClosedCommand.Execute();
        }

        private async void FormViewOnKeyDown(object? sender, KeyEventArgs e)
        {
            await _keyDownCommand.Execute(e);
        }
        #endregion

        #region ConnectionCom functions
        private void ConnectionComControlsSet()
        {
            _connectionComModel.Add(1, "COM3", 19200);
            _connectionComModel.Add(2, "COM3", 19200);

            _mainForm.SetConnectionComIdItems(_connectionComModel.GetItems());
            _mainForm.SetConnectionComBusAddressItems(RFID.Api.ConnectComBusAddressItems());
            _mainForm.SetConnectionComComNumberItems(RFID.Api.ConnectComComNumberItems());
            _mainForm.SetConnectionComBaudRateItems(RFID.Api.ConnectComBaudRateItems());
        }

        private void ConnectionComEventsBind()
        {
            _mainForm.ConnectionComId_SelectedIndexChanged += ConnectionComIdOnSelectedIndexChanged;
            _mainForm.ConnectionComConnect_Click += ConnectionComConnectOnClick;
            _mainForm.ConnectionComDisconnect_Click += ConnectionComDisconnectOnClick;
        }
        #endregion
        #region ConnectionCom handlers
        private void ConnectionComIdOnSelectedIndexChanged(object? sender, EventArgs e)
        {
            _idComIndexChangedCommand.Execute(_mainForm.ConnectionComIdIndex);
        }

        private async void ConnectionComConnectOnClick(object? sender, EventArgs e)
        {
            await _connectComCommand.Execute(_mainForm.ConnectionComBusAddressText, _mainForm.ConnectionComComNumberText, _mainForm.ConnectionComBaudRateText);
        }

        private async void ConnectionComDisconnectOnClick(object? sender, EventArgs e)
        {
            await _disconnectCommand.Execute();
        }
        #endregion

        #region ConnectionIp functions
        private void ConnectionIpControlsSet()
        {
            _connectionIpModel.Add("TCP", "192.168.1.41", 7086);
            _connectionIpModel.Add("UDP", "192.168.1.41", 7088);
            _connectionIpModel.Add("TCP", "192.168.1.42", 7086);
            _connectionIpModel.Add("UDP", "192.168.1.42", 7088);

            _mainForm.SetConnectionIpIdItems(_connectionIpModel.GetItems());
            _mainForm.SetConnectionIpProtocolItems(RFID.Api.ConnectIpProtocolItems());
        }

        private void ConnectionIpEventsBind()
        {
            _mainForm.ConnectionIpId_SelectedIndexChanged += ConnectionIpIdOnSelectedIndexChanged;
            _mainForm.ConnectionIpConnect_Click += ConnectionIpConnectOnClick;
            _mainForm.ConnectionIpDisconnect_Click += ConnectionIpDisconnectOnClick;
        }
        #endregion
        #region ConnectionIp handlers
        private void ConnectionIpIdOnSelectedIndexChanged(object? sender, EventArgs e)
        {
            _idIpIndexChangedCommand.Execute(_mainForm.ConnectionIpIdIndex);
        }

        private async void ConnectionIpConnectOnClick(object? sender, EventArgs e)
        {
            await _connectIpCommand.Execute(_mainForm.ConnectionIpProtocolText, _mainForm.ConnectionIpHostNameText, _mainForm.ConnectionIpSocketPortText);
        }

        private async void ConnectionIpDisconnectOnClick(object? sender, EventArgs e)
        {
            await _disconnectCommand.Execute();
        }
        #endregion

        #region SettingHw functions
        private void SettingHwControlsSet()
        {
            _mainForm.SetSettingHwPowerItems(RFID.Api.GetPowerItems());
            _mainForm.SetSettingHwTagFilterItems(RFID.Api.GetTagFilterItems());
            _mainForm.SetSettingHwBuzzerItems(RFID.Api.GetBuzzerItems());
        }

        private void SettingHwEventsBind()
        {
            _mainForm.SettingHwPower_SelectedIndexChanged += SettingHwPowerOnSelectedIndexChanged;
            _mainForm.SettingHwTagFilter_SelectedIndexChanged += SettingHwTagFilterOnSelectedIndexChanged;
            _mainForm.SettingHwBuzzer_SelectedIndexChanged += SettingHwBuzzerOnSelectedIndexChanged;
            _mainForm.SettingHwAdvanced_Click += SettingHwAdvancedOnClick;
        }
        #endregion
        #region SettingHw handlers
        private async void SettingHwPowerOnSelectedIndexChanged(object? sender, EventArgs e)
        {
            await _setPowerCommand.Execute(_mainForm.SettingHwPowerIndex);
        }

        private async void SettingHwTagFilterOnSelectedIndexChanged(object? sender, EventArgs e)
        {
            await _setTagFilterCommand.Execute(_mainForm.SettingHwTagFilterIndex);
        }

        private async void SettingHwBuzzerOnSelectedIndexChanged(object? sender, EventArgs e)
        {
            await _setBuzzerCommand.Execute(_mainForm.SettingHwBuzzerIndex);
        }

        private async void SettingHwAdvancedOnClick(object? sender, EventArgs e)
        {
            await _openAdvancedCommand.Execute();
        }
        #endregion

        #region SettingSw functions
        private void SettingSwControlsSet()
        {
            _mainForm.SetSettingSwActivatorItems(_settingSwModel.GetActivatorItems());
            _mainForm.SetSettingSwTagFilterItems(_settingSwModel.GetTagFilterItems());
            _mainForm.SetSettingSwRssi1Items(_settingSwModel.GetRssi1Items());
            _mainForm.SetSettingSwRssi2Items(_settingSwModel.GetRssi2Items());
        }

        private void SettingSwEventsBind()
        {
            _mainForm.SettingSwSound_CheckedChanged += SettingSwSoundCheckedChanged;
            _mainForm.SettingSwMysql_CheckedChanged += SettingSwMysqlCheckedChanged;
        }
        #endregion
        #region SettingSw handlers
        private async void SettingSwSoundCheckedChanged(object? sender, EventArgs e)
        {
            await _setSoundCommand.Execute(_mainForm.SettingSwSoundChecked);
        }

        private async void SettingSwMysqlCheckedChanged(object? sender, EventArgs e)
        {
            await _setMysqlCommand.Execute(_mainForm.SettingSwMysqlChecked);
        }
        #endregion

        #region Read functions
        private void ReadEventsBind()
        {
            _mainForm.ReadStart_Click += ReadStartOnClick;
            _mainForm.ReadStop_Click += ReadStopOnClick;
            _mainForm.ReadReset_Click += ReadResetOnClick;
        }
        #endregion
        #region Read handlers
        private async void ReadStartOnClick(object? sender, EventArgs e)
        {
            await _readStartCommand.Execute();
        }

        private async void ReadStopOnClick(object? sender, EventArgs e)
        {
            await _readStopCommand.Execute();
        }

        private async void ReadResetOnClick(object? sender, EventArgs e)
        {
            await _readResetCommand.Execute();
        }
        #endregion
    }
}
