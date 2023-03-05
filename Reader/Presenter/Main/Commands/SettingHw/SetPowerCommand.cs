using Reader.Model.Main;
using Reader.View;

namespace Reader.Presenter.Main.Commands.SettingHw
{
    public class SetPowerCommand : SetCommandTemplate<int>
    {
        private readonly IMainForm _mainForm;
        private readonly IValidateModel _validateModel;

        public SetPowerCommand(IMainForm mainForm, IViewController viewController, IValidateModel validateModel)
            : base(mainForm, viewController)
        {
            _mainForm = mainForm;
            _validateModel = validateModel;
        }

        protected override Task<bool> CheckConnection() => RFID.Api.CheckHwConnection();
        protected override bool CheckValidation(int index) => _validateModel.SettingHwPower(index);
        protected override async Task<bool> ExecuteCommand(int index)
        {
            bool result = await RFID.Api.SetPowerKey(index);

            if (result)
            {
                _mainForm.SettingHwPowerPrevIndex = index;
            }
            else
            {
                _mainForm.SettingHwPowerIndex = _mainForm.SettingHwPowerPrevIndex;
            }

            return result;
        }
        protected override string Success => Lang.Main.SetPower_Success;
        protected override string Error => Lang.Main.SetPower_Error;
    }
}
