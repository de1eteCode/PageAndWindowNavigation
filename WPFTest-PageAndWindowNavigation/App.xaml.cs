using WPFTest_PageAndWindowNavigation.Core;
using System.Windows;
using WPFTest_PageAndWindowNavigation.WindowArea.Views;
using WPFTest_PageAndWindowNavigation.WindowArea.ViewModels;
using System.Linq;

namespace WPFTest_PageAndWindowNavigation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public WindowController WinController = new WindowController();

        public App()
        {
            WinController.RegisterVMAndWindow<LoginVM, Login>();
            WinController.RegisterVMAndWindow<WorkflowVM, Workflow>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            WinController.ShowWindow(new LoginVM());
        }
    }
}
