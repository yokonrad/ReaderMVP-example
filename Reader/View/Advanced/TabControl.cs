namespace Reader.View
{
    public partial class AdvancedForm
    {
        public event EventHandler? TabControl_IndexChanged;

        public bool TabControlEnabled
        {
            set { TabControl.Enabled = value; }
        }

        public int TabControlIndex
        {
            get { return TabControl.SelectedIndex; }
        }

        private void SetTabControlUI()
        {
            TabControl.SelectedIndexChanged += delegate { TabControl_IndexChanged?.Invoke(this, EventArgs.Empty); };

            TabControlPage1.Text = Lang.Advanced.TabControlPage1;
            TabControlPage2.Text = Lang.Advanced.TabControlPage2;
        }

        private void SetTabControlTabPage1UI()
        {
            SetNameUI();
            SetModelUI();
            SetSerialNumberUI();
            SetBuzzerUI();
            SetBuzzerWidthUI();
            SetFrequencyUI();
            SetPowerUI();
            SetTagFilterUI();
            SetRebootUI();
        }

        private void SetTabControlTabPage2UI()
        {
            SetBusAddressUI();
            SetRs232BaudRateUI();
            SetMacAddressUI();
            SetIpAddressUI();
            SetMaskUI();
            SetGatewayUI();
            SetSocketPortTcpUI();
            SetSocketPortUdpUI();
        }
    }
}
