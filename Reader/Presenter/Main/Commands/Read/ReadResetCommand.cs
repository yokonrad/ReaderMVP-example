using Reader.View;

namespace Reader.Presenter.Main.Commands.Read
{
    public class ReadResetCommand
    {
        private readonly IMainForm _mainForm;
        private readonly IViewController _viewController;
        private readonly ITransponder _transponder;

        public ReadResetCommand(IMainForm mainForm, IViewController viewController, ITransponder transponder)
        {
            _mainForm = mainForm;
            _viewController = viewController;
            _transponder = transponder;
        }

        public async Task Execute()
        {
            if (_viewController.IsLocked) return;

            try
            {
                if (!await RFID.Api.CheckHwConnection()) return;

                await _viewController.Refresh(true);

                _transponder.Clear();
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
