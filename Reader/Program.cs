using Reader.Model.Main;
using Reader.Presenter;
using Reader.View;

namespace Reader
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            using MainForm view = new();
            var connectionComModel = new ConnectionComModel();
            var connectionIpModel = new ConnectionIpModel();
            var settingSwModel = new SettingSwModel();
            var validateModel = new ValidateModel();
            _ = new MainPresenter(view, connectionComModel, connectionIpModel, settingSwModel, validateModel);

            Application.Run(view);
        }
    }
}