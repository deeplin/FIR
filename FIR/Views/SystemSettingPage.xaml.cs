using FIR.Models;
using FIR.Utils;
using Microsoft.Practices.Unity;
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

namespace FIR.Views
{
    /// <summary>
    /// Interaction logic for SystemSettingPage.xaml
    /// </summary>
    public partial class SystemSettingPage : Page
    {
        private readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        SystemSetting systemSetting;
        public SystemSettingPage()
        {
            InitializeComponent();
        }

        private void Page_Initialized(object sender, EventArgs e)
        {
            LoadSystemSetting();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int refreshRate = Int32.Parse(refreshRateTextBox.Text);
                int expireTime = Int32.Parse(expireTimeTextBox.Text);

                systemSetting.RefreshRate = refreshRate;
                systemSetting.ExpireTime = expireTime;
                XmlUtil.SaveToXml<SystemSetting>(Constant.SYSTEM_SETTING_FILE, systemSetting);
                LoadSystemSetting();
            }
            catch (Exception ex)
            {
                logger.Warn(ex);
            }
        }

        private void LoadSystemSetting()
        {
            IUnityContainer container = UnityConfig.GetConfiguredContainer();
            systemSetting = container.Resolve<SystemSetting>();
            this.refreshRateTextBox.Text = systemSetting.RefreshRate.ToString();
            this.expireTimeTextBox.Text = systemSetting.ExpireTime.ToString();
        }
    }
}
