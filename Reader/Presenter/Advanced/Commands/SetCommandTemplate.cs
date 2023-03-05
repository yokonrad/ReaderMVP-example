using Reader.View;

namespace Reader.Presenter.Advanced.Commands
{
    public abstract class SetCommandTemplate<T>
    {
        private readonly IMainForm _mainForm;
        private readonly IAdvancedForm _advancedForm;
        private readonly IViewController _viewController;

        public SetCommandTemplate(IMainForm mainForm, IAdvancedForm advancedForm, IViewController viewController)
        {
            _mainForm = mainForm;
            _advancedForm = advancedForm;
            _viewController = viewController;
        }

        public async Task Execute(T t)
        {
            if (_viewController.IsLocked) return;

            try
            {
                if (!await CheckConnection()) return;

                await _viewController.Refresh(_advancedForm.TabControlIndex, true);

                if (CheckValidation(t))
                {
                    if (await ExecuteCommand(t))
                    {
                        _mainForm.LogDevice_Add(Success);
                    }
                    else
                    {
                        _mainForm.LogDevice_Add(Error);
                    }
                }
            }
            catch (Exception exception)
            {
                _mainForm.LogDevice_Add(exception.Message, true);
            }
            finally
            {
                await _viewController.Refresh(_advancedForm.TabControlIndex, false);
            }
        }

        protected abstract Task<bool> CheckConnection();
        protected abstract bool CheckValidation(T t);
        protected abstract Task<bool> ExecuteCommand(T t);
        protected abstract string Success { get; }
        protected abstract string Error { get; }
    }
}
