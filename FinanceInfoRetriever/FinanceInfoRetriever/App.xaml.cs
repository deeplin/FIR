using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FinanceInfoRetriever
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public void OnStartup(object sender, StartupEventArgs e)
        {
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            logger.Error(e.Exception, "Application unhandled error");
            //表示己经处理过异常，将不会传递异常给操作系统
            //e.Handled = true;
        }

        private void Application_SessionEnding(object sender, SessionEndingCancelEventArgs e)
        {
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {

        }

    }
}
