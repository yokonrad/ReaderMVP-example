using Reader.View;

namespace Reader.Presenter.Advanced.Commands.Form
{
    public class LoadCommand
    {
        private readonly IMainForm _mainForm;
        private readonly IViewController _viewController;

        public LoadCommand(IMainForm mainForm, IViewController viewController)
        {
            _mainForm = mainForm;
            _viewController = viewController;
        }

        public async Task Execute(int index)
        {
            try
            {
                await _viewController.Refresh(index, true);

                if (await _viewController.Data(index))
                {
                    _mainForm.LogDevice_Add(Lang.Advanced.DataUI_Success);
                }
                else
                {
                    _mainForm.LogDevice_Add(Lang.Advanced.DataUI_Error);
                }
            }
            catch (Exception exception)
            {
                _mainForm.LogDevice_Add(exception.Message, true);
            }
            finally
            {
                await _viewController.Refresh(index, false);
            }
        }
    }
}
