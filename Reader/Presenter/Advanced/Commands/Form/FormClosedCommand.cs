namespace Reader.Presenter.Advanced.Commands.Form
{
    public class FormClosedCommand
    {
        private readonly CancellationTokenSource _cts;

        public FormClosedCommand(CancellationTokenSource cts)
        {
            _cts = cts;
        }

        public void Execute()
        {
            _cts.Cancel();
            _cts.Dispose();
        }
    }
}
