namespace Reader.View
{
    public partial class AdvancedForm
    {
        private void BuzzerWidthInput_DrawItem(object sender, DrawItemEventArgs e) => Helper.ComboBox_DrawItem(sender, e);
        public event EventHandler? BuzzerWidthButton_Click;

        public bool BuzzerWidthInputEnabled
        {
            set { BuzzerWidthInput.Enabled = value; }
        }

        public int BuzzerWidthInputIndex
        {
            get { return BuzzerWidthInput.SelectedIndex; }
            set { BuzzerWidthInput.SelectedIndex = value; }
        }

        public bool BuzzerWidthButtonEnabled
        {
            set { BuzzerWidthButton.Enabled = value; }
        }

        private void SetBuzzerWidthUI()
        {
            BuzzerWidthButton.Click += delegate { BuzzerWidthButton_Click?.Invoke(this, EventArgs.Empty); };

            BuzzerWidthContainer.Text = Lang.Advanced.BuzzerWidthContainer;
            BuzzerWidthButton.Text = Lang.Advanced.Button;
        }

        public void SetBuzzerWidthInputItems(object[] items)
        {
            BuzzerWidthInput.BeginUpdate();
            foreach (var item in items) BuzzerWidthInput.Items.Add(item);
            BuzzerWidthInput.EndUpdate();
        }
    }
}
