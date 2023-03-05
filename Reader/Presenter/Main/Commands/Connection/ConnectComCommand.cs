using Reader.Model.Main;
using Reader.View;

namespace Reader.Presenter.Main.Commands.Connection
{
    public class ConnectComCommand
    {
        private readonly IMainForm _mainForm;
        private readonly IViewController _viewController;
        private readonly IValidateModel _validateModel;
        private readonly CancellationToken _ct;

        public ConnectComCommand(IMainForm mainForm, IViewController viewController, IValidateModel validateModel, CancellationToken ct)
        {
            _mainForm = mainForm;
            _viewController = viewController;
            _validateModel = validateModel;
            _ct = ct;
        }

        public async Task Execute(string busAddress, string comNumber, string baudRate)
        {
            if (_viewController.IsLocked) return;

            try
            {
                if (!_validateModel.ConnectCom(busAddress, comNumber, baudRate)) return;

                if (await RFID.Api.CheckSwConnection()) return;

                await _viewController.Refresh(true);

                if (await ConnectCom(Convert.ToInt32(busAddress), comNumber, Convert.ToInt32(baudRate)))
                {
                    _mainForm.LogDevice_Add(Lang.Main.Connect_Success);
                }
                else
                {
                    _mainForm.LogDevice_Add(Lang.Main.Connect_Error);
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

        private async Task<bool> ConnectCom(int busAddress, string comNumber, int baudRate)
        {
            if (await RFID.Api.ConnectCom(busAddress, comNumber, baudRate))
            {
                if (await RFID.Api.CheckHwConnection())
                {
                    var tasksInt = new List<Func<Task<int?>>>
                    {
                        () => RFID.Api.GetPowerKey(),
                        () => RFID.Api.GetTagFilterKey(),
                        () => RFID.Api.GetBuzzerKey(),
                    };
                    var resultsInt = new List<int?>();

                    foreach (var task in tasksInt)
                    {
                        if (!_ct.IsCancellationRequested)
                        {
                            resultsInt.Add(await task());
                        }
                    }

                    if (resultsInt.Count == tasksInt.Count)
                    {
                        _mainForm.SettingHwPowerIndex = resultsInt.ElementAt(0) ?? -1;
                        _mainForm.SettingHwTagFilterIndex = resultsInt.ElementAt(1) ?? -1;
                        _mainForm.SettingHwBuzzerIndex = resultsInt.ElementAt(2) ?? -1;

                        _mainForm.SettingSwActivatorIndex = 0;
                        _mainForm.SettingSwTagFilterIndex = 0;
                        _mainForm.SettingSwRssi1Index = 0;
                        _mainForm.SettingSwRssi2Index = 0;
                        _mainForm.SettingSwSoundChecked = false;
                        _mainForm.SettingSwMysqlChecked = false;

                        return true;
                    }
                }
            }

            return false;
        }
    }
}
