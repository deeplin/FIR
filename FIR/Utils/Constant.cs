using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIR.Utils
{
    public static class Constant
    {
        public const int TOTAL_POSTED_ARTICLE = 50;

        public const string WEB_SITE_FILE = "WebSites.config";
        public const string SYSTEM_SETTING_FILE = "SystemSetting.config";

        public const string DefaultUserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.104 Safari/537.36";

        public const string TabFilter = @"\t";
        public const string EnterFilter = @"\r";
        public const string NextLineFilter = @"\n";

        public const string FontFilter = @"<[//]?font.*?>";
        public const string EmFilter = @"<[//]?em>";
    }
}
