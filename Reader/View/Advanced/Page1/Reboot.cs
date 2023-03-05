namespace Reader.View
{
    public partial class AdvancedForm
    {
        public event EventHandler? RebootButton_Click;

        public bool RebootButtonEnabled
        {
            set { RebootButton.Enabled = value; }
        }

        private void SetRebootUI()
        {
            RebootButton.Click += delegate { RebootButton_Click?.Invoke(this, EventArgs.Empty); };

            RebootContainer.Text = Lang.Advanced.RebootContainer;
            RebootButton.Text = Lang.Advanced.Button;
        }

        public bool OpenRebootMessageBox()
        {
            if (MessageBox.Show($"{Lang.Advanced.RebootContainer}?", string.Empty, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                return true;
            }

            return false;
        }
    }
}
