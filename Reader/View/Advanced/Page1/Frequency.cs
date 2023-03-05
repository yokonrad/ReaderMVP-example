namespace Reader.View
{
    public partial class AdvancedForm
    {
        private void FrequencyInput_DrawItem(object sender, DrawItemEventArgs e) => Helper.ComboBox_DrawItem(sender, e);
        public event EventHandler? FrequencyButton_Click;

        public bool FrequencyInputEnabled
        {
            set { FrequencyInput.Enabled = value; }
        }

        public int FrequencyInputIndex
        {
            get { return FrequencyInput.SelectedIndex; }
            set { FrequencyInput.SelectedIndex = value; }
        }

        public bool FrequencyButtonEnabled
        {
            set { FrequencyButton.Enabled = value; }
        }

        private void SetFrequencyUI()
        {
            FrequencyButton.Click += delegate { FrequencyButton_Click?.Invoke(this, EventArgs.Empty); };

            FrequencyContainer.Text = Lang.Advanced.FrequencyContainer;
            FrequencyButton.Text = Lang.Advanced.Button;
        }

        public void SetFrequencyInputItems(object[] items)
        {
            FrequencyInput.BeginUpdate();
            foreach (var item in items) FrequencyInput.Items.Add(item);
            FrequencyInput.EndUpdate();
        }
    }
}
