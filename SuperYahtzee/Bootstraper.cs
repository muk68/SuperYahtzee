
using System.Windows;
using Microsoft.Practices.ServiceLocation;
using Prism.Unity;

namespace SuperYahtzee
{
    internal class Bootstraper : UnityBootstrapper
    {
        protected override void InitializeShell()
        {
            Application.Current.MainWindow = (MainWindow)Shell;
            Application.Current.MainWindow.Show();
        }
        protected override DependencyObject CreateShell()
        {
            return ServiceLocator.Current.GetInstance<MainWindow>();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            //((ModuleCatalog)ModuleCatalog).AddModule(typeof(LoggingModuleInfo));
            //((ModuleCatalog)ModuleCatalog).AddModule(typeof(LogTestModuleInfo));
            //((ModuleCatalog)ModuleCatalog).AddModule(typeof(ModuleBInfo), typeof(LoggingModuleInfo).FullName);
        }

        protected override void InitializeModules()
        {
            base.InitializeModules();
            //var mainWindow = (MainWindow)Shell;
            //mainWindow.ViewModel = Container.Resolve<MainWindowViewModel>();
            //mainWindow.Show();
        }
    }
}
