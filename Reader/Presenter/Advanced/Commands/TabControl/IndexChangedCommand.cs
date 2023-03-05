using Reader.View;

namespace Reader.Presenter.Advanced.Commands.TabControl
{
    public class IndexChangedCommand
    {
        private readonly IMainForm _mainForm;
        private readonly IAdvancedForm _advancedForm;
        private readonly IViewController _viewController;

        public IndexChangedCommand(IMainForm mainForm, IAdvancedForm advancedForm, IViewController viewController)
        {
            _mainForm = mainForm;
            _advancedForm = advancedForm;
            _viewController = viewController;
        }

        public async Task Execute(int index)
        {
            if (_viewController.IsLocked) return;

            try
            {
                await _viewController.Refresh(index, true);

                if (_advancedForm.TabControlIndex == 0)
                {
                    _advancedForm.NameInputText = string.Empty;
                    _advancedForm.ModelInputText = string.Empty;
                    _advancedForm.SerialNumberInputText = string.Empty;
                    _advancedForm.BuzzerInputIndex = -1;
                    _advancedForm.BuzzerWidthInputIndex = -1;
                    _advancedForm.FrequencyInputIndex = -1;
                    _advancedForm.PowerInputIndex = -1;
                    _advancedForm.TagFilterInputIndex = -1;
                }
                else if (index == 1)
                {
                    _advancedForm.BusAddressInputIndex = -1;
                    _advancedForm.Rs232BaudRateInputIndex = -1;
                    _advancedForm.MacAddressInputText = string.Empty;
                    _advancedForm.IpAddressInputText = string.Empty;
                    _advancedForm.MaskInputText = string.Empty;
                    _advancedForm.GatewayInputText = string.Empty;
                    _advancedForm.SocketPortTcpInputText = string.Empty;
                    _advancedForm.SocketPortUdpInputText = string.Empty;
                }
                else
                {
                    throw new Exception("Not implemented index");
                }

                if (await _viewController.Data(index))
                {
                    _mainForm.LogDevice_Add(Lang.Advanced.DataUI_Success);
                }
                else
                {
                    _mainForm.LogDevice_Add(Lang.Advanced.DataUI_Error);
                }
            }
            catch (Exception exception)
            {
                _mainForm.LogDevice_Add(exception.Message, true);
            }
            finally
            {
                await _viewController.Refresh(index, false);
            }
        }
    }
}
