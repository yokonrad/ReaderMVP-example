namespace Reader.View
{
    public partial class MainForm
    {
        private void ConnectionIpId_DrawItem(object sender, DrawItemEventArgs e) => Helper.ComboBox_DrawItem(sender, e);
        private void ConnectionIpProtocol_DrawItem(object sender, DrawItemEventArgs e) => Helper.ComboBox_DrawItem(sender, e);

        public event EventHandler? ConnectionIpId_SelectedIndexChanged;
        public event EventHandler? ConnectionIpConnect_Click;
        public event EventHandler? ConnectionIpDisconnect_Click;

        public bool ConnectionIpIdEnabled
        {
            set { ConnectionIpId.Enabled = value; }
        }

        public int ConnectionIpIdIndex
        {
            get { return ConnectionIpId.SelectedIndex; }
        }

        public bool ConnectionIpProtocolEnabled
        {
            set { ConnectionIpProtocol.Enabled = value; }
        }

        public int ConnectionIpProtocolIndex
        {
            get { return ConnectionIpProtocol.SelectedIndex; }
            set { ConnectionIpProtocol.SelectedIndex = value; }
        }

        public string ConnectionIpProtocolText
        {
            get { return ConnectionIpProtocol.Text; }
        }

        public bool ConnectionIpHostNameEnabled
        {
            set { ConnectionIpHostName.Enabled = value; }
        }

        public string ConnectionIpHostNameText
        {
            get { return ConnectionIpHostName.Text; }
            set { ConnectionIpHostName.Text = value; }
        }

        public bool ConnectionIpSocketPortEnabled
        {
            set { ConnectionIpSocketPort.Enabled = value; }
        }

        public string ConnectionIpSocketPortText
        {
            get { return ConnectionIpSocketPort.Text; }
            set { ConnectionIpSocketPort.Text = value; }
        }

        public bool ConnectionIpConnectEnabled
        {
            set { ConnectionIpConnect.Enabled = value; }
        }

        public bool ConnectionIpDisconnectEnabled
        {
            set { ConnectionIpDisconnect.Enabled = value; }
        }

        private void ConnectionIpUI()
        {
            ConnectionIpId.SelectedIndexChanged += delegate { ConnectionIpId_SelectedIndexChanged?.Invoke(this, EventArgs.Empty); };
            ConnectionIpConnect.Click += delegate { ConnectionIpConnect_Click?.Invoke(this, EventArgs.Empty); };
            ConnectionIpDisconnect.Click += delegate { ConnectionIpDisconnect_Click?.Invoke(this, EventArgs.Empty); };

            ConnectionIpContainer.Text = Lang.Main.ConnectionIpContainer;
            ConnectionIpConnect.Text = Lang.Main.ConnectionIpConnect;
            ConnectionIpDisconnect.Text = Lang.Main.ConnectionIpDisconnect;
        }

        public void SetConnectionIpIdItems(object[] items)
        {
            ConnectionIpId.BeginUpdate();
            foreach (var item in items) ConnectionIpId.Items.Add(item);
            ConnectionIpId.EndUpdate();
        }

        public void SetConnectionIpProtocolItems(object[] items)
        {
            ConnectionIpProtocol.BeginUpdate();
            foreach (var item in items) ConnectionIpProtocol.Items.Add(item);
            ConnectionIpProtocol.EndUpdate();
        }
    }
}
