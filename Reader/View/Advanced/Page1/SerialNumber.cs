namespace Reader.View
{
    public partial class AdvancedForm
    {
        public event KeyPressEventHandler? SerialNumberInput_KeyPress;
        public event EventHandler? SerialNumberButton_Click;

        public bool SerialNumberInputEnabled
        {
            set { SerialNumberInput.Enabled = value; }
        }

        public int SerialNumberInputMaxLength
        {
            set { SerialNumberInput.MaxLength = value; }
        }

        public string SerialNumberInputText
        {
            get { return SerialNumberInput.Text; }
            set { SerialNumberInput.Text = value; }
        }

        public bool SerialNumberButtonEnabled
        {
            set { SerialNumberButton.Enabled = value; }
        }

        private void SetSerialNumberUI()
        {
            SerialNumberInput.KeyPress += delegate { SerialNumberInput_KeyPress?.Invoke(this, (KeyPressEventArgs)EventArgs.Empty); };
            SerialNumberButton.Click += delegate { SerialNumberButton_Click?.Invoke(this, EventArgs.Empty); };

            SerialNumberContainer.Text = Lang.Advanced.SerialNumberContainer;
            SerialNumberButton.Text = Lang.Advanced.Button;
        }
    }
}
