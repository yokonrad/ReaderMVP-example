namespace Reader.View
{
    public partial class AdvancedForm
    {
        public event KeyPressEventHandler? MaskInput_KeyPress;
        public event EventHandler? MaskButton_Click;

        public bool MaskInputEnabled
        {
            set { MaskInput.Enabled = value; }
        }

        public int MaskInputMaxLength
        {
            set { MaskInput.MaxLength = value; }
        }

        public string MaskInputText
        {
            get { return MaskInput.Text; }
            set { MaskInput.Text = value; }
        }

        public bool MaskButtonEnabled
        {
            set { MaskButton.Enabled = value; }
        }

        private void SetMaskUI()
        {
            MaskInput.KeyPress += delegate { MaskInput_KeyPress?.Invoke(this, (KeyPressEventArgs)EventArgs.Empty); };
            MaskButton.Click += delegate { MaskButton_Click?.Invoke(this, EventArgs.Empty); };

            MaskContainer.Text = Lang.Advanced.MaskContainer;
            MaskButton.Text = Lang.Advanced.Button;
        }
    }
}
