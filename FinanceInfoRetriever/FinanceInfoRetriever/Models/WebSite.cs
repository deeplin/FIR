using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FinanceInfoRetriever.Models
{
    public class WebSite
    {
        public WebSite()
        {
            Referer = "";
        }
        public int Id { get; set; }

        public string SiteName { get; set; }

        public string SiteAddress { get; set; }

        public string LinkAddress { get; set; }

        public string Keyword { get; set; }

        public string Referer  { get; set; }

    }
}
