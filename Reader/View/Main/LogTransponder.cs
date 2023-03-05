namespace Reader.View
{
    public partial class MainForm
    {
        private readonly int[] _logTransponderListViewColumnWidth = new int[8] { 0, 50, 60, 90, 140, 60, 60, 60 };

        private void LogTransponderUI()
        {
            LogTransponderContainer.Text = Lang.Main.LogTransponderContainer;

            LogTransponderListView.DoubleBuffered(true);

            LogTransponderListViewColumnNull.Text = Lang.Main.LogTransponderListViewColumnNull;
            LogTransponderListViewColumnNull.Width = _logTransponderListViewColumnWidth[0];

            LogTransponderListViewColumnId.Text = Lang.Main.LogTransponderListViewColumnId;
            LogTransponderListViewColumnId.Width = _logTransponderListViewColumnWidth[1];

            LogTransponderListViewColumnActivator.Text = Lang.Main.LogTransponderListViewColumnActivator;
            LogTransponderListViewColumnActivator.Width = _logTransponderListViewColumnWidth[2];

            LogTransponderListViewColumnNumber.Text = Lang.Main.LogTransponderListViewColumnNumber;
            LogTransponderListViewColumnNumber.Width = _logTransponderListViewColumnWidth[3];

            LogTransponderListViewColumnValue.Text = Lang.Main.LogTransponderListViewColumnValue;
            LogTransponderListViewColumnValue.Width = _logTransponderListViewColumnWidth[4];

            LogTransponderListViewColumnRssi1.Text = Lang.Main.LogTransponderListViewColumnRssi1;
            LogTransponderListViewColumnRssi1.Width = _logTransponderListViewColumnWidth[5];

            LogTransponderListViewColumnRssi2.Text = Lang.Main.LogTransponderListViewColumnRssi2;
            LogTransponderListViewColumnRssi2.Width = _logTransponderListViewColumnWidth[6];

            LogTransponderListViewColumnBattery.Text = Lang.Main.LogTransponderListViewColumnBattery;
            LogTransponderListViewColumnBattery.Width = _logTransponderListViewColumnWidth[7];
        }

        private static DateTime UnixToDateTime(double value)
        {
            if (TimeZoneInfo.Local.IsDaylightSavingTime(DateTime.Now))
            {
                return new DateTime(1970, 1, 1, 2, 0, 0).AddSeconds(value);
            }

            return new DateTime(1970, 1, 1, 1, 0, 0).AddSeconds(value);
        }

        public void LogTransponder_Add(int activator, uint number, double value, int rssi1, int rssi2, bool battery)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate
                {
                    LogTransponder_Add(activator, number, value, rssi1, rssi2, battery);
                }));
            }
            else
            {
                ListViewItem listViewItem = new(new string[] {
                    string.Empty,
                    (LogTransponderListView.Items.Count + 1).ToString(),
                    activator.ToString(),
                    number.ToString(),
                    UnixToDateTime(value).ToString("dd.MM.yyyy HH:mm:ss.fff"),
                    rssi1.ToString(),
                    rssi2.ToString(),
                    battery ? "Low" : "Normal",
                });

                if (battery)
                {
                    listViewItem.BackColor = Color.Coral;
                }

                LogTransponderListView.BeginUpdate();
                LogTransponderListView.Items.Add(listViewItem);
                LogTransponderListView.Items[^1].EnsureVisible();
                LogTransponderListView.EndUpdate();
            }
        }

        public void LogTransponder_Update(int i, int activator, uint number, double value, int rssi1, int rssi2, bool battery)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate
                {
                    LogTransponder_Update(i, activator, number, value, rssi1, rssi2, battery);
                }));
            }
            else
            {
                if (LogTransponderListView.Items.Count > i)
                {
                    LogTransponderListView.BeginUpdate();
                    LogTransponderListView.Items[i].SubItems[2].Text = activator.ToString();
                    LogTransponderListView.Items[i].SubItems[3].Text = number.ToString();
                    LogTransponderListView.Items[i].SubItems[4].Text = UnixToDateTime(value).ToString("dd.MM.yyyy HH:mm:ss.fff");
                    LogTransponderListView.Items[i].SubItems[5].Text = rssi1.ToString();
                    LogTransponderListView.Items[i].SubItems[6].Text = rssi2.ToString();
                    LogTransponderListView.Items[i].SubItems[7].Text = battery ? "Low" : "Normal";

                    if (battery)
                    {
                        LogTransponderListView.Items[i].BackColor = Color.Coral;
                    }
                    else
                    {
                        LogTransponderListView.Items[i].BackColor = Color.White;
                    }

                    LogTransponderListView.EndUpdate();
                }
                else
                {
                    LogTransponder_Add(activator, number, value, rssi1, rssi2, battery);
                }
            }
        }

        public void LogTransponder_Clear()
        {
            LogTransponderListView.BeginUpdate();
            LogTransponderListView.Items.Clear();
            LogTransponderListView.EndUpdate();
        }

        private void LogTransponderListView_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {
            if (_logTransponderListViewColumnWidth.Length > e.ColumnIndex && !(LogTransponderListView.Columns[e.ColumnIndex].Width == _logTransponderListViewColumnWidth[e.ColumnIndex]))
            {
                LogTransponderListView.Columns[e.ColumnIndex].Width = _logTransponderListViewColumnWidth[e.ColumnIndex];
            }
        }
    }
}
