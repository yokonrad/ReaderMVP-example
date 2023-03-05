using Reader.Model.Advanced;
using Reader.View;

namespace Reader.Presenter.Advanced.Commands.TabControlPage1
{
    public class SetIpAddressCommand : SetCommandTemplate<string>
    {
        private readonly IValidateModel _validateModel;

        public SetIpAddressCommand(IMainForm mainForm, IAdvancedForm advancedForm, IViewController viewController, IValidateModel validateModel)
            : base(mainForm, advancedForm, viewController)
        {
            _validateModel = validateModel;
        }

        protected override Task<bool> CheckConnection() => RFID.Api.CheckHwConnection();
        protected override bool CheckValidation(string value) => _validateModel.IpAddressInput(value);
        protected override Task<bool> ExecuteCommand(string value) => RFID.Api.SetIpAddress(value);
        protected override string Success => Lang.Advanced.SetIpAddress_Success;
        protected override string Error => Lang.Advanced.SetIpAddress_Error;
    }
}
