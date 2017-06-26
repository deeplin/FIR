using FinanceInfoRetriever.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceInfoRetriever.Models
{
    class SystemMetaData
    {
        public SystemMetaData()
        {
            ArticleList = new List<Article>();
            ServiceStatus = new ServiceStatus();
        }

        public ServiceStatus ServiceStatus { get; set; }

        public List<WebSite> WebSiteList { get; set; }

        public List<Article> ArticleList { get; set; }

        public void AddArticle(Article article)
        {
            lock (ArticleList)
            {
                ArticleList.Add(article);
                while(ArticleList.Count > 100)
                {
                    ArticleList.RemoveAt(0);
                }
            }
        }
    }
}
