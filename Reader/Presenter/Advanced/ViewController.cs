using Reader.View;
using System.Diagnostics;

namespace Reader.Presenter.Advanced
{
    public interface IViewController
    {
        bool IsEditable { get; set; }
        bool IsLocked { get; }

        Task<bool> Data(int index);
        Task Refresh(int index, bool lockUI = false);
    }

    public class ViewController : IViewController
    {
        private readonly IAdvancedForm _advancedForm;
        private readonly CancellationToken _ct;

        private bool _locked = false;
        private bool _editable = false;

        public ViewController(IAdvancedForm advancedForm, CancellationToken ct)
        {
            _advancedForm = advancedForm;
            _ct = ct;
        }

        public bool IsLocked => _locked;
        public bool IsEditable
        {
            get { return _editable; }
            set { _editable = value; }
        }

        public async Task<bool> Data(int index)
        {
            var connected = await RFID.Api.CheckHwConnection();

            if (!connected)
            {
                _advancedForm.Close();
            }

            if (index == 0)
            {
                var tasksString = new List<Func<Task<string?>>>
                {
                    () => RFID.Api.GetName(),
                    () => RFID.Api.GetModel(),
                    () => RFID.Api.GetSerialNumber(),
                };
                var resultsString = new List<string?>();

                var tasksInt = new List<Func<Task<int?>>>
                {
                    () => RFID.Api.GetBuzzerKey(),
                    () => RFID.Api.GetBuzzerWidthKey(),
                    () => RFID.Api.GetFrequencyKey(),
                    () => RFID.Api.GetPowerKey(),
                    () => RFID.Api.GetTagFilterKey(),
                };
                var resultsInt = new List<int?>();

                foreach (var task in tasksString)
                {
                    if (!_ct.IsCancellationRequested)
                    {
                        resultsString.Add(await task());
                    }
                }

                foreach (var task in tasksInt)
                {
                    if (!_ct.IsCancellationRequested)
                    {
                        resultsInt.Add(await task());
                    }
                }

                if (resultsString.Count == tasksString.Count && resultsInt.Count == tasksInt.Count)
                {
                    _advancedForm.NameInputText = resultsString.ElementAt(0) ?? string.Empty;
                    _advancedForm.ModelInputText = resultsString.ElementAt(1) ?? string.Empty;
                    _advancedForm.SerialNumberInputText = resultsString.ElementAt(2) ?? string.Empty;
                    _advancedForm.BuzzerInputIndex = resultsInt.ElementAt(0) ?? -1;
                    _advancedForm.BuzzerWidthInputIndex = resultsInt.ElementAt(1) ?? -1;
                    _advancedForm.FrequencyInputIndex = resultsInt.ElementAt(2) ?? -1;
                    _advancedForm.PowerInputIndex = resultsInt.ElementAt(3) ?? -1;
                    _advancedForm.TagFilterInputIndex = resultsInt.ElementAt(4) ?? -1;

                    return true;
                }
            }
            else if (index == 1)
            {
                var tasksInt = new List<Func<Task<int?>>>
                {
                    () => RFID.Api.GetBusAddressKey(),
                    () => RFID.Api.GetRs232BaudRateKey(),
                    () => RFID.Api.GetSocketPortTcp(),
                    () => RFID.Api.GetSocketPortUdp(),
                };
                var resultsInt = new List<int?>();

                var tasksString = new List<Func<Task<string?>>>
                {
                    () => RFID.Api.GetMacAddress(),
                    () => RFID.Api.GetIpAddress(),
                    () => RFID.Api.GetMask(),
                    () => RFID.Api.GetGateway(),
                };
                var resultsString = new List<string?>();

                foreach (var task in tasksInt)
                {
                    if (!_ct.IsCancellationRequested)
                    {
                        resultsInt.Add(await task());
                    }
                }

                foreach (var task in tasksString)
                {
                    if (!_ct.IsCancellationRequested)
                    {
                        resultsString.Add(await task());
                    }
                }

                if (resultsInt.Count == tasksInt.Count && resultsString.Count == tasksString.Count)
                {
                    _advancedForm.BusAddressInputIndex = resultsInt.ElementAt(0) ?? -1;
                    _advancedForm.Rs232BaudRateInputIndex = resultsInt.ElementAt(1) ?? -1;
                    _advancedForm.MacAddressInputText = resultsString.ElementAt(0) ?? string.Empty;
                    _advancedForm.IpAddressInputText = resultsString.ElementAt(1) ?? string.Empty;
                    _advancedForm.MaskInputText = resultsString.ElementAt(2) ?? string.Empty;
                    _advancedForm.GatewayInputText = resultsString.ElementAt(3) ?? string.Empty;
                    _advancedForm.SocketPortTcpInputText = Convert.ToString(resultsInt.ElementAt(2)) ?? string.Empty;
                    _advancedForm.SocketPortUdpInputText = Convert.ToString(resultsInt.ElementAt(3)) ?? string.Empty;

                    return true;
                }
            }
            else
            {
                throw new Exception("Not implemented index");
            }

            return false;
        }

        public async Task Refresh(int index, bool lockUI = false)
        {
            _locked = lockUI;

            var connected = await RFID.Api.CheckSwConnection();

            if (!connected)
            {
                _advancedForm.Close();
            }

            _advancedForm.TabControlEnabled = !_locked && connected;

            if (index == 0)
            {
                _advancedForm.NameInputEnabled = !_locked && _editable && connected;
                _advancedForm.NameButtonEnabled = !_locked && _editable && connected;

                _advancedForm.ModelInputEnabled = !_locked && _editable && connected;
                _advancedForm.ModelButtonEnabled = !_locked && _editable && connected;

                _advancedForm.SerialNumberInputEnabled = !_locked && _editable && connected;
                _advancedForm.SerialNumberButtonEnabled = !_locked && _editable && connected;

                _advancedForm.BuzzerInputEnabled = !_locked && _editable && connected;
                _advancedForm.BuzzerButtonEnabled = !_locked && _editable && connected;

                _advancedForm.BuzzerWidthInputEnabled = !_locked && _editable && connected;
                _advancedForm.BuzzerWidthButtonEnabled = !_locked && _editable && connected;

                _advancedForm.FrequencyInputEnabled = !_locked && _editable && connected;
                _advancedForm.FrequencyButtonEnabled = !_locked && _editable && connected;

                _advancedForm.PowerInputEnabled = !_locked && _editable && connected;
                _advancedForm.PowerButtonEnabled = !_locked && _editable && connected;

                _advancedForm.TagFilterInputEnabled = !_locked && _editable && connected;
                _advancedForm.TagFilterButtonEnabled = !_locked && _editable && connected;

                _advancedForm.RebootButtonEnabled = !_locked && _editable && connected;
            }
            else if (index == 1)
            {
                _advancedForm.BusAddressInputEnabled = !_locked && _editable && connected;
                _advancedForm.BusAddressButtonEnabled = !_locked && _editable && connected;

                _advancedForm.Rs232BaudRateInputEnabled = !_locked && _editable && connected;
                _advancedForm.Rs232BaudRateButtonEnabled = !_locked && _editable && connected;

                _advancedForm.MacAddressInputEnabled = !_locked && _editable && connected;
                _advancedForm.MacAddressButtonEnabled = !_locked && _editable && connected;

                _advancedForm.IpAddressInputEnabled = !_locked && _editable && connected;
                _advancedForm.IpAddressButtonEnabled = !_locked && _editable && connected;

                _advancedForm.MaskInputEnabled = !_locked && _editable && connected;
                _advancedForm.MaskButtonEnabled = !_locked && _editable && connected;

                _advancedForm.GatewayInputEnabled = !_locked && _editable && connected;
                _advancedForm.GatewayButtonEnabled = !_locked && _editable && connected;

                _advancedForm.SocketPortTcpInputEnabled = !_locked && _editable && connected;
                _advancedForm.SocketPortTcpButtonEnabled = !_locked && _editable && connected;

                _advancedForm.SocketPortUdpInputEnabled = !_locked && _editable && connected;
                _advancedForm.SocketPortUdpButtonEnabled = !_locked && _editable && connected;
            }

            Debug.WriteLine($"Advanced RefreshUI, connected: {connected}, locked: {_locked}, editable: {_editable}");
        }
    }
}
