using FinanceInfoRetriever.Controls;
using FinanceInfoRetriever.Models;
using FinanceInfoRetriever.Utils;
using Microsoft.Practices.Unity;
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

        private readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        private XmlDataProvider provider = new XmlDataProvider();
        public SetupPage()
        {

        }

        private void Page_Initialized(object sender, EventArgs e)
        {
            DataGridWebSite.CanUserAddRows = false;

            IUnityContainer container = UnityConfig.GetConfiguredContainer();
            SearchSetting searchSetting = container.Resolve<SearchSetting>();
            DataGridWebSite.ItemsSource = searchSetting.WebSiteList;
        }

        private void DataGridWebSite_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataGrid datagrid = sender as DataGrid;
            object obj = datagrid.CurrentItem;

            if (obj != null)
            {
                WebSite webSite = obj as WebSite;
                Process.Start(new ProcessStartInfo(webSite.SiteAddress));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;
            string name = btn.Name;

            string status = "";
            switch (name)
            {
                case ("buttonSave"):
                    Save();
                    status = "已经保存";
                    break;
                case ("buttonStart"):
                    Start();
                    buttonStart.IsEnabled = false;
                    buttonStop.IsEnabled = true;
                    status = "查询启动";
                    break;
                case ("buttonStop"):
                    buttonStart.IsEnabled = true;
                    buttonStop.IsEnabled = false;
                    status = "查询结束";
                    break;
            }
            labelStatus.Content = status;
        }

        private void Save()
        {
            IUnityContainer container = UnityConfig.GetConfiguredContainer();
            SearchSetting searchSetting = container.Resolve<SearchSetting>();
            XmlUtil.SaveToXml<List<WebSite>>(Constants.WEB_SITE_FILE, searchSetting.WebSiteList);
        }

        private void Start()
        {
            IUnityContainer container = UnityConfig.GetConfiguredContainer();
            SearchControl searchControl = container.Resolve<SearchControl>();
            searchControl.Start();
        }

    }
}
