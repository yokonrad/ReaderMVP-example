using Reader.View;

namespace Reader.Presenter.Main.Commands.Read
{
    public class ReadStartCommand
    {
        private readonly IMainForm _mainForm;
        private readonly IViewController _viewController;
        private readonly IReadController _readController;
        private readonly Transponder _transponder;

        public ReadStartCommand(IMainForm mainForm, IViewController viewController, IReadController readController, Transponder transponder)
        {
            _mainForm = mainForm;
            _viewController = viewController;
            _readController = readController;
            _transponder = transponder;
        }

        public async Task Execute()
        {
            if (_viewController.IsLocked) return;

            try
            {
                if (!await RFID.Api.CheckHwConnection()) return;

                await _viewController.Refresh(true);

                if (await RFID.Api.ReadStart())
                {
                    _mainForm.LogDevice_Add(Lang.Main.ReadStart_Success);

                    _viewController.IsReadStarted = true;
                    _readController.SoundCount = 0;

                    object soundLock = new();
                    var tickCount = Environment.TickCount;

                    var activator = -1;
                    var tagFilter = -1;
                    var rssi1 = -1;
                    var rssi2 = -1;

                    if (_mainForm.SettingSwActivatorIndex > 0)
                    {
                        activator = Convert.ToInt32(_mainForm.SettingSwActivatorText);
                    }

                    if (_mainForm.SettingSwTagFilterIndex > 0)
                    {
                        tagFilter = Convert.ToInt32(_mainForm.SettingSwTagFilterText);
                    }

                    if (_mainForm.SettingSwRssi1Index > 0)
                    {
                        rssi1 = Convert.ToInt32(_mainForm.SettingSwRssi1Text);
                    }

                    if (_mainForm.SettingSwRssi2Index > 0)
                    {
                        rssi2 = Convert.ToInt32(_mainForm.SettingSwRssi2Text);
                    }

                    _ = Task.Run(async () =>
                    {
                        while (_viewController.IsReadStarted)
                        {
                            var readTransponder = await RFID.Api.ReadTransponder2();

                            if (readTransponder is not null)
                            {
                                var transponder = (RFID.StructTransponder)readTransponder;
                                transponder.Value = Math.Round(transponder.Value, 3);

                                if (_transponder.Add(transponder, activator, tagFilter, rssi1, rssi2))
                                {
                                    if (_readController.IsMysqlEnabled)
                                    {
                                        if (await MySQL.Api.CheckConnection())
                                        {
                                            // MySQL insert query command
                                        }
                                    }

                                    if (_readController.IsSoundEnabled)
                                    {
                                        lock (soundLock)
                                        {
                                            _readController.SoundCount++;
                                        }

                                        _readController.SoundWait.Set();
                                    }
                                }
                            }

                            if (Environment.TickCount - tickCount > 30000)
                            {
                                if (!await RFID.Api.CheckHwConnection())
                                {
                                    if (await RFID.Api.Reconnect())
                                    {
                                        _mainForm.LogDevice_Add(Lang.Main.Reconnect_Success);
                                    }
                                    else
                                    {
                                        _mainForm.LogDevice_Add(Lang.Main.Reconnect_Error);

                                        _viewController.IsReadStarted = false;
                                        _readController.SoundCount = 0;
                                        _readController.SoundWait.Set();
                                    }
                                }

                                tickCount = Environment.TickCount;
                            }
                        }
                    });

                    _ = Task.Run(() =>
                    {
                        while (_viewController.IsReadStarted && _readController.IsSoundEnabled)
                        {
                            _readController.SoundWait.Wait();

                            while (_readController.SoundCount > 0)
                            {
                                Console.Beep(1000, 100);

                                lock (soundLock)
                                {
                                    if (_readController.SoundCount > 0)
                                    {
                                        _readController.SoundCount--;
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }

                            _readController.SoundWait.Reset();
                        }
                    });
                }
                else
                {
                    _mainForm.LogDevice_Add(Lang.Main.ReadStart_Error);
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
