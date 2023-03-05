namespace Reader.View
{
    public partial class MainForm
    {
        private void SettingSwActivator_DrawItem(object sender, DrawItemEventArgs e) => Helper.ComboBox_DrawItem(sender, e);
        private void SettingSwTagFilter_DrawItem(object sender, DrawItemEventArgs e) => Helper.ComboBox_DrawItem(sender, e);
        private void SettingSwRssi1_DrawItem(object sender, DrawItemEventArgs e) => Helper.ComboBox_DrawItem(sender, e);
        private void SettingSwRssi2_DrawItem(object sender, DrawItemEventArgs e) => Helper.ComboBox_DrawItem(sender, e);
        private void SettingSwSound_Paint(object sender, PaintEventArgs e) => Helper.CheckBox_Paint(sender, e);
        private void SettingSwMysql_Paint(object sender, PaintEventArgs e) => Helper.CheckBox_Paint(sender, e);

        public event EventHandler? SettingSwSound_CheckedChanged;
        public event EventHandler? SettingSwMysql_CheckedChanged;

        public bool SettingSwActivatorEnabled
        {
            set { SettingSwActivator.Enabled = value; }
        }

        public int SettingSwActivatorIndex
        {
            get { return SettingSwActivator.SelectedIndex; }
            set { SettingSwActivator.SelectedIndex = value; }
        }

        public string SettingSwActivatorText
        {
            get { return SettingSwActivator.Text; }
        }

        public bool SettingSwTagFilterEnabled
        {
            set { SettingSwTagFilter.Enabled = value; }
        }

        public int SettingSwTagFilterIndex
        {
            get { return SettingSwTagFilter.SelectedIndex; }
            set { SettingSwTagFilter.SelectedIndex = value; }
        }

        public string SettingSwTagFilterText
        {
            get { return SettingSwTagFilter.Text; }
        }

        public bool SettingSwRssi1Enabled
        {
            set { SettingSwRssi1.Enabled = value; }
        }

        public int SettingSwRssi1Index
        {
            get { return SettingSwRssi1.SelectedIndex; }
            set { SettingSwRssi1.SelectedIndex = value; }
        }

        public string SettingSwRssi1Text
        {
            get { return SettingSwRssi1.Text; }
        }

        public bool SettingSwRssi2Enabled
        {
            set { SettingSwRssi2.Enabled = value; }
        }

        public int SettingSwRssi2Index
        {
            get { return SettingSwRssi2.SelectedIndex; }
            set { SettingSwRssi2.SelectedIndex = value; }
        }

        public string SettingSwRssi2Text
        {
            get { return SettingSwRssi2.Text; }
        }

        public bool SettingSwSoundEnabled
        {
            set { SettingSwSound.Enabled = value; }
        }

        public bool SettingSwSoundChecked
        {
            get { return SettingSwSound.Checked; }
            set { SettingSwSound.Checked = value; }
        }

        public bool SettingSwMysqlEnabled
        {
            set { SettingSwMysql.Enabled = value; }
        }

        public bool SettingSwMysqlChecked
        {
            get { return SettingSwMysql.Checked; }
            set { SettingSwMysql.Checked = value; }
        }

        private void SettingSwUI()
        {
            SettingSwSound.CheckedChanged += delegate { SettingSwSound_CheckedChanged?.Invoke(this, EventArgs.Empty); };
            SettingSwMysql.CheckedChanged += delegate { SettingSwMysql_CheckedChanged?.Invoke(this, EventArgs.Empty); };

            SettingSwContainer.Text = Lang.Main.SettingsSwContainer;
            SettingSwSound.Text = Lang.Main.SettingSwSound;
            SettingSwMysql.Text = Lang.Main.SettingSwMysql;
        }

        public void SetSettingSwActivatorItems(object[] items)
        {
            SettingSwActivator.BeginUpdate();
            foreach (var item in items) SettingSwActivator.Items.Add(item);
            SettingSwActivator.EndUpdate();
        }

        public void SetSettingSwTagFilterItems(object[] items)
        {
            SettingSwTagFilter.BeginUpdate();
            foreach (var item in items) SettingSwTagFilter.Items.Add(item);
            SettingSwTagFilter.EndUpdate();
        }

        public void SetSettingSwRssi1Items(object[] items)
        {
            SettingSwRssi1.BeginUpdate();
            foreach (var item in items) SettingSwRssi1.Items.Add(item);
            SettingSwRssi1.EndUpdate();
        }

        public void SetSettingSwRssi2Items(object[] items)
        {
            SettingSwRssi2.BeginUpdate();
            foreach (var item in items) SettingSwRssi2.Items.Add(item);
            SettingSwRssi2.EndUpdate();
        }
    }
}
