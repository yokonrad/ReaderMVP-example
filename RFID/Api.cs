namespace RFID
{
    public class Api
    {
        // All methods here are async Tasks (wrapped in the Proxy.cs). They are cutted out due to the commercial usage.

        #region CheckHwConnection
        public static async Task<bool> CheckHwConnection()
        {
            return await Task.FromResult(true);
        }
        #endregion

        #region CheckSwConnection
        public static async Task<bool> CheckSwConnection()
        {
            return await Task.FromResult(true);
        }
        #endregion

        #region ClearConnection
        public static async Task<bool> ClearConnection()
        {
            return await Task.FromResult(true);
        }
        #endregion



        #region ConnectCom
        public static object[] ConnectComBusAddressItems() => Rfid.ConnectComBusAddressArray().GetValues();

        public static object[] ConnectComComNumberItems() => Rfid.ConnectComComNumberArray().GetValues();

        public static object[] ConnectComBaudRateItems() => Rfid.ConnectComBaudRateArray().GetValues();

        public static async Task<bool> ConnectCom(int busAddress, string comNumber, int baudRate)
        {
            return await Task.FromResult(true);
        }
        #endregion

        #region ConnectIp
        public static object[] ConnectIpProtocolItems() => Rfid.ConnectIpProtocolArray().GetValues();

        public static bool ConnectIpHostNameCheck(string value) => Rfid.ConnectIpHostNameCheck(value);

        public static int ConnectIpSocketPortMin() => Rfid.ConnectIpSocketPortArray().GetMin();

        public static int ConnectIpSocketPortMax() => Rfid.ConnectIpSocketPortArray().GetMax();

        public static async Task<bool> ConnectIp(string protocol, string hostName, int socketPort)
        {
            return await Task.FromResult(true);
        }
        #endregion

        #region Disconnect
        public static async Task<bool> Disconnect()
        {
            return await Task.FromResult(true);
        }
        #endregion



        #region Reboot
        public static object[] RebootItems() => Rfid.RebootArray().GetValues();

        public static async Task<bool> Reboot()
        {
            return await Task.FromResult(true);
        }
        #endregion

        #region Reconnect
        public static async Task<bool> Reconnect()
        {
            return await Task.FromResult(true);
        }
        #endregion

        #region Lang
        public static object[] LangItems() => Rfid.LangArray().GetValues();

        public static async Task<bool> Lang()
        {
            return await Task.FromResult(true);
        }
        #endregion



        #region Copyright
        public static async Task<string?> Copyright()
        {
            return await Task.FromResult<string?>(string.Empty);
        }
        #endregion

        #region ErrorMessage
        public static async Task<string?> ErrorMessage()
        {
            return await Task.FromResult<string?>(string.Empty);
        }
        #endregion

        #region ErrorCode
        public static async Task<int?> ErrorCode()
        {
            return await Task.FromResult<int?>(0);
        }
        #endregion



        #region Name
        public static int GetNameMinLength() => Rfid.SysInfName().GetMin();

        public static int GetNameMaxLength() => Rfid.SysInfName().GetMax();

        public static async Task<string?> GetName()
        {
            return await Task.FromResult<string?>(string.Empty);
        }

        public static async Task<bool> SetName(string value)
        {
            return await Task.FromResult(true);
        }
        #endregion

        #region Model
        public static int GetModelMinLength() => Rfid.SysInfModel().GetMin();

        public static int GetModelMaxLength() => Rfid.SysInfModel().GetMax();

        public static async Task<string?> GetModel()
        {
            return await Task.FromResult<string?>(string.Empty);
        }

        public static async Task<bool> SetModel(string value)
        {
            return await Task.FromResult(true);
        }
        #endregion

        #region SerialNumber
        public static int GetSerialNumberMinLength() => Rfid.SysInfSerialNumber().GetMin();

        public static int GetSerialNumberMaxLength() => Rfid.SysInfSerialNumber().GetMax();

        public static async Task<string?> GetSerialNumber()
        {
            return await Task.FromResult<string?>(string.Empty);
        }

        public static async Task<bool> SetSerialNumber(string value)
        {
            return await Task.FromResult(true);
        }
        #endregion

        #region FirmwareVersion
        public static async Task<string?> GetFirmwareVersion()
        {
            return await Task.FromResult<string?>(string.Empty);
        }
        #endregion

        #region HardwareVersion
        public static async Task<string?> GetHardwareVersion()
        {
            return await Task.FromResult<string?>(string.Empty);
        }
        #endregion



        #region BusAddress
        public static object[] GetBusAddressItems() => Rfid.CommunicatParaBusAddress().GetValues();

        public static async Task<int?> GetBusAddressKey()
        {
            return await Task.FromResult<int?>(0);
        }

        public static async Task<bool> SetBusAddressKey(int key)
        {
            return await Task.FromResult(true);
        }
        #endregion

        #region Rs232BaudRate
        public static object[] GetRs232BaudRateItems() => Rfid.CommunicatParaRs232BaudRate().GetValues();

        public static async Task<int?> GetRs232BaudRateKey()
        {
            return await Task.FromResult<int?>(0);
        }

        public static async Task<string?> GetRs232BaudRateValue()
        {
            return await Task.FromResult<string?>(string.Empty);
        }

        public static async Task<bool> SetRs232BaudRateKey(int key)
        {
            return await Task.FromResult(true);
        }

        public static async Task<bool> SetRs232BaudRateValue(int value)
        {
            return await Task.FromResult(true);
        }
        #endregion

        #region Rs485BaudRate
        public static object[] GetRs485BaudRateItems() => Rfid.CommunicatParaRs485BaudRate().GetValues();

        public static async Task<int?> GetRs485BaudRateKey()
        {
            return await Task.FromResult<int?>(0);
        }

        public static async Task<string?> GetRs485BaudRateValue()
        {
            return await Task.FromResult<string?>(string.Empty);
        }

        public static async Task<bool> SetRs485BaudRateKey(int key)
        {
            return await Task.FromResult(true);
        }

        public static async Task<bool> SetRs485BaudRateValue(int value)
        {
            return await Task.FromResult(true);
        }
        #endregion



        #region MacAddress
        public static int GetMacAddressMinLength() => Rfid.NetParaMacAddress().GetMin();

        public static int GetMacAddressMaxLength() => Rfid.NetParaMacAddress().GetMax();

        public static async Task<string?> GetMacAddress()
        {
            return await Task.FromResult<string?>(string.Empty);
        }

        public static async Task<bool> SetMacAddress(string value)
        {
            return await Task.FromResult(true);
        }
        #endregion

        #region IpAddress
        public static int GetIpAddressMinLength() => Rfid.NetParaIpAddress().GetMin();

        public static int GetIpAddressMaxLength() => Rfid.NetParaIpAddress().GetMax();

        public static async Task<string?> GetIpAddress()
        {
            return await Task.FromResult<string?>(string.Empty);
        }

        public static async Task<bool> SetIpAddress(string value)
        {
            return await Task.FromResult(true);
        }
        #endregion

        #region Mask
        public static int GetMaskMinLength() => Rfid.NetParaMask().GetMin();

        public static int GetMaskMaxLength() => Rfid.NetParaMask().GetMax();

        public static async Task<string?> GetMask()
        {
            return await Task.FromResult<string?>(string.Empty);
        }

        public static async Task<bool> SetMask(string value)
        {
            return await Task.FromResult(true);
        }
        #endregion

        #region Gateway
        public static int GetGatewayMinLength() => Rfid.NetParaGateway().GetMin();

        public static int GetGatewayMaxLength() => Rfid.NetParaGateway().GetMax();

        public static async Task<string?> GetGateway()
        {
            return await Task.FromResult<string?>(string.Empty);
        }

        public static async Task<bool> SetGateway(string value)
        {
            return await Task.FromResult(true);
        }
        #endregion

        #region SocketPortTcp
        public static int GetSocketPortTcpMin() => Rfid.NetParaSocketPortTcp().GetMin();

        public static int GetSocketPortTcpMax() => Rfid.NetParaSocketPortTcp().GetMax();

        public static async Task<int?> GetSocketPortTcp()
        {
            return await Task.FromResult<int?>(0);
        }

        public static async Task<bool> SetSocketPortTcp(int value)
        {
            return await Task.FromResult(true);
        }
        #endregion

        #region SocketPortUdp
        public static int GetSocketPortUdpMin() => Rfid.NetParaSocketPortUdp().GetMin();

        public static int GetSocketPortUdpMax() => Rfid.NetParaSocketPortUdp().GetMax();

        public static async Task<int?> GetSocketPortUdp()
        {
            return await Task.FromResult<int?>(0);
        }

        public static async Task<bool> SetSocketPortUdp(int value)
        {
            return await Task.FromResult(true);
        }
        #endregion



        #region TagFilter
        public static object[] GetTagFilterItems() => Enumerable.Range(Rfid.TagOpParaStatus().GetMin(), Rfid.TagOpParaTime().GetMax() + 1).Cast<object>().ToArray();

        public static async Task<int?> GetTagFilterKey()
        {
            return await Task.FromResult<int?>(0);
        }

        public static async Task<bool> SetTagFilterKey(int key)
        {
            return await Task.FromResult(true);
        }
        #endregion

        #region Frequency
        public static object[] GetFrequencyItems() => Rfid.YRFParaArray().GetValues();

        public static async Task<int?> GetFrequencyKey()
        {
            return await Task.FromResult<int?>(0);
        }

        public static async Task<string?> GetFrequencyValue()
        {
            return await Task.FromResult<string?>(string.Empty);
        }

        public static async Task<bool> SetFrequencyKey(int key)
        {
            return await Task.FromResult(true);
        }

        public static async Task<bool> SetFrequencyValue(string value)
        {
            return await Task.FromResult(true);
        }
        #endregion

        #region Power
        public static object[] GetPowerItems() => Rfid.YAntennaPowerArray().GetValues();

        public static async Task<int?> GetPowerKey()
        {
            return await Task.FromResult<int?>(0);
        }

        public static async Task<string?> GetPowerValue()
        {
            return await Task.FromResult<string?>(string.Empty);
        }

        public static async Task<bool> SetPowerKey(int key)
        {
            return await Task.FromResult(true);
        }

        public static async Task<bool> SetPowerValue(string value)
        {
            return await Task.FromResult(true);
        }
        #endregion

        #region Buzzer
        public static object[] GetBuzzerItems() => Rfid.YBuzzerArray().GetValues();

        public static async Task<int?> GetBuzzerKey()
        {
            return await Task.FromResult<int?>(0);
        }

        public static async Task<bool> SetBuzzerKey(int key)
        {
            return await Task.FromResult(true);
        }
        #endregion

        #region BuzzerWidth
        public static object[] GetBuzzerWidthItems() => Rfid.IOPulseWidthBuzzer().GetValues();

        public static async Task<int?> GetBuzzerWidthKey()
        {
            return await Task.FromResult<int?>(0);
        }

        public static async Task<int?> GetBuzzerWidthValue()
        {
            return await Task.FromResult<int?>(0);
        }

        public static async Task<bool> SetBuzzerWidthKey(int key)
        {
            return await Task.FromResult(true);
        }

        public static async Task<bool> SetBuzzerWidthValue(int value)
        {
            return await Task.FromResult(true);
        }
        #endregion



        #region ReadStart
        public static async Task<bool> ReadStart()
        {
            return await Task.FromResult(true);
        }
        #endregion

        #region ReadStop
        public static async Task<bool> ReadStop()
        {
            return await Task.FromResult(true);
        }
        #endregion



        #region ReadTransponder1
        public static async Task<StructTransponder?> ReadTransponder1()
        {
            return await Task.FromResult<StructTransponder>(new StructTransponder());
        }
        #endregion

        #region ReadTransponder2
        public static async Task<StructTransponder?> ReadTransponder2()
        {
            return await Task.FromResult<StructTransponder>(new StructTransponder());
        }
        #endregion

        #region ReadTransponder3
        public static async Task<StructTransponder?> ReadTransponder3()
        {
            return await Task.FromResult<StructTransponder>(new StructTransponder());
        }
        #endregion

        #region ReadTransponder4
        public static async Task<StructTransponder?> ReadTransponder4()
        {
            return await Task.FromResult<StructTransponder>(new StructTransponder());
        }
        #endregion
    }
}
