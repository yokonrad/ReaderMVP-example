namespace Reader.View
{
    public partial class AdvancedForm
    {
        private void Rs232BaudRateInput_DrawItem(object sender, DrawItemEventArgs e) => Helper.ComboBox_DrawItem(sender, e);
        public event EventHandler? Rs232BaudRateButton_Click;

        public bool Rs232BaudRateInputEnabled
        {
            set { Rs232BaudRateInput.Enabled = value; }
        }

        public int Rs232BaudRateInputIndex
        {
            get { return Rs232BaudRateInput.SelectedIndex; }
            set { Rs232BaudRateInput.SelectedIndex = value; }
        }

        public bool Rs232BaudRateButtonEnabled
        {
            set { Rs232BaudRateButton.Enabled = value; }
        }

        private void SetRs232BaudRateUI()
        {
            Rs232BaudRateButton.Click += delegate { Rs232BaudRateButton_Click?.Invoke(this, EventArgs.Empty); };

            Rs232BaudRateContainer.Text = Lang.Advanced.Rs232BaudRateContainer;
            Rs232BaudRateButton.Text = Lang.Advanced.Button;
        }

        public void SetRs232BaudRateInputItems(object[] items)
        {
            Rs232BaudRateInput.BeginUpdate();
            foreach (var item in items) Rs232BaudRateInput.Items.Add(item);
            Rs232BaudRateInput.EndUpdate();
        }
    }
}
