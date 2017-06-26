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

        public SetupPage()
        {
        }

        private void Page_Initialized(object sender, EventArgs e)
        {
            DataGridWebSite.CanUserAddRows = false;

            IUnityContainer container = UnityConfig.GetConfiguredContainer();
            SystemMetaData searchMetaData = container.Resolve<SystemMetaData>();
            DataGridWebSite.ItemsSource = searchMetaData.WebSiteList;
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

        private void DataGridWebSite_CurrentCellChanged(object sender, EventArgs e)
        {
            labelStatus.Content = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = e.Source as Button;
            string status = "";
            if (button == buttonSave)
            {
                Save();
                status = "已经保存";
            }
            labelStatus.Content = status;
        }

        private void Save()
        {
            IUnityContainer container = UnityConfig.GetConfiguredContainer();
            SystemMetaData systemSetting = container.Resolve<SystemMetaData>();
            XmlUtil.SaveToXml<List<WebSite>>(Constant.WEB_SITE_FILE, systemSetting.WebSiteList);
        }
    }
}
