using Reader.Model.Advanced;
using Reader.Presenter.Advanced;
using Reader.Presenter.Advanced.Commands.Form;
using Reader.Presenter.Advanced.Commands.TabControl;
using Reader.Presenter.Advanced.Commands.TabControlPage1;
using Reader.Presenter.Advanced.Commands.TabControlPage2;
using Reader.View;

namespace Reader.Presenter
{
    public class AdvancedPresenter
    {
        private readonly CancellationToken _ct;
        private readonly CancellationTokenSource _cts;

        private readonly IMainForm _mainForm;
        private readonly IAdvancedForm _advancedForm;
        private readonly IValidateModel _validateModel;

        private readonly IViewController _viewController;

        private readonly LoadCommand _loadCommand;
        private readonly FormClosedCommand _formClosedCommand;
        private readonly KeyDownCommand _keyDownCommand;

        private readonly IndexChangedCommand _indexChangedCommand;

        private readonly SetNameCommand _setNameCommand;
        private readonly SetModelCommand _setModelCommand;
        private readonly SetSerialNumberCommand _setSerialNumberCommand;
        private readonly SetBuzzerCommand _setBuzzerCommand;
        private readonly SetBuzzerWidthCommand _setBuzzerWidthCommand;
        private readonly SetFrequencyCommand _setFrequencyCommand;
        private readonly SetPowerCommand _setPowerCommand;
        private readonly SetTagFilterCommand _setTagFilterCommand;
        private readonly OpenRebootCommand _openRebootCommand;

        private readonly SetBusAddressCommand _setBusAddressCommand;
        private readonly SetRs232BaudRateCommand _setRs232BaudRateCommand;
        private readonly SetMacAddressCommand _setMacAddressCommand;
        private readonly SetIpAddressCommand _setIpAddressCommand;
        private readonly SetMaskCommand _setMaskCommand;
        private readonly SetGatewayCommand _setGatewayCommand;
        private readonly SetSocketPortTcpCommand _setSocketPortTcpCommand;
        private readonly SetSocketPortUdpCommand _setSocketPortUdpCommand;

        public AdvancedPresenter(IMainForm mainForm, IAdvancedForm advancedForm, IValidateModel validateModel)
        {
            _ct = new CancellationToken();
            _cts = new CancellationTokenSource();
            _ct = _cts.Token;

            _mainForm = mainForm;
            _advancedForm = advancedForm;
            _validateModel = validateModel;

            _viewController = new ViewController(_advancedForm, _ct);

            _loadCommand = new(_mainForm, _viewController);
            _formClosedCommand = new(_cts);
            _keyDownCommand = new(_mainForm, _viewController);

            _indexChangedCommand = new(_mainForm, _advancedForm, _viewController);

            _setNameCommand = new(_mainForm, _advancedForm, _viewController, _validateModel);
            _setModelCommand = new(_mainForm, _advancedForm, _viewController, _validateModel);
            _setSerialNumberCommand = new(_mainForm, _advancedForm, _viewController, _validateModel);
            _setBuzzerCommand = new(_mainForm, _advancedForm, _viewController, _validateModel);
            _setBuzzerWidthCommand = new(_mainForm, _advancedForm, _viewController, _validateModel);
            _setFrequencyCommand = new(_mainForm, _advancedForm, _viewController, _validateModel);
            _setPowerCommand = new(_mainForm, _advancedForm, _viewController, _validateModel);
            _setTagFilterCommand = new(_mainForm, _advancedForm, _viewController, _validateModel);
            _openRebootCommand = new(_mainForm, _advancedForm, _viewController);

            _setBusAddressCommand = new(_mainForm, _advancedForm, _viewController, _validateModel);
            _setRs232BaudRateCommand = new(_mainForm, _advancedForm, _viewController, _validateModel);
            _setMacAddressCommand = new(_mainForm, _advancedForm, _viewController, _validateModel);
            _setIpAddressCommand = new(_mainForm, _advancedForm, _viewController, _validateModel);
            _setMaskCommand = new(_mainForm, _advancedForm, _viewController, _validateModel);
            _setGatewayCommand = new(_mainForm, _advancedForm, _viewController, _validateModel);
            _setSocketPortTcpCommand = new(_mainForm, _advancedForm, _viewController, _validateModel);
            _setSocketPortUdpCommand = new(_mainForm, _advancedForm, _viewController, _validateModel);

            FormEventsBind();
            TabControlEventsBind();
            TabControlPage1ControlsSet();
            TabControlPage1EventsBind();
            TabControlPage2ControlsSet();
            TabControlPage2EventsBind();
        }

        #region Form functions
        private void FormEventsBind()
        {
            _advancedForm.Load += FormViewOnLoad;
            _advancedForm.FormClosed += FormViewOnFormClosed;
            _advancedForm.KeyDown += FormViewOnKeyDown;
        }
        #endregion
        #region Form handlers
        private async void FormViewOnLoad(object? sender, EventArgs e)
        {
            await _loadCommand.Execute(_advancedForm.TabControlIndex);
        }

        private void FormViewOnFormClosed(object? sender, FormClosedEventArgs e)
        {
            _formClosedCommand.Execute();
        }

        private async void FormViewOnKeyDown(object? sender, KeyEventArgs e)
        {
            await _keyDownCommand.Execute(_advancedForm.TabControlIndex, e);
        }
        #endregion

        #region TabControl functions
        private void TabControlEventsBind()
        {
            _advancedForm.TabControl_IndexChanged += TabControlOnIndexChanged;
        }
        #endregion
        #region TabControl handlers
        private async void TabControlOnIndexChanged(object? sender, EventArgs e)
        {
            await _indexChangedCommand.Execute(_advancedForm.TabControlIndex);
        }
        #endregion

        #region TabControlPage1 functions
        private void TabControlPage1ControlsSet()
        {
            _advancedForm.NameInputMaxLength = RFID.Api.GetNameMaxLength();
            _advancedForm.ModelInputMaxLength = RFID.Api.GetModelMaxLength();
            _advancedForm.SerialNumberInputMaxLength = RFID.Api.GetSerialNumberMaxLength();
            _advancedForm.SetBuzzerInputItems(RFID.Api.GetBuzzerItems());
            _advancedForm.SetBuzzerWidthInputItems(RFID.Api.GetBuzzerWidthItems());
            _advancedForm.SetFrequencyInputItems(RFID.Api.GetFrequencyItems());
            _advancedForm.SetPowerInputItems(RFID.Api.GetPowerItems());
            _advancedForm.SetTagFilterInputItems(RFID.Api.GetTagFilterItems());
        }

        private void TabControlPage1EventsBind()
        {
            _advancedForm.NameButton_Click += NameButtonOnClick;
            _advancedForm.ModelButton_Click += ModelButtonOnClick;
            _advancedForm.SerialNumberButton_Click += SerialNumberButtonOnClick;
            _advancedForm.BuzzerButton_Click += BuzzerButtonOnClick;
            _advancedForm.BuzzerWidthButton_Click += BuzzerWidthButtonOnClick;
            _advancedForm.FrequencyButton_Click += FrequencyButtonOnClick;
            _advancedForm.PowerButton_Click += PowerButtonOnClick;
            _advancedForm.TagFilterButton_Click += TagFilterButtonOnClick;
            _advancedForm.RebootButton_Click += RebootButtonOnClick;
        }
        #endregion
        #region TabControlPage1 handlers
        private async void NameButtonOnClick(object? sender, EventArgs e)
        {
            await _setNameCommand.Execute(_advancedForm.NameInputText);
        }

        private async void ModelButtonOnClick(object? sender, EventArgs e)
        {
            await _setModelCommand.Execute(_advancedForm.ModelInputText);
        }

        private async void SerialNumberButtonOnClick(object? sender, EventArgs e)
        {
            await _setSerialNumberCommand.Execute(_advancedForm.SerialNumberInputText);
        }

        private async void BuzzerButtonOnClick(object? sender, EventArgs e)
        {
            await _setBuzzerCommand.Execute(_advancedForm.BuzzerInputIndex);
        }

        private async void BuzzerWidthButtonOnClick(object? sender, EventArgs e)
        {
            await _setBuzzerWidthCommand.Execute(_advancedForm.BuzzerWidthInputIndex);
        }

        private async void FrequencyButtonOnClick(object? sender, EventArgs e)
        {
            await _setFrequencyCommand.Execute(_advancedForm.FrequencyInputIndex);
        }

        private async void PowerButtonOnClick(object? sender, EventArgs e)
        {
            await _setPowerCommand.Execute(_advancedForm.PowerInputIndex);
        }

        private async void TagFilterButtonOnClick(object? sender, EventArgs e)
        {
            await _setTagFilterCommand.Execute(_advancedForm.TagFilterInputIndex);
        }

        private async void RebootButtonOnClick(object? sender, EventArgs e)
        {
            await _openRebootCommand.Execute();
        }
        #endregion

        #region TabControlPage2 functions
        private void TabControlPage2ControlsSet()
        {
            _advancedForm.SetBusAddressInputItems(RFID.Api.GetBusAddressItems());
            _advancedForm.SetRs232BaudRateInputItems(RFID.Api.GetRs232BaudRateItems());
            _advancedForm.MacAddressInputMaxLength = RFID.Api.GetMacAddressMaxLength();
            _advancedForm.IpAddressInputMaxLength = RFID.Api.GetIpAddressMaxLength();
            _advancedForm.MaskInputMaxLength = RFID.Api.GetMaskMaxLength();
            _advancedForm.GatewayInputMaxLength = RFID.Api.GetGatewayMaxLength();
            _advancedForm.SocketPortTcpInputMaxLength = RFID.Api.GetSocketPortTcpMax().ToString().Length;
            _advancedForm.SocketPortUdpInputMaxLength = RFID.Api.GetSocketPortUdpMax().ToString().Length;
        }

        private void TabControlPage2EventsBind()
        {
            _advancedForm.BusAddressButton_Click += BusAddressButtonOnClick;
            _advancedForm.Rs232BaudRateButton_Click += Rs232BaudRateButtonOnClick;
            _advancedForm.MacAddressButton_Click += MacAddressButtonOnClick;
            _advancedForm.IpAddressButton_Click += IpAddressButtonOnClick;
            _advancedForm.MaskButton_Click += MaskButtonOnClick;
            _advancedForm.GatewayButton_Click += GatewayButtonOnClick;
            _advancedForm.SocketPortTcpButton_Click += SocketPortTcpButtonOnClick;
            _advancedForm.SocketPortUdpButton_Click += SocketPortUdpButtonOnClick;
        }
        #endregion
        #region TabControlPage2 handlers
        private async void BusAddressButtonOnClick(object? sender, EventArgs e)
        {
            await _setBusAddressCommand.Execute(_advancedForm.BusAddressInputIndex);
        }

        private async void Rs232BaudRateButtonOnClick(object? sender, EventArgs e)
        {
            await _setRs232BaudRateCommand.Execute(_advancedForm.Rs232BaudRateInputIndex);
        }

        private async void MacAddressButtonOnClick(object? sender, EventArgs e)
        {
            await _setMacAddressCommand.Execute(_advancedForm.MacAddressInputText);
        }

        private async void IpAddressButtonOnClick(object? sender, EventArgs e)
        {
            await _setIpAddressCommand.Execute(_advancedForm.IpAddressInputText);
        }

        private async void MaskButtonOnClick(object? sender, EventArgs e)
        {
            await _setMaskCommand.Execute(_advancedForm.MaskInputText);
        }

        private async void GatewayButtonOnClick(object? sender, EventArgs e)
        {
            await _setGatewayCommand.Execute(_advancedForm.GatewayInputText);
        }

        private async void SocketPortTcpButtonOnClick(object? sender, EventArgs e)
        {
            await _setSocketPortTcpCommand.Execute(Convert.ToInt32(_advancedForm.SocketPortTcpInputText));
        }

        private async void SocketPortUdpButtonOnClick(object? sender, EventArgs e)
        {
            await _setSocketPortUdpCommand.Execute(Convert.ToInt32(_advancedForm.SocketPortUdpInputText));
        }
        #endregion
    }
}
