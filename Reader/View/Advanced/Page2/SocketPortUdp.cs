namespace Reader.View
{
    public partial class AdvancedForm
    {
        public event KeyPressEventHandler? SocketPortUdpInput_KeyPress;
        public event EventHandler? SocketPortUdpButton_Click;

        public bool SocketPortUdpInputEnabled
        {
            set { SocketPortUdpInput.Enabled = value; }
        }

        public int SocketPortUdpInputMaxLength
        {
            set { SocketPortUdpInput.MaxLength = value; }
        }

        public string SocketPortUdpInputText
        {
            get { return SocketPortUdpInput.Text; }
            set { SocketPortUdpInput.Text = value; }
        }

        public bool SocketPortUdpButtonEnabled
        {
            set { SocketPortUdpButton.Enabled = value; }
        }

        private void SetSocketPortUdpUI()
        {
            SocketPortUdpInput.KeyPress += delegate { SocketPortUdpInput_KeyPress?.Invoke(this, (KeyPressEventArgs)EventArgs.Empty); };
            SocketPortUdpButton.Click += delegate { SocketPortUdpButton_Click?.Invoke(this, EventArgs.Empty); };

            SocketPortUdpContainer.Text = Lang.Advanced.SocketPortUdpContainer;
            SocketPortUdpButton.Text = Lang.Advanced.Button;
        }
    }
}
