namespace Reader.Presenter.Main.Commands.Form
{
    public class LoadCommand
    {
        private readonly IViewController _viewController;

        public LoadCommand(IViewController viewController)
        {
            _viewController = viewController;
        }

        public async Task Execute()
        {
            await _viewController.Refresh();
        }
    }
}
