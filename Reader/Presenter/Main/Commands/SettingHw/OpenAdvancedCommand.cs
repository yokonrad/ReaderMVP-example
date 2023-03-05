using Reader.View;

namespace Reader.Presenter.Main.Commands.SettingHw
{
    public class OpenAdvancedCommand
    {
        private readonly IMainForm _mainForm;
        private readonly IViewController _viewController;

        public OpenAdvancedCommand(IMainForm mainForm, IViewController viewController)
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

                _mainForm.OpenSettingHwAdvanced();
            }
            catch (Exception exception)
            {
                _mainForm.LogDevice_Add(exception.Message, true);
            }
            finally
            {
                await _viewController.Refresh(false);
            }
        }
    }
}
