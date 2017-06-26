using FinanceInfoRetriever.Controls;
using FinanceInfoRetriever.Models;
using FinanceInfoRetriever.Utils;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
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
            IUnityContainer container = UnityConfig.GetConfiguredContainer();
            container.RegisterInstance(this);

            SystemMetaData systemMetaData = container.Resolve<SystemMetaData>();
            DataGridWebSite.ItemsSource = systemMetaData.ArticleList;

            buttonStart.DataContext = systemMetaData.ServiceStatus;
            buttonStop.DataContext = systemMetaData.ServiceStatus;

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
                Start();
            }
            else if(button == buttonStop)
            {
                buttonStop.IsEnabled = false;
                status = "查询结束";
                Stop();
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

        public void BindDataGrid()
        {
            DataGridWebSite.Dispatcher.Invoke(() =>
            {
                SortDataGrid(DataGridWebSite);
            });
        }

        public static void SortDataGrid(DataGrid dataGrid, int columnIndex = 0, ListSortDirection sortDirection = ListSortDirection.Descending)
        {
            var column = dataGrid.Columns[columnIndex];

            // Clear current sort descriptions
            dataGrid.Items.SortDescriptions.Clear();

            // Add the new sort description
            dataGrid.Items.SortDescriptions.Add(new SortDescription(column.SortMemberPath, sortDirection));

            // Apply sort
            foreach (var col in dataGrid.Columns)
            {
                col.SortDirection = null;
            }
            column.SortDirection = sortDirection;

            // Refresh items to display sort
            dataGrid.Items.Refresh();
        }
    }
}
