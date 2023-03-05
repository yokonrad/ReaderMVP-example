using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace RFID
{
    #region structs
    internal readonly struct StructMinMax
    {
        private readonly int _min;
        private readonly int _max;

        internal StructMinMax(int min, int max)
        {
            _min = min;
            _max = max;
        }

        internal bool CheckKey(int key) => GetKeys().Length > key && key >= 0;

        internal bool CheckKey(int key, int[] except) => CheckKey(key) && !except.Contains(key);

        internal bool CheckValue(object value) => GetValues().Contains(value);

        internal bool CheckValue(object value, object[] except) => CheckValue(value) && !except.Contains(value);

        internal int GetMin() => _min;

        internal int GetMax() => _max;

        internal int GetKey(object value) => Array.IndexOf(GetValues(), value);

        internal int[] GetKeys() => Enumerable.Range(0, GetValues().Length).ToArray();

        internal object GetValue(int key) => GetValues().ElementAt(key);

        internal object[] GetValues() => Enumerable.Range(_min, _max - _min + 1).Cast<object>().ToArray();
    }

    internal readonly struct StructArray
    {
        private readonly object[] _array;

        internal StructArray(object[] array)
        {
            _array = array;
        }

        internal bool CheckKey(int key) => _array.Length > key && key >= 0;

        internal bool CheckKey(int key, int[] except) => CheckKey(key) && !except.Contains(key);

        internal bool CheckValue(object value) => _array.Contains(value);

        internal bool CheckValue(object value, object[] except) => CheckValue(value) && !except.Contains(value);

        internal int GetKey(object value) => Array.IndexOf(_array, value);

        internal int[] GetKeys() => Enumerable.Range(0, _array.Length).ToArray();

        internal object GetValue(int key) => _array.ElementAt(key);

        internal object[] GetValues() => _array;
    }

    public struct StructTransponder
    {
        private int _activator;
        private uint _number;
        private double _value;
        private int _rssi1;
        private int _rssi2;
        private bool _battery;

        internal StructTransponder(int activator, uint number, double value, int rssi1, int rssi2, bool battery)
        {
            _activator = activator;
            _number = number;
            _value = value;
            _rssi1 = rssi1;
            _rssi2 = rssi2;
            _battery = battery;
        }

        public int Activator
        {
            get => _activator;
            set => _activator = value;
        }

        public uint Number
        {
            get => _number;
            set => _number = value;
        }

        public double Value
        {
            get => _value;
            set => _value = value;
        }

        public int Rssi1
        {
            get => _rssi1;
            set => _rssi1 = value;
        }

        public int Rssi2
        {
            get => _rssi2;
            set => _rssi2 = value;
        }

        public bool Battery
        {
            get => _battery;
            set => _battery = value;
        }
    }
    #endregion

    internal class Rfid
    {
        // All methods here are cutted out due to the commercial usage.

        private static bool ValidateIPv4(string value)
        {
            if (!string.IsNullOrWhiteSpace(value))
            {
                var valuesSplit = value.Split('.');

                if (valuesSplit.Length == 4)
                {
                    return valuesSplit.All(r => byte.TryParse(r, out byte tempForParsing));
                }
            }

            return false;
        }

        internal static StructMinMax ConnectComBusAddressArray() => new(0, 255);

        internal static StructArray ConnectComComNumberArray() => new(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
        });

        internal static StructArray ConnectComBaudRateArray() => new(new object[] {
            4800,
            9600,
            19200,
            38400,
            57600,
            115200,
        });

        internal static StructArray ConnectIpProtocolArray() => new(new object[] {
            "TCP",
            "UDP",
        });

        internal static bool ConnectIpHostNameCheck(string value) => ValidateIPv4(value);

        internal static StructMinMax ConnectIpSocketPortArray() => new(1024, 65535);

        internal static StructArray RebootArray() => new(new object[] {
            "Normal mode",
            "Boot mode",
        });

        internal static StructArray LangArray() => new(new object[] {
            "Simplified Chinese (ZH_CN)",
            "Chinese Traditional (ZH_TW)",
            "English (EN_US)",
        });

        internal static StructMinMax SysInfName() => new(1, 8);

        internal static StructMinMax SysInfModel() => new(1, 6);

        internal static StructMinMax SysInfSerialNumber() => new(1, 8);

        internal static StructMinMax CommunicatParaBusAddress() => new(0, 255);

        internal static StructArray CommunicatParaRs232BaudRate() => new(new object[] {
            4800,
            9600,
            19200,
            38400,
            57600,
            115200,
        });

        internal static StructArray CommunicatParaRs485BaudRate() => new(new object[] {
            4800,
            9600,
            19200,
            38400,
            57600,
            115200,
        });

        internal static StructMinMax NetParaMacAddress() => new(12, 12);

        internal static StructMinMax NetParaIpAddress() => new(7, 15);

        internal static StructMinMax NetParaMask() => new(7, 15);

        internal static StructMinMax NetParaGateway() => new(7, 15);

        internal static StructMinMax NetParaSocketPortTcp() => new(1024, 65535);

        internal static StructMinMax NetParaSocketPortUdp() => new(1024, 65535);

        internal static StructMinMax TagOpParaStatus() => new(0, 1);

        internal static StructMinMax TagOpParaTime() => new(1, 255);

        internal static StructArray YRFParaArray() => new(new object[] {
            "2405 MHz",
            "2410 MHz",
            "2415 MHz",
            "2420 MHz",
            "2425 MHz",
            "2430 MHz",
            "2435 MHz",
            "2440 MHz",
            "2445 MHz",
            "2450 MHz",
            "2455 MHz",
            "2460 MHz",
            "2465 MHz",
            "2470 MHz",
            "2475 MHz",
            "2480 MHz",
            "2485 MHz",
            "2490 MHz",
            "2495 MHz",
            "2500 MHz",
            "2505 MHz",
            "2510 MHz",
            "2515 MHz",
            "2520 MHz",
        });

        internal static StructArray YAntennaPowerArray() => new(new object[] {
            "0 dB",
            "-2 dB",
            "-4 dB",
            "-6 dB",
            "-8 dB",
            "-10 dB",
            "-12 dB",
            "-14 dB",
            "-16 dB",
            "-18 dB",
            "-20 dB",
            "-22 dB",
            "-24 dB",
            "-26 dB",
            "-28 dB",
            "-30 dB",
        });

        internal static StructArray YBuzzerArray() => new(new object[] {
            "Off",
            "On",
        });

        internal static StructMinMax IOPulseWidthBuzzer() => new(1, 255);
    }
}