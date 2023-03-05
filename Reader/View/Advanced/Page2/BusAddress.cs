namespace Reader.View
{
    public partial class AdvancedForm
    {
        private void BusAddressInput_DrawItem(object sender, DrawItemEventArgs e) => Helper.ComboBox_DrawItem(sender, e);
        public event EventHandler? BusAddressButton_Click;

        public bool BusAddressInputEnabled
        {
            set { BusAddressInput.Enabled = value; }
        }

        public int BusAddressInputIndex
        {
            get { return BusAddressInput.SelectedIndex; }
            set { BusAddressInput.SelectedIndex = value; }
        }

        public bool BusAddressButtonEnabled
        {
            set { BusAddressButton.Enabled = value; }
        }

        private void SetBusAddressUI()
        {
            BusAddressButton.Click += delegate { BusAddressButton_Click?.Invoke(this, EventArgs.Empty); };

            BusAddressContainer.Text = Lang.Advanced.BusAddressContainer;
            BusAddressButton.Text = Lang.Advanced.Button;
        }

        public void SetBusAddressInputItems(object[] items)
        {
            BusAddressInput.BeginUpdate();
            foreach (var item in items) BusAddressInput.Items.Add(item);
            BusAddressInput.EndUpdate();
        }
    }
}
