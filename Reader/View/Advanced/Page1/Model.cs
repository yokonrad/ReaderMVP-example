namespace Reader.View
{
    public partial class AdvancedForm
    {
        public event KeyPressEventHandler? ModelInput_KeyPress;
        public event EventHandler? ModelButton_Click;

        public bool ModelInputEnabled
        {
            set { ModelInput.Enabled = value; }
        }

        public int ModelInputMaxLength
        {
            set { ModelInput.MaxLength = value; }
        }

        public string ModelInputText
        {
            get { return ModelInput.Text; }
            set { ModelInput.Text = value; }
        }

        public bool ModelButtonEnabled
        {
            set { ModelButton.Enabled = value; }
        }

        private void SetModelUI()
        {
            ModelInput.KeyPress += delegate { ModelInput_KeyPress?.Invoke(this, (KeyPressEventArgs)EventArgs.Empty); };
            ModelButton.Click += delegate { ModelButton_Click?.Invoke(this, EventArgs.Empty); };

            ModelContainer.Text = Lang.Advanced.ModelContainer;
            ModelButton.Text = Lang.Advanced.Button;
        }
    }
}
