using Reader.Model.Main;
using Reader.View;

namespace Reader.Presenter.Main.Commands.SettingHw
{
    public class SetTagFilterCommand : SetCommandTemplate<int>
    {
        private readonly IMainForm _mainForm;
        private readonly IValidateModel _validateModel;

        public SetTagFilterCommand(IMainForm mainForm, IViewController viewController, IValidateModel validateModel)
            : base(mainForm, viewController)
        {
            _mainForm = mainForm;
            _validateModel = validateModel;
        }

        protected override Task<bool> CheckConnection() => RFID.Api.CheckHwConnection();
        protected override bool CheckValidation(int index) => _validateModel.SettingHwTagFilter(index);
        protected override async Task<bool> ExecuteCommand(int index)
        {
            bool result = await RFID.Api.SetTagFilterKey(index);

            if (result)
            {
                _mainForm.SettingHwTagFilterPrevIndex = index;
            }
            else
            {
                _mainForm.SettingHwTagFilterIndex = _mainForm.SettingHwTagFilterPrevIndex;
            }

            return result;
        }
        protected override string Success => Lang.Main.SetTagFilter_Success;
        protected override string Error => Lang.Main.SetTagFilter_Error;
    }
}
