using Reader.Presenter.Main.Commands.Read;
using Reader.Presenter.Main.Commands.SettingSw;
using Reader.View;

namespace Reader.Presenter.Main.Commands.Form
{
    public class KeyDownCommand
    {
        private readonly IMainForm _mainForm;
        private readonly IViewController _viewController;
        private readonly ReadStartCommand _readStartCommand;
        private readonly ReadStopCommand _readStopCommand;
        private readonly ReadResetCommand _readResetCommand;
        private readonly SetSoundCommand _setSoundCommand;
        private readonly SetMysqlCommand _setMysqlCommand;

        public KeyDownCommand(IMainForm mainForm, IViewController viewController,
            ReadStartCommand readStartCommand,
            ReadStopCommand readStopCommand,
            ReadResetCommand readResetCommand,
            SetSoundCommand setSoundCommand,
            SetMysqlCommand setMysqlCommand)
        {
            _mainForm = mainForm;
            _viewController = viewController;
            _readStartCommand = readStartCommand;
            _readStopCommand = readStopCommand;
            _readResetCommand = readResetCommand;
            _setSoundCommand = setSoundCommand;
            _setMysqlCommand = setMysqlCommand;
        }

        public async Task Execute(KeyEventArgs e)
        {
            if (_viewController.IsLocked) return;

            try
            {
                if (e.Control)
                {
                    switch (e.KeyCode)
                    {
                        case Keys.D1:
                            await _readStartCommand.Execute();
                            break;

                        case Keys.D2:
                            await _readStopCommand.Execute();
                            break;

                        case Keys.D3:
                            await _readResetCommand.Execute();
                            break;

                        case Keys.D4:
                            await _setSoundCommand.Execute(_mainForm.SettingSwSoundChecked);
                            break;

                        case Keys.D5:
                            await _setMysqlCommand.Execute(_mainForm.SettingSwMysqlChecked);
                            break;
                    }
                }
            }
            catch (Exception exception)
            {
                _mainForm.LogDevice_Add(exception.Message, true);
            }
        }
    }
}
