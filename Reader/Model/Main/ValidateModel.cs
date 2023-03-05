namespace Reader.Model.Main
{
    public interface IValidateModel
    {
        bool ConnectCom(string busAddress, string comNumber, string baudRate);
        bool ConnectIp(string protocol, string hostName, string socketPort);
        bool SettingHwBuzzer(int index);
        bool SettingHwPower(int index);
        bool SettingHwTagFilter(int index);
    }

    public class ValidateModel : IValidateModel
    {
        public bool ConnectCom(string busAddress, string comNumber, string baudRate)
        {
            if (Helper.IsStringEmpty(busAddress) || !Helper.IsObjectInArray(busAddress, RFID.Api.ConnectComBusAddressItems(), typeof(int))) return false;
            if (Helper.IsStringEmpty(comNumber) || !Helper.IsObjectInArray(comNumber, RFID.Api.ConnectComComNumberItems(), typeof(string))) return false;
            if (Helper.IsStringEmpty(baudRate) || !Helper.IsObjectInArray(baudRate, RFID.Api.ConnectComBaudRateItems(), typeof(int))) return false;

            return true;
        }

        public bool ConnectIp(string protocol, string hostName, string socketPort)
        {
            if (Helper.IsStringEmpty(protocol) || !Helper.IsObjectInArray(protocol, RFID.Api.ConnectIpProtocolItems(), typeof(string))) return false;
            if (Helper.IsStringEmpty(hostName) || !RFID.Api.ConnectIpHostNameCheck(hostName)) return false;
            if (Helper.IsStringEmpty(protocol) || !Helper.IsIntBetween(Convert.ToInt32(socketPort), RFID.Api.ConnectIpSocketPortMin(), RFID.Api.ConnectIpSocketPortMax())) return false;

            return true;
        }

        public bool SettingHwPower(int index) => Helper.IsIndexInArray(index, RFID.Api.GetPowerItems());

        public bool SettingHwTagFilter(int index) => Helper.IsIndexInArray(index, RFID.Api.GetTagFilterItems());

        public bool SettingHwBuzzer(int index) => Helper.IsIndexInArray(index, RFID.Api.GetBuzzerItems());
    }
}
