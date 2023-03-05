namespace Reader.View
{
    public partial class AdvancedForm
    {
        public event KeyPressEventHandler? MacAddressInput_KeyPress;
        public event EventHandler? MacAddressButton_Click;

        public bool MacAddressInputEnabled
        {
            set { MacAddressInput.Enabled = value; }
        }

        public int MacAddressInputMaxLength
        {
            set { MacAddressInput.MaxLength = value; }
        }

        public string MacAddressInputText
        {
            get { return MacAddressInput.Text; }
            set { MacAddressInput.Text = value; }
        }

        public bool MacAddressButtonEnabled
        {
            set { MacAddressButton.Enabled = value; }
        }

        private void SetMacAddressUI()
        {
            MacAddressInput.KeyPress += delegate { MacAddressInput_KeyPress?.Invoke(this, (KeyPressEventArgs)EventArgs.Empty); };
            MacAddressButton.Click += delegate { MacAddressButton_Click?.Invoke(this, EventArgs.Empty); };

            MacAddressContainer.Text = Lang.Advanced.MacAddressContainer;
            MacAddressButton.Text = Lang.Advanced.Button;
        }
    }
}
