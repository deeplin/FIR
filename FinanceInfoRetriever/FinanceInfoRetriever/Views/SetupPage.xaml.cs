using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace FinanceInfoRetriever.Views
{
    /// <summary>
    /// Interaction logic for SetupPage.xaml
    /// </summary>
    public partial class SetupPage : Page
    {
        private const string WEB_SITE_FILE = "WebSites.xml";
        private readonly NLog.Logger mLogger = NLog.LogManager.GetCurrentClassLogger();

        private XmlDataProvider provider = new XmlDataProvider();
        public SetupPage()
        {
        }

        private void Page_Initialized(object sender, EventArgs e)
        {
            XmlDocument document = new XmlDocument();
            document.Load(WEB_SITE_FILE);
            provider.Document = document;
            provider.XPath = @"WebSites/Source";
            PanelWebSite.DataContext = provider;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;
            string name = btn.Name;
        }


        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Label label = sender as Label;
            XmlAttribute attribute = label.Content as XmlAttribute;
            string link = attribute.Value;
            Process.Start(new ProcessStartInfo(link));
        }
    }
}
