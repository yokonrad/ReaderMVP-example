namespace Reader.View
{
    public interface IMainForm
    {
        bool ConnectionComBaudRateEnabled { set; }
        int ConnectionComBaudRateIndex { get; set; }
        string ConnectionComBaudRateText { get; }
        bool ConnectionComBusAddressEnabled { set; }
        int ConnectionComBusAddressIndex { get; set; }
        string ConnectionComBusAddressText { get; }
        bool ConnectionComComNumberEnabled { set; }
        int ConnectionComComNumberIndex { get; set; }
        string ConnectionComComNumberText { get; }
        bool ConnectionComConnectEnabled { set; }
        bool ConnectionComDisconnectEnabled { set; }
        bool ConnectionComIdEnabled { set; }
        int ConnectionComIdIndex { get; }
        bool ConnectionIpConnectEnabled { set; }
        bool ConnectionIpDisconnectEnabled { set; }
        bool ConnectionIpHostNameEnabled { set; }
        string ConnectionIpHostNameText { get; set; }
        bool ConnectionIpIdEnabled { set; }
        int ConnectionIpIdIndex { get; }
        bool ConnectionIpProtocolEnabled { set; }
        int ConnectionIpProtocolIndex { get; set; }
        string ConnectionIpProtocolText { get; }
        bool ConnectionIpSocketPortEnabled { set; }
        string ConnectionIpSocketPortText { get; set; }
        bool ReadResetEnabled { set; }
        bool ReadStartEnabled { set; }
        bool ReadStopEnabled { set; }
        bool SettingHwAdvancedEnabled { set; }
        bool SettingHwBuzzerEnabled { set; }
        int SettingHwBuzzerIndex { get; set; }
        int SettingHwBuzzerPrevIndex { get; set; }
        bool SettingHwPowerEnabled { set; }
        int SettingHwPowerIndex { get; set; }
        int SettingHwPowerPrevIndex { get; set; }
        bool SettingHwTagFilterEnabled { set; }
        int SettingHwTagFilterIndex { get; set; }
        int SettingHwTagFilterPrevIndex { get; set; }
        bool SettingSwActivatorEnabled { set; }
        int SettingSwActivatorIndex { get; set; }
        string SettingSwActivatorText { get; }
        bool SettingSwMysqlChecked { get; set; }
        bool SettingSwMysqlEnabled { set; }
        bool SettingSwRssi1Enabled { set; }
        int SettingSwRssi1Index { get; set; }
        string SettingSwRssi1Text { get; }
        bool SettingSwRssi2Enabled { set; }
        int SettingSwRssi2Index { get; set; }
        string SettingSwRssi2Text { get; }
        bool SettingSwSoundChecked { get; set; }
        bool SettingSwSoundEnabled { set; }
        bool SettingSwTagFilterEnabled { set; }
        int SettingSwTagFilterIndex { get; set; }
        string SettingSwTagFilterText { get; }

        event EventHandler? Load;
        event FormClosedEventHandler? FormClosed;
        event KeyEventHandler? KeyDown;
        event EventHandler? ConnectionComConnect_Click;
        event EventHandler? ConnectionComDisconnect_Click;
        event EventHandler? ConnectionComId_SelectedIndexChanged;
        event EventHandler? ConnectionIpConnect_Click;
        event EventHandler? ConnectionIpDisconnect_Click;
        event EventHandler? ConnectionIpId_SelectedIndexChanged;
        event EventHandler? ReadReset_Click;
        event EventHandler? ReadStart_Click;
        event EventHandler? ReadStop_Click;
        event EventHandler? SettingHwAdvanced_Click;
        event EventHandler? SettingHwBuzzer_SelectedIndexChanged;
        event EventHandler? SettingHwPower_SelectedIndexChanged;
        event EventHandler? SettingHwTagFilter_SelectedIndexChanged;
        event EventHandler? SettingSwSound_CheckedChanged;
        event EventHandler? SettingSwMysql_CheckedChanged;

        void LogDevice_Add(string value, bool error = false);
        void LogTransponder_Add(int activator, uint number, double value, int rssi1, int rssi2, bool battery);
        void LogTransponder_Clear();
        void LogTransponder_Update(int i, int activator, uint number, double value, int rssi1, int rssi2, bool battery);
        void OpenSettingHwAdvanced();
        void SetConnectionComBaudRateItems(object[] items);
        void SetConnectionComBusAddressItems(object[] items);
        void SetConnectionComComNumberItems(object[] items);
        void SetConnectionComIdItems(object[] items);
        void SetConnectionIpIdItems(object[] items);
        void SetConnectionIpProtocolItems(object[] items);
        void SetSettingHwBuzzerItems(object[] items);
        void SetSettingHwPowerItems(object[] items);
        void SetSettingHwTagFilterItems(object[] items);
        void SetSettingSwActivatorItems(object[] items);
        void SetSettingSwRssi1Items(object[] items);
        void SetSettingSwRssi2Items(object[] items);
        void SetSettingSwTagFilterItems(object[] items);
    }

    public partial class MainForm : Form, IMainForm
    {
        public MainForm()
        {
            InitializeComponent();

            MainFormUI();
            ConnectionComUI();
            ConnectionIpUI();
            SettingHwUI();
            SettingSwUI();
            ReadUI();
            LogDeviceUI();
            LogTransponderUI();
        }

        private void MainFormUI()
        {
            Text = Lang.Main.FormName;
        }
    }
}
