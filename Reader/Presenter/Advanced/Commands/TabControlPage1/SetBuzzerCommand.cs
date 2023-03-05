using Reader.Model.Advanced;
using Reader.View;

namespace Reader.Presenter.Advanced.Commands.TabControlPage1
{
    public class SetBuzzerCommand : SetCommandTemplate<int>
    {
        private readonly IMainForm _mainForm;
        private readonly IValidateModel _validateModel;

        public SetBuzzerCommand(IMainForm mainForm, IAdvancedForm advancedForm, IViewController viewController, IValidateModel validateModel)
            : base(mainForm, advancedForm, viewController)
        {
            _mainForm = mainForm;
            _validateModel = validateModel;
        }

        protected override Task<bool> CheckConnection() => RFID.Api.CheckHwConnection();
        protected override bool CheckValidation(int index) => _validateModel.BuzzerInput(index);
        protected override async Task<bool> ExecuteCommand(int index)
        {
            bool result = await RFID.Api.SetBuzzerKey(index);

            if (result)
            {
                _mainForm.SettingHwBuzzerIndex = index;
            }

            return result;
        }
        protected override string Success => Lang.Advanced.SetBuzzer_Success;
        protected override string Error => Lang.Advanced.SetBuzzer_Error;
    }
}
