namespace Reader.Model.Advanced
{
    public interface IValidateModel
    {
        bool BusAddressInput(int index);
        bool BuzzerInput(int index);
        bool BuzzerWidthInput(int index);
        bool FrequencyInput(int index);
        bool GatewayInput(string value);
        bool IpAddressInput(string value);
        bool MacAddressInput(string value);
        bool MaskInput(string value);
        bool ModelInput(string value);
        bool NameInput(string value);
        bool PowerInput(int index);
        bool Rs232BaudRateInput(int index);
        bool SerialNumberInput(string value);
        bool SocketPortTcpInput(int value);
        bool SocketPortUdpInput(int value);
        bool TagFilterInput(int index);
    }

    public class ValidateModel : IValidateModel
    {
        public bool NameInput(string value) => !Helper.IsStringEmpty(value) && Helper.IsStringLengthBetween(value, RFID.Api.GetNameMinLength(), RFID.Api.GetNameMaxLength());

        public bool ModelInput(string value) => !Helper.IsStringEmpty(value) && Helper.IsStringLengthBetween(value, RFID.Api.GetModelMinLength(), RFID.Api.GetModelMaxLength());

        public bool SerialNumberInput(string value) => !Helper.IsStringEmpty(value) && Helper.IsStringLengthBetween(value, RFID.Api.GetSerialNumberMinLength(), RFID.Api.GetSerialNumberMaxLength());

        public bool BuzzerInput(int index) => Helper.IsIndexInArray(index, RFID.Api.GetBuzzerItems());

        public bool BuzzerWidthInput(int index) => Helper.IsIndexInArray(index, RFID.Api.GetBuzzerWidthItems());

        public bool FrequencyInput(int index) => Helper.IsIndexInArray(index, RFID.Api.GetFrequencyItems());

        public bool PowerInput(int index) => Helper.IsIndexInArray(index, RFID.Api.GetPowerItems());

        public bool TagFilterInput(int index) => Helper.IsIndexInArray(index, RFID.Api.GetTagFilterItems());

        public bool BusAddressInput(int index) => Helper.IsIndexInArray(index, RFID.Api.GetBusAddressItems());

        public bool Rs232BaudRateInput(int index) => Helper.IsIndexInArray(index, RFID.Api.GetRs232BaudRateItems());

        public bool MacAddressInput(string value) => !Helper.IsStringEmpty(value) && Helper.IsStringLengthBetween(value, RFID.Api.GetMacAddressMinLength(), RFID.Api.GetMacAddressMaxLength());

        public bool IpAddressInput(string value) => !Helper.IsStringEmpty(value) && Helper.IsStringLengthBetween(value, RFID.Api.GetIpAddressMinLength(), RFID.Api.GetIpAddressMaxLength());

        public bool MaskInput(string value) => !Helper.IsStringEmpty(value) && Helper.IsStringLengthBetween(value, RFID.Api.GetMaskMinLength(), RFID.Api.GetMaskMaxLength());

        public bool GatewayInput(string value) => !Helper.IsStringEmpty(value) && Helper.IsStringLengthBetween(value, RFID.Api.GetGatewayMinLength(), RFID.Api.GetGatewayMaxLength());

        public bool SocketPortTcpInput(int value) => Helper.IsIntBetween(value, RFID.Api.GetSocketPortTcpMin(), RFID.Api.GetSocketPortTcpMax());

        public bool SocketPortUdpInput(int value) => Helper.IsIntBetween(value, RFID.Api.GetSocketPortUdpMin(), RFID.Api.GetSocketPortUdpMax());
    }
}
