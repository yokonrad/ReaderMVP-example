namespace Reader.View
{
    public partial class AdvancedForm
    {
        private void PowerInput_DrawItem(object sender, DrawItemEventArgs e) => Helper.ComboBox_DrawItem(sender, e);
        public event EventHandler? PowerButton_Click;

        public bool PowerInputEnabled
        {
            set { PowerInput.Enabled = value; }
        }

        public int PowerInputIndex
        {
            get { return PowerInput.SelectedIndex; }
            set { PowerInput.SelectedIndex = value; }
        }

        public bool PowerButtonEnabled
        {
            set { PowerButton.Enabled = value; }
        }

        private void SetPowerUI()
        {
            PowerButton.Click += delegate { PowerButton_Click?.Invoke(this, EventArgs.Empty); };

            PowerContainer.Text = Lang.Advanced.PowerContainer;
            PowerButton.Text = Lang.Advanced.Button;
        }

        public void SetPowerInputItems(object[] items)
        {
            PowerInput.BeginUpdate();
            foreach (var item in items) PowerInput.Items.Add(item);
            PowerInput.EndUpdate();
        }
    }
}
