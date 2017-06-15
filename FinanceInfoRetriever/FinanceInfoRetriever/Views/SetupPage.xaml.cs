using System;
using System.Collections.Generic;
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
    /// Interaction logic for SetupPage.xaml
    /// </summary>
    public partial class SetupPage : Page
    {
        private readonly NLog.Logger mLogger = NLog.LogManager.GetCurrentClassLogger();

        public SetupPage()
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;
            string name = btn.Name;

        }

        private void StartServer()
        {

        }

        private void StopServer()
        {

        }

        private int count = 0;
        public void Display(string message)
        {

        }
    }
}
