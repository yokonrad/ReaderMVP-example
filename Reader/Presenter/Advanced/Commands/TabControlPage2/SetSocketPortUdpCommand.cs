using Reader.Model.Advanced;
using Reader.View;

namespace Reader.Presenter.Advanced.Commands.TabControlPage1
{
    public class SetSocketPortUdpCommand : SetCommandTemplate<int>
    {
        private readonly IValidateModel _validateModel;

        public SetSocketPortUdpCommand(IMainForm mainForm, IAdvancedForm advancedForm, IViewController viewController, IValidateModel validateModel)
            : base(mainForm, advancedForm, viewController)
        {
            _validateModel = validateModel;
        }

        protected override Task<bool> CheckConnection() => RFID.Api.CheckHwConnection();
        protected override bool CheckValidation(int value) => _validateModel.SocketPortUdpInput(value);
        protected override Task<bool> ExecuteCommand(int value) => RFID.Api.SetSocketPortUdp(value);
        protected override string Success => Lang.Advanced.SetSocketPortUdp_Success;
        protected override string Error => Lang.Advanced.SetSocketPortUdp_Error;
    }
}
