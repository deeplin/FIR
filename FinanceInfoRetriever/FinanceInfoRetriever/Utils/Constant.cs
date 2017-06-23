using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceInfoRetriever.Utils
{
    public static class Constant
    {
        public const int REFRESH_RATE = 3000; //SECONDS

        public const string WEB_SITE_FILE = "WebSites.xml";

        public const string DefaultUserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/59.0.3071.104 Safari/537.36";

        public const string TabFilter = @"\t";
        public const string EnterFilter = @"\r\n";
    }
}
