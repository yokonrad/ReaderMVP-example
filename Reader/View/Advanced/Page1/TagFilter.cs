namespace Reader.View
{
    public partial class AdvancedForm
    {
        private void TagFilterInput_DrawItem(object sender, DrawItemEventArgs e) => Helper.ComboBox_DrawItem(sender, e);
        public event EventHandler? TagFilterButton_Click;

        public bool TagFilterInputEnabled
        {
            set { TagFilterInput.Enabled = value; }
        }

        public int TagFilterInputIndex
        {
            get { return TagFilterInput.SelectedIndex; }
            set { TagFilterInput.SelectedIndex = value; }
        }

        public bool TagFilterButtonEnabled
        {
            set { TagFilterButton.Enabled = value; }
        }

        private void SetTagFilterUI()
        {
            TagFilterButton.Click += delegate { TagFilterButton_Click?.Invoke(this, EventArgs.Empty); };

            TagFilterContainer.Text = Lang.Advanced.TagFilterContainer;
            TagFilterButton.Text = Lang.Advanced.Button;
        }

        public void SetTagFilterInputItems(object[] items)
        {
            TagFilterInput.BeginUpdate();
            foreach (var item in items) TagFilterInput.Items.Add(item);
            TagFilterInput.EndUpdate();
        }
    }
}
