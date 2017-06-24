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
            SearchMetaData searchMetaData = container.Resolve<SearchMetaData>();
            DataGridWebSite.ItemsSource = searchMetaData.ArticleList;
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
            Button btn = e.Source as Button;
            string name = btn.Name;

            switch (name)
            {
                case ("buttonSave"):
                    break;
                case ("buttonStart"):
                    break;
                case ("buttonStop"):
                    break;
            }
        }
    }
}
