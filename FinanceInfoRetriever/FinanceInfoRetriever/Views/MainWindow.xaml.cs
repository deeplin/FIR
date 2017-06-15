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
using System.Windows.Shapes;

namespace FinanceInfoRetriever.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Start all services
        private void Window_Initialized(object sender, EventArgs e)
        {
        }

        private Button mOldButton = new Button();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = e.Source as Button;
            button.Foreground = Brushes.Red;
            mOldButton.Foreground = Brushes.Blue;
            mOldButton = button;
            Uri uri = new Uri(button.Tag.ToString(), UriKind.Relative);
            detailFrame.Source = new Uri(button.Tag.ToString(), UriKind.Relative);
        }
    }
}
