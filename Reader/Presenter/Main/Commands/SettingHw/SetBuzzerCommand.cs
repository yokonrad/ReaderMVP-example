using Reader.Model.Main;
using Reader.View;

namespace Reader.Presenter.Main.Commands.SettingHw
{
    public class SetBuzzerCommand : SetCommandTemplate<int>
    {
        private readonly IMainForm _mainForm;
        private readonly IValidateModel _validateModel;

        public SetBuzzerCommand(IMainForm mainForm, IViewController viewController, IValidateModel validateModel)
            : base(mainForm, viewController)
        {
            _mainForm = mainForm;
            _validateModel = validateModel;
        }

        protected override Task<bool> CheckConnection() => RFID.Api.CheckHwConnection();
        protected override bool CheckValidation(int index) => _validateModel.SettingHwBuzzer(index);
        protected override async Task<bool> ExecuteCommand(int index)
        {
            bool result = await RFID.Api.SetBuzzerKey(index);

            if (result)
            {
                _mainForm.SettingHwBuzzerPrevIndex = index;
            }
            else
            {
                _mainForm.SettingHwBuzzerIndex = _mainForm.SettingHwBuzzerPrevIndex;
            }

            return result;
        }
        protected override string Success => Lang.Main.SetBuzzer_Success;
        protected override string Error => Lang.Main.SetBuzzer_Error;
    }
}
