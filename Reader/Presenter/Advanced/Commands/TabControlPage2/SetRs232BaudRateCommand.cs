using Reader.Model.Advanced;
using Reader.View;

namespace Reader.Presenter.Advanced.Commands.TabControlPage2
{
    public class SetRs232BaudRateCommand : SetCommandTemplate<int>
    {
        private readonly IValidateModel _validateModel;

        public SetRs232BaudRateCommand(IMainForm mainForm, IAdvancedForm advancedForm, IViewController viewController, IValidateModel validateModel)
            : base(mainForm, advancedForm, viewController)
        {
            _validateModel = validateModel;
        }

        protected override Task<bool> CheckConnection() => RFID.Api.CheckHwConnection();
        protected override bool CheckValidation(int index) => _validateModel.Rs232BaudRateInput(index);
        protected override Task<bool> ExecuteCommand(int index) => RFID.Api.SetRs232BaudRateKey(index);
        protected override string Success => Lang.Advanced.SetRs232BaudRate_Success;
        protected override string Error => Lang.Advanced.SetRs232BaudRate_Error;
    }
}
