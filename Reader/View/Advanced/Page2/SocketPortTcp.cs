namespace Reader.View
{
    public partial class AdvancedForm
    {
        public event KeyPressEventHandler? SocketPortTcpInput_KeyPress;
        public event EventHandler? SocketPortTcpButton_Click;

        public bool SocketPortTcpInputEnabled
        {
            set { SocketPortTcpInput.Enabled = value; }
        }

        public int SocketPortTcpInputMaxLength
        {
            set { SocketPortTcpInput.MaxLength = value; }
        }

        public string SocketPortTcpInputText
        {
            get { return SocketPortTcpInput.Text; }
            set { SocketPortTcpInput.Text = value; }
        }

        public bool SocketPortTcpButtonEnabled
        {
            set { SocketPortTcpButton.Enabled = value; }
        }

        private void SetSocketPortTcpUI()
        {
            SocketPortTcpInput.KeyPress += delegate { SocketPortTcpInput_KeyPress?.Invoke(this, (KeyPressEventArgs)EventArgs.Empty); };
            SocketPortTcpButton.Click += delegate { SocketPortTcpButton_Click?.Invoke(this, EventArgs.Empty); };

            SocketPortTcpContainer.Text = Lang.Advanced.SocketPortTcpContainer;
            SocketPortTcpButton.Text = Lang.Advanced.Button;
        }
    }
}
