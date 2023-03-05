using Reader.Model.Advanced;
using Reader.View;

namespace Reader.Presenter.Advanced.Commands.TabControlPage1
{
    public class SetPowerCommand : SetCommandTemplate<int>
    {
        private readonly IMainForm _mainForm;
        private readonly IValidateModel _validateModel;

        public SetPowerCommand(IMainForm mainForm, IAdvancedForm advancedForm, IViewController viewController, IValidateModel validateModel)
            : base(mainForm, advancedForm, viewController)
        {
            _mainForm = mainForm;
            _validateModel = validateModel;
        }

        protected override Task<bool> CheckConnection() => RFID.Api.CheckHwConnection();
        protected override bool CheckValidation(int index) => _validateModel.PowerInput(index);
        protected override async Task<bool> ExecuteCommand(int index)
        {
            bool result = await RFID.Api.SetPowerKey(index);

            if (result)
            {
                _mainForm.SettingHwPowerIndex = index;
            }

            return result;
        }
        protected override string Success => Lang.Advanced.SetPower_Success;
        protected override string Error => Lang.Advanced.SetPower_Error;
    }
}
