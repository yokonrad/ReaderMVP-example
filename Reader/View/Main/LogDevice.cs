namespace Reader.View
{
    public partial class MainForm
    {
        private readonly int[] _logDeviceListViewColumnWidth = new int[4] { 0, 50, 140, 249 };

        private void LogDeviceUI()
        {
            LogDeviceContainer.Text = Lang.Main.LogDeviceContainer;

            LogDeviceListView.DoubleBuffered(true);

            LogDeviceListViewColumnNull.Text = Lang.Main.LogDeviceListViewColumnNull;
            LogDeviceListViewColumnNull.Width = _logDeviceListViewColumnWidth[0];

            LogDeviceListViewColumnId.Text = Lang.Main.LogDeviceListViewColumnId;
            LogDeviceListViewColumnId.Width = _logDeviceListViewColumnWidth[1];

            LogDeviceListViewColumnTime.Text = Lang.Main.LogDeviceListViewColumnTime;
            LogDeviceListViewColumnTime.Width = _logDeviceListViewColumnWidth[2];

            LogDeviceListViewColumnValue.Text = Lang.Main.LogDeviceListViewColumnValue;
            LogDeviceListViewColumnValue.Width = _logDeviceListViewColumnWidth[3];
        }

        public void LogDevice_Add(string value, bool error = false)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate
                {
                    LogDevice_Add(value, error);
                }));
            }
            else
            {
                ListViewItem listViewItem = new(new string[]
                {
                    string.Empty,
                    (LogDeviceListView.Items.Count + 1).ToString(),
                    DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.fff"),
                    value,
                });

                if (error)
                {
                    listViewItem.BackColor = Color.Coral;
                }

                LogDeviceListView.BeginUpdate();
                LogDeviceListView.Items.Add(listViewItem);
                LogDeviceListView.Items[^1].EnsureVisible();
                LogDeviceListView.EndUpdate();
            }
        }

        private void LogDeviceListView_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            if (_logDeviceListViewColumnWidth.Length > e.ColumnIndex && !(LogDeviceListView.Columns[e.ColumnIndex].Width == _logDeviceListViewColumnWidth[e.ColumnIndex]))
            {
                LogDeviceListView.Columns[e.ColumnIndex].Width = _logDeviceListViewColumnWidth[e.ColumnIndex];
            }
        }
    }
}
