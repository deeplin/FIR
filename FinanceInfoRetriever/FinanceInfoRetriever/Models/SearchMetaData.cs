using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceInfoRetriever.Models
{
    class SearchMetaData
    {
        public SearchMetaData()
        {
            ArticleList = new List<Article>();
        }

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
