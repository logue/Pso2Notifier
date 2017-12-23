using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using Windows.Foundation;
using Windows.Graphics.Display;
using Windows.System;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Documents;
using System.IO;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System;
using System.Windows;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Pso2Notifier.Models;
using Pso2Notifier.ViewModels;
using System.Linq;
using Pso2Notifier.ShellHelpers;
using MS.WindowsAPICodePack.Internal;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;

namespace Pso2Notifier.Views
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private const String APP_ID = "Logue.Pso2Notifier";
        public MainWindow()
        {
            
            InitializeComponent();
            //DataContext = new MainWindowViewModel(DialogCoordinator.Instance);
            TryCreateShortcut();

        }

        // In order to display toasts, a desktop application must have a shortcut on the Start menu.
        // Also, an AppUserModelID must be set on that shortcut.
        // The shortcut should be created as part of the installer. The following code shows how to create
        // a shortcut and assign an AppUserModelID using Windows APIs. You must download and include the 
        // Windows API Code Pack for Microsoft .NET Framework for this code to function
        //
        // Included in this project is a wxs file that be used with the WiX toolkit
        // to make an installer that creates the necessary shortcut. One or the other should be used.
        private bool TryCreateShortcut()
        {
            String shortcutPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Microsoft\\Windows\\Start Menu\\Programs\\Pso2Notifier.lnk";
            if (!File.Exists(shortcutPath))
            {
                InstallShortcut(shortcutPath);
                return true;
            }
            return false;
        }

        private void InstallShortcut(String shortcutPath)
        {
            // Find the path to the current executable
            String exePath = Process.GetCurrentProcess().MainModule.FileName;
            IShellLinkW newShortcut = (IShellLinkW)new CShellLink();

            // Create a shortcut to the exe
            ShellHelpers.ErrorHelper.VerifySucceeded(newShortcut.SetPath(exePath));
            ShellHelpers.ErrorHelper.VerifySucceeded(newShortcut.SetArguments(""));

            // Open the shortcut property store, set the AppUserModelId property
            IPropertyStore newShortcutProperties = (IPropertyStore)newShortcut;

            using (PropVariant appId = new PropVariant(APP_ID))
            {
                ShellHelpers.ErrorHelper.VerifySucceeded(newShortcutProperties.SetValue(SystemProperties.System.AppUserModel.ID, appId));
                ShellHelpers.ErrorHelper.VerifySucceeded(newShortcutProperties.Commit());
            }

            // Commit the shortcut to disk
            IPersistFile newShortcutSave = (IPersistFile)newShortcut;

            ShellHelpers.ErrorHelper.VerifySucceeded(newShortcutSave.Save(shortcutPath, true));
        }
        private void ToastActivated(ToastNotification sender, object e)
        {
            Dispatcher.Invoke(() =>
            {
                Activate();
                Debug.WriteLine("The user activated the toast.");
            });
        }

        private void ToastDismissed(ToastNotification sender, ToastDismissedEventArgs e)
        {
            String outputText = "";
            switch (e.Reason)
            {
                case ToastDismissalReason.ApplicationHidden:
                    outputText = "The app hid the toast using ToastNotifier.Hide";
                    break;
                case ToastDismissalReason.UserCanceled:
                    outputText = "The user dismissed the toast";
                    break;
                case ToastDismissalReason.TimedOut:
                    outputText = "The toast has timed out";
                    break;
            }

            Dispatcher.Invoke(() =>
            {
                Debug.WriteLine(outputText);
            });
        }

        private void ToastFailed(ToastNotification sender, ToastFailedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                Debug.WriteLine("The toast encountered an error.");
            });
        }


        private void Button_Test_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            System.Diagnostics.Process pro = System.Diagnostics.Process.GetCurrentProcess();

            Debug.WriteLine(pro.Id.ToString() + " / " + pro.ProcessName + " / " + pro.ToString());

            // Get a toast XML template 
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastImageAndText04);
            Debug.WriteLine(toastXml.GetXml());

            // Fill in the text elements 
            XmlNodeList stringElements = toastXml.GetElementsByTagName("text");
            for (int i = 0; i < stringElements.Length; i++)
            {
                stringElements[i].AppendChild(toastXml.CreateTextNode("Line " + i));
            }

            // Specify the absolute path to an image 
            String imagePath = "file:///" + Path.GetFullPath("Resources/Wopal_Beach.png");
            //String imagePath = "ms-appx:///Wopal_Beach.png";
            XmlNodeList imageElements = toastXml.GetElementsByTagName("image");
            imageElements[0].Attributes.GetNamedItem("src").NodeValue = imagePath;

            Debug.WriteLine(imagePath);
            // Create the toast and attach event listeners 
            ToastNotification toast = new ToastNotification(toastXml);
            toast.Activated += ToastActivated; 
            toast.Dismissed += ToastDismissed; 
            toast.Failed += ToastFailed; 

            // Show the toast. Be sure to specify the AppUserModelId on your application's shortcut! 
            ToastNotificationManager.CreateToastNotifier(APP_ID).Show(toast);
        }
    }
}