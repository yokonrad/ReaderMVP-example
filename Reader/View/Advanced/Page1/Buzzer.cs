namespace Reader.View
{
    public partial class AdvancedForm
    {
        private void BuzzerInput_DrawItem(object sender, DrawItemEventArgs e) => Helper.ComboBox_DrawItem(sender, e);
        public event EventHandler? BuzzerButton_Click;

        public bool BuzzerInputEnabled
        {
            set { BuzzerInput.Enabled = value; }
        }

        public int BuzzerInputIndex
        {
            get { return BuzzerInput.SelectedIndex; }
            set { BuzzerInput.SelectedIndex = value; }
        }

        public bool BuzzerButtonEnabled
        {
            set { BuzzerButton.Enabled = value; }
        }

        private void SetBuzzerUI()
        {
            BuzzerButton.Click += delegate { BuzzerButton_Click?.Invoke(this, EventArgs.Empty); };

            BuzzerContainer.Text = Lang.Advanced.BuzzerContainer;
            BuzzerButton.Text = Lang.Advanced.Button;
        }

        public void SetBuzzerInputItems(object[] items)
        {
            BuzzerInput.BeginUpdate();
            foreach (var item in items) BuzzerInput.Items.Add(item);
            BuzzerInput.EndUpdate();
        }
    }
}
