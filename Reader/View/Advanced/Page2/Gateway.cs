namespace Reader.View
{
    public partial class AdvancedForm
    {
        public event KeyPressEventHandler? GatewayInput_KeyPress;
        public event EventHandler? GatewayButton_Click;

        public bool GatewayInputEnabled
        {
            set { GatewayInput.Enabled = value; }
        }

        public int GatewayInputMaxLength
        {
            set { GatewayInput.MaxLength = value; }
        }

        public string GatewayInputText
        {
            get { return GatewayInput.Text; }
            set { GatewayInput.Text = value; }
        }

        public bool GatewayButtonEnabled
        {
            set { GatewayButton.Enabled = value; }
        }

        private void SetGatewayUI()
        {
            GatewayInput.KeyPress += delegate { GatewayInput_KeyPress?.Invoke(this, (KeyPressEventArgs)EventArgs.Empty); };
            GatewayButton.Click += delegate { GatewayButton_Click?.Invoke(this, EventArgs.Empty); };

            GatewayContainer.Text = Lang.Advanced.GatewayContainer;
            GatewayButton.Text = Lang.Advanced.Button;
        }
    }
}
