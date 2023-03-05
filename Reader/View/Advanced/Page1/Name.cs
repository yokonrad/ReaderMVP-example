namespace Reader.View
{
    public partial class AdvancedForm
    {
        public event KeyPressEventHandler? NameInput_KeyPress;
        public event EventHandler? NameButton_Click;

        public bool NameInputEnabled
        {
            set { NameInput.Enabled = value; }
        }

        public int NameInputMaxLength
        {
            set { NameInput.MaxLength = value; }
        }

        public string NameInputText
        {
            get { return NameInput.Text; }
            set { NameInput.Text = value; }
        }

        public bool NameButtonEnabled
        {
            set { NameButton.Enabled = value; }
        }

        private void SetNameUI()
        {
            NameInput.KeyPress += delegate { NameInput_KeyPress?.Invoke(this, (KeyPressEventArgs)EventArgs.Empty); };
            NameButton.Click += delegate { NameButton_Click?.Invoke(this, EventArgs.Empty); };

            NameContainer.Text = Lang.Advanced.NameContainer;
            NameButton.Text = Lang.Advanced.Button;
        }
    }
}
