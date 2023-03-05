using Reader.View;

namespace Reader.Presenter.Main.Commands.Read
{
    public class ReadStopCommand
    {
        private readonly IMainForm _mainForm;
        private readonly IViewController _viewController;
        private readonly IReadController _readController;

        public ReadStopCommand(IMainForm mainForm, IViewController viewController, IReadController readController)
        {
            _mainForm = mainForm;
            _viewController = viewController;
            _readController = readController;
        }

        public async Task Execute()
        {
            if (_viewController.IsLocked) return;

            try
            {
                if (!await RFID.Api.CheckHwConnection()) return;

                await _viewController.Refresh(true);

                if (await RFID.Api.ReadStop())
                {
                    _mainForm.LogDevice_Add(Lang.Main.ReadStop_Success);

                    _viewController.IsReadStarted = false;
                    _readController.SoundCount = 0;
                    _readController.SoundWait.Set();
                }
                else
                {
                    _mainForm.LogDevice_Add(Lang.Main.ReadStop_Error);
                }
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
