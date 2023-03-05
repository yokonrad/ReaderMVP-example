namespace Reader.Presenter.Main
{
    public interface IReadController
    {
        bool IsMysqlEnabled { get; set; }
        bool IsSoundEnabled { get; set; }
        int SoundCount { get; set; }
        ManualResetEventSlim SoundWait { get; set; }
    }

    public class ReadController : IReadController
    {
        private bool _mysqlEnabled = false;
        private bool _soundEnabled = false;

        private int _soundCount = 0;
        private ManualResetEventSlim _soundWait = new(false);

        public bool IsMysqlEnabled
        {
            get { return _mysqlEnabled; }
            set { _mysqlEnabled = value; }
        }
        public bool IsSoundEnabled
        {
            get { return _soundEnabled; }
            set { _soundEnabled = value; }
        }
        public int SoundCount
        {
            get { return _soundCount; }
            set { _soundCount = value; }
        }
        public ManualResetEventSlim SoundWait
        {
            get { return _soundWait; }
            set { _soundWait = value; }
        }
    }
}
