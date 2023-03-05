using Reader.View;

namespace Reader.Presenter.Main.Commands.Connection
{
    public class DisconnectCommand
    {
        private readonly IMainForm _mainForm;
        private readonly IViewController _viewController;

        public DisconnectCommand(IMainForm mainForm, IViewController viewController)
        {
            _mainForm = mainForm;
            _viewController = viewController;
        }

        public async Task Execute()
        {
            if (_viewController.IsLocked) return;

            try
            {
                if (!await RFID.Api.CheckSwConnection()) return;

                await _viewController.Refresh(true);

                if (await RFID.Api.Disconnect())
                {
                    _mainForm.LogDevice_Add(Lang.Main.Disconnect_Success);
                }
                else
                {
                    _mainForm.LogDevice_Add(Lang.Main.Disconnect_Error);
                }
            }
            catch (Exception exception)
            {
                _mainForm.LogDevice_Add(exception.Message, false);
            }
            finally
            {
                await _viewController.Refresh(false);
            }
        }
    }
}
