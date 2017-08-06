using FIR.Models;
using FIR.Utils;
using FIR.Views;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FIR
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public void OnStartup(object sender, StartupEventArgs e)
        {
            IUnityContainer container = UnityConfig.GetConfiguredContainer();
            SystemMetaData searchMetaData = container.Resolve<SystemMetaData>();
            searchMetaData.WebSiteList = XmlUtil.LoadFromXml<List<WebSite>>(Constant.WEB_SITE_FILE);
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            logger.Error(e.Exception, "Application unhandled error");
            //表示己经处理过异常，将不会传递异常给操作系统
            e.Handled = true;
        }

        private void Application_SessionEnding(object sender, SessionEndingCancelEventArgs e)
        {
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {

        }

    }
}
