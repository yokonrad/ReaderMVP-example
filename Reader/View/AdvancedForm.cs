namespace Reader.View
{
    public interface IAdvancedForm
    {
        bool BusAddressButtonEnabled { set; }
        bool BusAddressInputEnabled { set; }
        int BusAddressInputIndex { get; set; }
        bool BuzzerButtonEnabled { set; }
        bool BuzzerInputEnabled { set; }
        int BuzzerInputIndex { get; set; }
        bool BuzzerWidthButtonEnabled { set; }
        bool BuzzerWidthInputEnabled { set; }
        int BuzzerWidthInputIndex { get; set; }
        bool FrequencyButtonEnabled { set; }
        bool FrequencyInputEnabled { set; }
        int FrequencyInputIndex { get; set; }
        bool GatewayButtonEnabled { set; }
        bool GatewayInputEnabled { set; }
        int GatewayInputMaxLength { set; }
        string GatewayInputText { get; set; }
        bool IpAddressButtonEnabled { set; }
        bool IpAddressInputEnabled { set; }
        int IpAddressInputMaxLength { set; }
        string IpAddressInputText { get; set; }
        bool MacAddressButtonEnabled { set; }
        bool MacAddressInputEnabled { set; }
        int MacAddressInputMaxLength { set; }
        string MacAddressInputText { get; set; }
        bool MaskButtonEnabled { set; }
        bool MaskInputEnabled { set; }
        int MaskInputMaxLength { set; }
        string MaskInputText { get; set; }
        bool ModelButtonEnabled { set; }
        bool ModelInputEnabled { set; }
        int ModelInputMaxLength { set; }
        string ModelInputText { get; set; }
        bool NameButtonEnabled { set; }
        bool NameInputEnabled { set; }
        int NameInputMaxLength { set; }
        string NameInputText { get; set; }
        bool PowerButtonEnabled { set; }
        bool PowerInputEnabled { set; }
        int PowerInputIndex { get; set; }
        bool RebootButtonEnabled { set; }
        bool Rs232BaudRateButtonEnabled { set; }
        bool Rs232BaudRateInputEnabled { set; }
        int Rs232BaudRateInputIndex { get; set; }
        bool SerialNumberButtonEnabled { set; }
        bool SerialNumberInputEnabled { set; }
        int SerialNumberInputMaxLength { set; }
        string SerialNumberInputText { get; set; }
        bool SocketPortTcpButtonEnabled { set; }
        bool SocketPortTcpInputEnabled { set; }
        int SocketPortTcpInputMaxLength { set; }
        string SocketPortTcpInputText { get; set; }
        bool SocketPortUdpButtonEnabled { set; }
        bool SocketPortUdpInputEnabled { set; }
        int SocketPortUdpInputMaxLength { set; }
        string SocketPortUdpInputText { get; set; }
        bool TabControlEnabled { set; }
        int TabControlIndex { get; }
        bool TagFilterButtonEnabled { set; }
        bool TagFilterInputEnabled { set; }
        int TagFilterInputIndex { get; set; }

        event EventHandler? Load;
        event FormClosedEventHandler? FormClosed;
        event KeyEventHandler? KeyDown;
        event EventHandler? BusAddressButton_Click;
        event EventHandler? BuzzerButton_Click;
        event EventHandler? BuzzerWidthButton_Click;
        event EventHandler? FrequencyButton_Click;
        event EventHandler? GatewayButton_Click;
        event KeyPressEventHandler? GatewayInput_KeyPress;
        event EventHandler? IpAddressButton_Click;
        event KeyPressEventHandler? IpAddressInput_KeyPress;
        event EventHandler? MacAddressButton_Click;
        event KeyPressEventHandler? MacAddressInput_KeyPress;
        event EventHandler? MaskButton_Click;
        event KeyPressEventHandler? MaskInput_KeyPress;
        event EventHandler? ModelButton_Click;
        event KeyPressEventHandler? ModelInput_KeyPress;
        event EventHandler? NameButton_Click;
        event KeyPressEventHandler? NameInput_KeyPress;
        event EventHandler? PowerButton_Click;
        event EventHandler? RebootButton_Click;
        event EventHandler? Rs232BaudRateButton_Click;
        event EventHandler? SerialNumberButton_Click;
        event KeyPressEventHandler? SerialNumberInput_KeyPress;
        event EventHandler? SocketPortTcpButton_Click;
        event KeyPressEventHandler? SocketPortTcpInput_KeyPress;
        event EventHandler? SocketPortUdpButton_Click;
        event KeyPressEventHandler? SocketPortUdpInput_KeyPress;
        event EventHandler? TabControl_IndexChanged;
        event EventHandler? TagFilterButton_Click;

        void Close();
        bool OpenRebootMessageBox();
        void SetBusAddressInputItems(object[] items);
        void SetBuzzerInputItems(object[] items);
        void SetBuzzerWidthInputItems(object[] items);
        void SetFrequencyInputItems(object[] items);
        void SetPowerInputItems(object[] items);
        void SetRs232BaudRateInputItems(object[] items);
        void SetTagFilterInputItems(object[] items);
    }

    public partial class AdvancedForm : Form, IAdvancedForm
    {
        private readonly MainForm _mainForm;

        public AdvancedForm(MainForm mainForm)
        {
            InitializeComponent();

            _mainForm = mainForm;

            SetAdvancedFormUI();
            SetTabControlUI();
            SetTabControlTabPage1UI();
            SetTabControlTabPage2UI();
        }

        private void SetAdvancedFormUI()
        {
            Text = Lang.Advanced.FormName;
        }

        private void AdvancedForm_Move(object sender, EventArgs e)
        {
            _mainForm.Left = Left - _mainForm.Width;
            _mainForm.Top = Top;
        }
    }
}
