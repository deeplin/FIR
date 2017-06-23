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
        private static readonly string CCGP_PATTERN = @"(?is)<a\shref=\""(?<link>\S+)\""\starget=\""_blank\"">(?<content>.*?)</a><em>(?<time>.*?)</em><span\stitle=\""(?<title>.*?)\"">";

        public static void GetCcgpArticle(string html, string siteName)
        {
            String content= Regex.Replace(html, Constant.TabFilter, "");
            content  = Regex.Replace(content, Constant.EnterFilter, "");

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
    }
}
