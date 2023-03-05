using Reader.View;

namespace Reader.Presenter.Main.Commands
{
    public abstract class SetCommandTemplate<T>
    {
        private readonly IMainForm _mainForm;
        private readonly IViewController _viewController;

        public SetCommandTemplate(IMainForm mainForm, IViewController viewController)
        {
            _mainForm = mainForm;
            _viewController = viewController;
        }

        public async Task Execute(T t)
        {
            if (_viewController.IsLocked) return;

            try
            {
                if (!await CheckConnection()) return;

                await _viewController.Refresh(true);

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
                await _viewController.Refresh(false);
            }
        }

        protected abstract Task<bool> CheckConnection();
        protected abstract bool CheckValidation(T t);
        protected abstract Task<bool> ExecuteCommand(T t);
        protected abstract string Success { get; }
        protected abstract string Error { get; }
    }
}
