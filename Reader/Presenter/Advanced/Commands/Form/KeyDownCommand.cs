using Reader.View;

namespace Reader.Presenter.Advanced.Commands.Form
{
    public class KeyDownCommand
    {
        private readonly IMainForm _mainForm;
        private readonly IViewController _viewController;

        public KeyDownCommand(IMainForm mainForm, IViewController viewController)
        {
            _mainForm = mainForm;
            _viewController = viewController;
        }

        public async Task Execute(int index, KeyEventArgs e)
        {
            if (_viewController.IsLocked) return;

            try
            {
                if (e.Control && e.KeyCode == Keys.Y)
                {
                    await _viewController.Refresh(index, true);

                    _viewController.IsEditable = !_viewController.IsEditable;

                    await _viewController.Refresh(index, false);
                }
            }
            catch (Exception exception)
            {
                _mainForm.LogDevice_Add(exception.Message, true);
            }
        }
    }
}
