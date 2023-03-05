namespace Reader.View
{
    public partial class AdvancedForm
    {
        public event KeyPressEventHandler? IpAddressInput_KeyPress;
        public event EventHandler? IpAddressButton_Click;

        public bool IpAddressInputEnabled
        {
            set { IpAddressInput.Enabled = value; }
        }

        public int IpAddressInputMaxLength
        {
            set { IpAddressInput.MaxLength = value; }
        }

        public string IpAddressInputText
        {
            get { return IpAddressInput.Text; }
            set { IpAddressInput.Text = value; }
        }

        public bool IpAddressButtonEnabled
        {
            set { IpAddressButton.Enabled = value; }
        }

        private void SetIpAddressUI()
        {
            IpAddressInput.KeyPress += delegate { IpAddressInput_KeyPress?.Invoke(this, (KeyPressEventArgs)EventArgs.Empty); };
            IpAddressButton.Click += delegate { IpAddressButton_Click?.Invoke(this, EventArgs.Empty); };

            IpAddressContainer.Text = Lang.Advanced.IpAddressContainer;
            IpAddressButton.Text = Lang.Advanced.Button;
        }
    }
}
