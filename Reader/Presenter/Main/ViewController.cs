using Reader.View;
using System.Diagnostics;

namespace Reader.Presenter.Main
{
    public interface IViewController
    {
        bool IsConnectedCom { get; set; }
        bool IsConnectedIp { get; set; }
        bool IsLocked { get; }
        bool IsReadStarted { get; set; }

        Task Refresh(bool lockUI = false);
    }

    public class ViewController : IViewController
    {
        private readonly IMainForm _mainForm;

        private bool _locked = false;
        private bool _connectedCom = false;
        private bool _connectedIp = false;
        private bool _readStarted = false;

        public ViewController(IMainForm mainForm)
        {
            _mainForm = mainForm;
        }

        public bool IsLocked => _locked;
        public bool IsConnectedCom
        {
            get { return _connectedCom; }
            set { _connectedCom = value; }
        }
        public bool IsConnectedIp
        {
            get { return _connectedIp; }
            set { _connectedIp = value; }
        }
        public bool IsReadStarted
        {
            get { return _readStarted; }
            set { _readStarted = value; }
        }

        public async Task Refresh(bool lockUI = false)
        {
            _locked = lockUI;

            var connected = await RFID.Api.CheckSwConnection();

            if (!connected)
            {
                _connectedCom = false;
                _connectedIp = false;
            }

            _mainForm.ConnectionComIdEnabled = !_locked && !_connectedIp && !_readStarted && !connected;
            _mainForm.ConnectionComBusAddressEnabled = !_locked && !_connectedIp && !_readStarted && !connected;
            _mainForm.ConnectionComComNumberEnabled = !_locked && !_connectedIp && !_readStarted && !connected;
            _mainForm.ConnectionComBaudRateEnabled = !_locked && !_connectedIp && !_readStarted && !connected;
            _mainForm.ConnectionComConnectEnabled = !_locked && !_connectedIp && !_readStarted && !connected;
            _mainForm.ConnectionComDisconnectEnabled = !_locked && !_connectedIp && !_readStarted && connected;

            _mainForm.ConnectionIpIdEnabled = !_locked && !_connectedCom && !_readStarted && !connected;
            _mainForm.ConnectionIpProtocolEnabled = !_locked && !_connectedCom && !_readStarted && !connected;
            _mainForm.ConnectionIpHostNameEnabled = !_locked && !_connectedCom && !_readStarted && !connected;
            _mainForm.ConnectionIpSocketPortEnabled = !_locked && !_connectedCom && !_readStarted && !connected;
            _mainForm.ConnectionIpConnectEnabled = !_locked && !_connectedCom && !_readStarted && !connected;
            _mainForm.ConnectionIpDisconnectEnabled = !_locked && !_connectedCom && !_readStarted && connected;

            _mainForm.SettingHwPowerEnabled = !_locked && !_readStarted && connected;
            _mainForm.SettingHwTagFilterEnabled = !_locked && !_readStarted && connected;
            _mainForm.SettingHwBuzzerEnabled = !_locked && !_readStarted && connected;
            _mainForm.SettingHwAdvancedEnabled = !_locked && !_readStarted && connected;

            _mainForm.SettingSwActivatorEnabled = !_locked && !_readStarted && connected;
            _mainForm.SettingSwTagFilterEnabled = !_locked && !_readStarted && connected;
            _mainForm.SettingSwRssi1Enabled = !_locked && !_readStarted && connected;
            _mainForm.SettingSwRssi2Enabled = !_locked && !_readStarted && connected;
            _mainForm.SettingSwSoundEnabled = !_locked && !_readStarted && connected;
            _mainForm.SettingSwMysqlEnabled = !_locked && !_readStarted && connected;

            _mainForm.ReadStartEnabled = !_locked && !_readStarted && connected;
            _mainForm.ReadStopEnabled = !_locked && _readStarted && connected;
            _mainForm.ReadResetEnabled = !_locked && !_readStarted && connected;

            if (!_locked && !connected)
            {
                _mainForm.SettingHwPowerIndex = -1;
                _mainForm.SettingHwTagFilterIndex = -1;
                _mainForm.SettingHwBuzzerIndex = -1;

                _mainForm.SettingSwActivatorIndex = -1;
                _mainForm.SettingSwTagFilterIndex = -1;
                _mainForm.SettingSwRssi1Index = -1;
                _mainForm.SettingSwRssi2Index = -1;
                _mainForm.SettingSwSoundChecked = false;
                _mainForm.SettingSwMysqlChecked = false;
            }

            Debug.WriteLine($"Main Refresh - connected: {connected}, locked: {_locked}, connectedCom: {_connectedCom}, connectedIp: {_connectedIp}, startedRead: {_readStarted}");
        }
    }
}
