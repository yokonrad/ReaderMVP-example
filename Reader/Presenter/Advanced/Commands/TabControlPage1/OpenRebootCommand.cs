using Reader.View;

namespace Reader.Presenter.Advanced.Commands.TabControlPage1
{
    public class OpenRebootCommand : OpenCommandTemplate
    {
        private readonly IAdvancedForm _advancedForm;

        public OpenRebootCommand(IMainForm mainForm, IAdvancedForm advancedForm, IViewController viewController)
            : base(mainForm, advancedForm, viewController)
        {
            _advancedForm = advancedForm;
        }

        protected override Task<bool> CheckConnection() => RFID.Api.CheckHwConnection();
        protected override bool OpenMessageBox() => _advancedForm.OpenRebootMessageBox();
        protected override Task<bool> ExecuteCommand() => RFID.Api.Reboot();
        protected override string Success => Lang.Advanced.Reboot_Success;
        protected override string Error => Lang.Advanced.Reboot_Error;
    }
}
