using Autofac;
using Prism.Autofac;
using System.Windows;
using Pso2Notifier.Views;
using Pso2Notifier.Models;
using Hardcodet.Wpf.TaskbarNotification;
using Prism.Modularity;

namespace Pso2Notifier
{
    class Bootstrapper : AutofacBootstrapper
    {
        private TaskbarIcon tb;

        protected override DependencyObject CreateShell()
            => Container.Resolve<MainWindow>();

        protected override void InitializeShell()
        {
            // Display Nortify Icon
            tb = (TaskbarIcon)Application.Current.Resources["NotifyIcon"];
            // TODO: Add Nortify Icon Menubar

            

            // Show MainWindow
            Application.Current.MainWindow.Show();

        }
    }
}
