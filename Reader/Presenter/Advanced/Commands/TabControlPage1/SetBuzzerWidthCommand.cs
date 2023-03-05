using Reader.Model.Advanced;
using Reader.View;

namespace Reader.Presenter.Advanced.Commands.TabControlPage1
{
    public class SetBuzzerWidthCommand : SetCommandTemplate<int>
    {
        private readonly IValidateModel _validateModel;

        public SetBuzzerWidthCommand(IMainForm mainForm, IAdvancedForm advancedForm, IViewController viewController, IValidateModel validateModel)
            : base(mainForm, advancedForm, viewController)
        {
            _validateModel = validateModel;
        }

        protected override Task<bool> CheckConnection() => RFID.Api.CheckHwConnection();
        protected override bool CheckValidation(int index) => _validateModel.BuzzerWidthInput(index);
        protected override Task<bool> ExecuteCommand(int index) => RFID.Api.SetBuzzerWidthKey(index);
        protected override string Success => Lang.Advanced.SetBuzzerWidth_Success;
        protected override string Error => Lang.Advanced.SetBuzzerWidth_Error;
    }
}
