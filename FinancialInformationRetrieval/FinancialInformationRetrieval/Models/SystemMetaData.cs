using FinancialInformationRetrieval.Utils;
using FinancialInformationRetrieval.Views;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialInformationRetrieval.Models
{
    class SystemMetaData
    {
        public SystemMetaData()
        {
            ServiceStatus = new ServiceStatus();
            ArticleList = new List<Article>();
            ArticleHashSet = new HashSet<int>();
        }

        public ServiceStatus ServiceStatus { get; set; }

        public List<WebSite> WebSiteList { get; set; }

        public List<Article> ArticleList { get; set; }
        public ISet<int> ArticleHashSet { get; set; }
        private int index = 0;
        public void AddArticle(Article article)
        {
            //是否10分钟内
            DateTime now = DateTime.Now;
            TimeSpan passed = now.Subtract(article.PublishDate);
            if (passed.TotalMinutes > Constant.ARTICLE_TO_BE_POSTED)
            {
                return;
            }

            int hashCode = article.GetHashCode();
            lock (ArticleHashSet)
            {
                if (!ArticleHashSet.Contains(hashCode))
                {
                    ArticleHashSet.Add(hashCode);

                    IUnityContainer container = UnityConfig.GetConfiguredContainer();
                    ResultPage setupPage = container.Resolve<ResultPage>();

                    article.Id = string.Format("{0:00000}", index++);
                    ArticleList.Add(article);
                    while (ArticleList.Count > Constant.TOTAL_POSTED_ARTICLE)
                    {
                        ArticleList.RemoveAt(0);
                    }
                    setupPage.BindDataGrid();
                }
            }
        }
    }
}
