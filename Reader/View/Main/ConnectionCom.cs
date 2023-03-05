namespace Reader.View
{
    public partial class MainForm
    {
        private void ConnectionComId_DrawItem(object sender, DrawItemEventArgs e) => Helper.ComboBox_DrawItem(sender, e);
        private void ConnectionComBusAddress_DrawItem(object sender, DrawItemEventArgs e) => Helper.ComboBox_DrawItem(sender, e);
        private void ConnectionComComNumber_DrawItem(object sender, DrawItemEventArgs e) => Helper.ComboBox_DrawItem(sender, e);
        private void ConnectionComBaudRate_DrawItem(object sender, DrawItemEventArgs e) => Helper.ComboBox_DrawItem(sender, e);

        public event EventHandler? ConnectionComId_SelectedIndexChanged;
        public event EventHandler? ConnectionComConnect_Click;
        public event EventHandler? ConnectionComDisconnect_Click;

        public bool ConnectionComIdEnabled
        {
            set { ConnectionComId.Enabled = value; }
        }

        public int ConnectionComIdIndex
        {
            get { return ConnectionComId.SelectedIndex; }
        }

        public bool ConnectionComBusAddressEnabled
        {
            set { ConnectionComBusAddress.Enabled = value; }
        }

        public int ConnectionComBusAddressIndex
        {
            get { return ConnectionComBusAddress.SelectedIndex; }
            set { ConnectionComBusAddress.SelectedIndex = value; }
        }

        public string ConnectionComBusAddressText
        {
            get { return ConnectionComBusAddress.Text; }
        }

        public bool ConnectionComComNumberEnabled
        {
            set { ConnectionComComNumber.Enabled = value; }
        }

        public int ConnectionComComNumberIndex
        {
            get { return ConnectionComComNumber.SelectedIndex; }
            set { ConnectionComComNumber.SelectedIndex = value; }
        }

        public string ConnectionComComNumberText
        {
            get { return ConnectionComComNumber.Text; }
        }

        public bool ConnectionComBaudRateEnabled
        {
            set { ConnectionComBaudRate.Enabled = value; }
        }

        public int ConnectionComBaudRateIndex
        {
            get { return ConnectionComBaudRate.SelectedIndex; }
            set { ConnectionComBaudRate.SelectedIndex = value; }
        }

        public string ConnectionComBaudRateText
        {
            get { return ConnectionComBaudRate.Text; }
        }

        public bool ConnectionComConnectEnabled
        {
            set { ConnectionComConnect.Enabled = value; }
        }

        public bool ConnectionComDisconnectEnabled
        {
            set { ConnectionComDisconnect.Enabled = value; }
        }

        private void ConnectionComUI()
        {
            ConnectionComId.SelectedIndexChanged += delegate { ConnectionComId_SelectedIndexChanged?.Invoke(this, EventArgs.Empty); };
            ConnectionComConnect.Click += delegate { ConnectionComConnect_Click?.Invoke(this, EventArgs.Empty); };
            ConnectionComDisconnect.Click += delegate { ConnectionComDisconnect_Click?.Invoke(this, EventArgs.Empty); };

            ConnectionComContainer.Text = Lang.Main.ConnectionComContainer;
            ConnectionComConnect.Text = Lang.Main.ConnectionComConnect;
            ConnectionComDisconnect.Text = Lang.Main.ConnectionComDisconnect;
        }

        public void SetConnectionComIdItems(object[] items)
        {
            ConnectionComId.BeginUpdate();
            foreach (var item in items) ConnectionComId.Items.Add(item);
            ConnectionComId.EndUpdate();
        }

        public void SetConnectionComBusAddressItems(object[] items)
        {
            ConnectionComBusAddress.BeginUpdate();
            foreach (var item in items) ConnectionComBusAddress.Items.Add(item);
            ConnectionComBusAddress.EndUpdate();
        }

        public void SetConnectionComComNumberItems(object[] items)
        {
            ConnectionComComNumber.BeginUpdate();
            foreach (var item in items) ConnectionComComNumber.Items.Add(item);
            ConnectionComComNumber.EndUpdate();
        }

        public void SetConnectionComBaudRateItems(object[] items)
        {
            ConnectionComBaudRate.BeginUpdate();
            foreach (var item in items) ConnectionComBaudRate.Items.Add(item);
            ConnectionComBaudRate.EndUpdate();
        }
    }
}
