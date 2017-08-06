using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIR.Models
{
    public class WebSite
    {
        public WebSite()
        {
            Referer = "";
            ContentFormat = "";
            Keyword = "";
        }
        public int Id { get; set; }

        public string SiteName { get; set; }

        public string SiteAddress { get; set; }

        public string LinkAddress { get; set; }

        public string Keyword { get; set; }

        public string Referer { get; set; }

        public string ContentFormat { get; set; }

        public WebSite Clone()
        {
            WebSite webSite = new WebSite();
            webSite.Id = Id;
            webSite.SiteName = SiteName;
            webSite.SiteAddress = SiteAddress;
            webSite.LinkAddress = LinkAddress;
            webSite.Keyword = Keyword;
            webSite.Referer = Referer;
            webSite.ContentFormat = ContentFormat;
            return webSite;
        }
    }
}
