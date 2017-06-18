using FinanceInfoRetriever.Models;
using FinanceInfoRetriever.Utils;
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
        private readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        private List<WebSite> webSiteList;

        private XmlDataProvider provider = new XmlDataProvider();
        public SetupPage()
        {
        }

        private void Page_Initialized(object sender, EventArgs e)
        {

            webSiteList = XmlUtil.LoadFromXml<List<WebSite>>(WEB_SITE_FILE);

            DataGridWebSite.CanUserAddRows = false;
            DataGridWebSite.ItemsSource = webSiteList;
        }

        private void DataGridWebSite_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataGrid datagrid = sender as DataGrid;
            object obj = datagrid.CurrentItem;

            if(obj != null)
            {
                WebSite webSite = obj as WebSite;
                Process.Start(new ProcessStartInfo(webSite.SiteAddress));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;
            string name = btn.Name;

            switch (name)
            {
                case ("buttonSave"):
                    Save();
                    break;
                case (""):
                    break;
                case ("clearLog"):
                    break;
            }
        }

        private void Save()
        {
            XmlUtil.SaveToXml<List<WebSite>>(WEB_SITE_FILE, webSiteList);
        }
    }
}
