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


        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Label label = sender as Label;
            string link = label.Content as string;
            Process.Start(new ProcessStartInfo(link));
        }
    }
}
