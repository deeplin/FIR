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

namespace FinanceInfoRetriever.Views
{
    /// <summary>
    /// Interaction logic for ResultPage.xaml
    /// </summary>
    public partial class ResultPage : Page
    {
        public ResultPage()
        {
            InitializeComponent();
        }

        private void Page_Initialized(object sender, EventArgs e)
        {
            DataGridWebSite.CanUserAddRows = false;

            IUnityContainer container = UnityConfig.GetConfiguredContainer();
            SystemMetaData systemMetaData = container.Resolve<SystemMetaData>();
            DataGridWebSite.ItemsSource = systemMetaData.ArticleList;

            DataContext = systemMetaData.ServiceStatus;
            //buttonStop.DataContext = systemMetaData.ServiceStatus;
        }

        private void DataGridWebSite_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataGrid datagrid = sender as DataGrid;
            object obj = datagrid.CurrentItem;

            if (obj != null)
            {
                Article article = obj as Article;
                if (article.Link != null)
                {
                    Process.Start(new ProcessStartInfo(article.Link));
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IUnityContainer container = UnityConfig.GetConfiguredContainer();
            SystemMetaData systemMetaData = container.Resolve<SystemMetaData>();

            Button button = e.Source as Button;

            string status = "";
            if (button == buttonStart)
            {
                buttonStart.IsEnabled = false;
                status = "查询开始";
            }
            else if(button == buttonStop)
            {
                buttonStop.IsEnabled = false;
                status = "查询结束";
            }
            else if(button == buttonDelete)
            {

            }
            labelStatus.Content = status;
        }

        private void Start()
        {
            IUnityContainer container = UnityConfig.GetConfiguredContainer();
            SearchControl searchControl = container.Resolve<SearchControl>();
            searchControl.Start();
        }

        private void Stop()
        {
            IUnityContainer container = UnityConfig.GetConfiguredContainer();
            SearchControl searchControl = container.Resolve<SearchControl>();
            searchControl.Stop();
        }
    }
}
