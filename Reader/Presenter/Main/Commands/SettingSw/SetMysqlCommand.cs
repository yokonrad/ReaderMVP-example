using Reader.View;

namespace Reader.Presenter.Main.Commands.SettingSw
{
    public class SetMysqlCommand
    {
        private readonly IMainForm _mainForm;
        private readonly IViewController _viewController;
        private readonly IReadController _readController;

        private readonly string server = string.Empty;
        private readonly string database = string.Empty;
        private readonly string user = string.Empty;
        private readonly string password = string.Empty;

        public SetMysqlCommand(IMainForm mainForm, IViewController viewController, IReadController readController)
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

                if (enabled)
                {
                    if (await MySQL.Api.Connect(server, database, user, password))
                    {
                        _mainForm.LogDevice_Add(Lang.Main.SetMysql_Success);

                        _readController.IsMysqlEnabled = true;
                    }
                    else
                    {
                        _mainForm.LogDevice_Add(Lang.Main.SetMysql_Error);

                        _mainForm.SettingSwMysqlChecked = false;
                    }
                }
                else
                {
                    if (await MySQL.Api.Disconnect())
                    {
                        _mainForm.LogDevice_Add(Lang.Main.SetMysql_Success);

                        _readController.IsMysqlEnabled = false;
                    }
                    else
                    {
                        _mainForm.LogDevice_Add(Lang.Main.SetMysql_Error);
                    }
                }
            }
            catch (Exception exception)
            {
                _mainForm.LogDevice_Add(exception.Message, false);

                _mainForm.SettingSwMysqlChecked = false;
            }
            finally
            {
                await _viewController.Refresh(false);
            }
        }
    }
}
