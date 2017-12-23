using Autofac;
using System;
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
        {
            SplashScreen splashScreen = new SplashScreen("SplashScreen.png");
            splashScreen.Show(true);

            MainWindow shell = new MainWindow();
            shell.Dispatcher.BeginInvoke((Action)delegate
            {
                // Display Nortify Icon
                tb = (TaskbarIcon)Application.Current.Resources["NotifyIcon"];
                // TODO: Add Nortify Icon Menubar

                splashScreen.Close(TimeSpan.Zero);
                shell.Show();
                
            });
            return shell;
            //return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            
            // Show MainWindow
            Application.Current.MainWindow.Show();

        }
        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();
        }
    }
}
