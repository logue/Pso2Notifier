using Prism.Mvvm;
using System.IO;
using System.Windows.Media;
using System.Xml;

namespace Pso2Notifier.Models
{
    public class EmergencyQuests : BindableBase
    {
        public EmergencyQuests(string configFile="Resources/EmergencyQuests.html")
        {
            // Parse XHTML as XML.
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            XmlReader reader = XmlReader.Create(configFile, settings);
        }
        
        public struct EmergencyQuest
        {
            string referenceText;
            string image;
            string text;
        }
    }
}
