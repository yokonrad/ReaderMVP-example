using Reader.Model.Advanced;
using Reader.View;

namespace Reader.Presenter.Advanced.Commands.TabControlPage2
{
    public class SetBusAddressCommand : SetCommandTemplate<int>
    {
        private readonly IValidateModel _validateModel;

        public SetBusAddressCommand(IMainForm mainForm, IAdvancedForm advancedForm, IViewController viewController, IValidateModel validateModel)
            : base(mainForm, advancedForm, viewController)
        {
            _validateModel = validateModel;
        }

        protected override Task<bool> CheckConnection() => RFID.Api.CheckHwConnection();
        protected override bool CheckValidation(int index) => _validateModel.BusAddressInput(index);
        protected override Task<bool> ExecuteCommand(int index) => RFID.Api.SetBusAddressKey(index);
        protected override string Success => Lang.Advanced.SetBusAddress_Success;
        protected override string Error => Lang.Advanced.SetBusAddress_Error;
    }
}
