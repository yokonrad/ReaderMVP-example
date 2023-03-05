using Reader.View;

namespace Reader.Presenter.Main.Commands.SettingSw
{
    public class SetSoundCommand
    {
        private readonly IMainForm _mainForm;
        private readonly IViewController _viewController;
        private readonly IReadController _readController;

        public SetSoundCommand(IMainForm mainForm, IViewController viewController, IReadController readController)
        {
            _mainForm = mainForm;
            _viewController = viewController;
            _readController = readController;
        }

        public async Task Execute(bool enabled)
        {
            if (_viewController.IsLocked) return;

            try
            {
                if (!await RFID.Api.CheckSwConnection()) return;

                await _viewController.Refresh(true);

                _readController.IsSoundEnabled = enabled;

                _mainForm.LogDevice_Add(Lang.Main.SetSound_Success);
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
