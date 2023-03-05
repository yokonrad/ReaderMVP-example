namespace Reader.View
{
    public partial class MainForm
    {
        public event EventHandler? ReadStart_Click;
        public event EventHandler? ReadStop_Click;
        public event EventHandler? ReadReset_Click;

        public bool ReadStartEnabled
        {
            set { ReadStart.Enabled = value; }
        }

        public bool ReadStopEnabled
        {
            set { ReadStop.Enabled = value; }
        }

        public bool ReadResetEnabled
        {
            set { ReadReset.Enabled = value; }
        }

        private void ReadUI()
        {
            ReadStart.Click += delegate { ReadStart_Click?.Invoke(this, EventArgs.Empty); };
            ReadStop.Click += delegate { ReadStop_Click?.Invoke(this, EventArgs.Empty); };
            ReadReset.Click += delegate { ReadReset_Click?.Invoke(this, EventArgs.Empty); };

            ReadContainer.Text = Lang.Main.ReadContainer;
            ReadStart.Text = Lang.Main.ReadStart;
            ReadStop.Text = Lang.Main.ReadStop;
            ReadReset.Text = Lang.Main.ReadReset;
        }
    }
}
