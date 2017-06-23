using FinanceInfoRetriever.Models;
using FinanceInfoRetriever.Utils;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FinanceInfoRetriever.Parser
{
    class HtmlParser
    {
        private const string CCGP_PATTERN = @"(?is)<a\shref=\""(?<link>\S+)\""\starget=\""_blank\"">(?<content>.*?)</a><em>(?<time>.*?)</em><span\stitle=\""(?<title>.*?)\"">";

        private const string SSEINFO_PATTERN = @"(?is)<a\shref='\S+'&nbsp;>:(?<title>[\u4e00-\u9fa5()\d]*)</a>(?<request>.*?)</div>.*?<span>(?<time>.*?)</span>.*?""m_feed_txt.*?>(?<response>[^<]*)";

        public static void GetCcgpArticle(string html, string siteName)
        {
            String content= Regex.Replace(html, Constant.TabFilter, "");
            content  = Regex.Replace(content, Constant.EnterFilter, "");
            content = Regex.Replace(content, Constant.NextLineFilter, "");

            IUnityContainer container = UnityConfig.GetConfiguredContainer();
            SearchMetaData searchMetaData = container.Resolve<SearchMetaData>();

            MatchCollection collection = Regex.Matches(content, CCGP_PATTERN);
            foreach (Match m in collection)
            {
                Article article = container.Resolve<Article>();
                article.Title = m.Groups["title"].Value;
                article.Content = m.Groups["content"].Value;
                article.Link = m.Groups["link"].Value;
                article.PublishDate = m.Groups["time"].Value;
                article.SiteName = siteName;
                searchMetaData.AddArticle(article);
            }
        }


        public static void GetSseInfoArticle(string html, string siteName)
        {
            String content = Regex.Replace(html, Constant.TabFilter, "");
            content = Regex.Replace(content, Constant.EnterFilter, "");
            content = Regex.Replace(content, Constant.NextLineFilter, "");
            content = Regex.Replace(content, Constant.FontFilter, "");

            IUnityContainer container = UnityConfig.GetConfiguredContainer();
            SearchMetaData searchMetaData = container.Resolve<SearchMetaData>();

            MatchCollection collection = Regex.Matches(content, SSEINFO_PATTERN);
            foreach (Match m in collection)
            {
                string response = m.Groups["response"].Value;
                if (!string.IsNullOrWhiteSpace(response))
                {
                    Article article = container.Resolve<Article>();
                    article.Title = m.Groups["title"].Value;
                    article.Content = "问题: " + m.Groups["request"].Value + "\n" + "回答: " + response;
                    article.Link = null;
                    article.PublishDate = m.Groups["time"].Value;
                    article.SiteName = siteName;
                    searchMetaData.AddArticle(article);
                }
            }
        }
    }
}
