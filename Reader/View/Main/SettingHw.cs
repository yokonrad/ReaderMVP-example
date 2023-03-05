using Reader.Model.Advanced;
using Reader.Presenter;

namespace Reader.View
{
    public partial class MainForm
    {
        private void SettingHwPower_DrawItem(object sender, DrawItemEventArgs e) => Helper.ComboBox_DrawItem(sender, e);
        private void SettingHwTagFilter_DrawItem(object sender, DrawItemEventArgs e) => Helper.ComboBox_DrawItem(sender, e);
        private void SettingHwBuzzer_DrawItem(object sender, DrawItemEventArgs e) => Helper.ComboBox_DrawItem(sender, e);

        public event EventHandler? SettingHwPower_SelectedIndexChanged;
        public event EventHandler? SettingHwTagFilter_SelectedIndexChanged;
        public event EventHandler? SettingHwBuzzer_SelectedIndexChanged;
        public event EventHandler? SettingHwAdvanced_Click;

        private int _settingHwPowerPrevIndex = -1;
        private int _settingHwTagFilterPrevIndex = -1;
        private int _settingHwBuzzerPrevIndex = -1;

        public bool SettingHwPowerEnabled
        {
            set { SettingHwPower.Enabled = value; }
        }

        public int SettingHwPowerIndex
        {
            get { return SettingHwPower.SelectedIndex; }
            set { SettingHwPower.SelectedIndex = value; }
        }

        public int SettingHwPowerPrevIndex
        {
            get { return _settingHwPowerPrevIndex; }
            set { _settingHwPowerPrevIndex = value; }
        }

        public bool SettingHwTagFilterEnabled
        {
            set { SettingHwTagFilter.Enabled = value; }
        }

        public int SettingHwTagFilterIndex
        {
            get { return SettingHwTagFilter.SelectedIndex; }
            set { SettingHwTagFilter.SelectedIndex = value; }
        }

        public int SettingHwTagFilterPrevIndex
        {
            get { return _settingHwTagFilterPrevIndex; }
            set { _settingHwTagFilterPrevIndex = value; }
        }

        public bool SettingHwBuzzerEnabled
        {
            set { SettingHwBuzzer.Enabled = value; }
        }

        public int SettingHwBuzzerIndex
        {
            get { return SettingHwBuzzer.SelectedIndex; }
            set { SettingHwBuzzer.SelectedIndex = value; }
        }

        public int SettingHwBuzzerPrevIndex
        {
            get { return _settingHwBuzzerPrevIndex; }
            set { _settingHwBuzzerPrevIndex = value; }
        }

        public bool SettingHwAdvancedEnabled
        {
            set { SettingHwAdvanced.Enabled = value; }
        }

        private void SettingHwUI()
        {
            SettingHwPower.SelectedIndexChanged += delegate { SettingHwPower_SelectedIndexChanged?.Invoke(this, EventArgs.Empty); };
            SettingHwTagFilter.SelectedIndexChanged += delegate { SettingHwTagFilter_SelectedIndexChanged?.Invoke(this, EventArgs.Empty); };
            SettingHwBuzzer.SelectedIndexChanged += delegate { SettingHwBuzzer_SelectedIndexChanged?.Invoke(this, EventArgs.Empty); };
            SettingHwAdvanced.Click += delegate { SettingHwAdvanced_Click?.Invoke(this, EventArgs.Empty); };

            SettingHwContainer.Text = Lang.Main.SettingsHwContainer;
            SettingHwAdvanced.Text = Lang.Main.SettingsHwAdvanced;
        }

        public void SetSettingHwPowerItems(object[] items)
        {
            SettingHwPower.BeginUpdate();
            foreach (var item in items) SettingHwPower.Items.Add(item);
            SettingHwPower.EndUpdate();
        }

        public void SetSettingHwTagFilterItems(object[] items)
        {
            SettingHwTagFilter.BeginUpdate();
            foreach (var item in items) SettingHwTagFilter.Items.Add(item);
            SettingHwTagFilter.EndUpdate();
        }

        public void SetSettingHwBuzzerItems(object[] items)
        {
            SettingHwBuzzer.BeginUpdate();
            foreach (var item in items) SettingHwBuzzer.Items.Add(item);
            SettingHwBuzzer.EndUpdate();
        }

        public void OpenSettingHwAdvanced()
        {
            using AdvancedForm view = new(this);
            var validateModel = new ValidateModel();
            _ = new AdvancedPresenter(this, view, validateModel);

            view.Location = new Point(Left + Width, Top);
            view.ShowDialog();
        }
    }
}
