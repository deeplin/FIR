using FinanceInfoRetriever.Models;
using FinanceInfoRetriever.Utils;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FinanceInfoRetriever.Parser
{
    class HtmlParser
    {
        private const string CCGP_PATTERN = @"(?is)<a\shref=\""(?<link>\S+)\""\starget=\""_blank\"">(?<content>.*?)</a><em>(?<time>.*?)</em><span\stitle=\""(?<title>.*?)\"">";

        private const string SSEINFO_PATTERN = @"(?is)<a\shref='\S+'&nbsp;>:(?<title>[\u4e00-\u9fa5()\d]*)</a>(?<request>.*?)</div>.*?""m_feed_txt.*?>(?<response>[^<\s]+).*?<span>(?<time>.*?)</span>";

        private const string IFENG_PATTERN = @"(?is)<a\shref=""(?<link>\S+)"" target=""_blank"">(?<title>[^<]*)<.*?<p>(?<content>[^<]*)<.*?<p>[^ ]* (?<time>[^<]+)<";

        private const string CNINFO_PATTERN = @"(?is)<a[^>]+>(?<title>[^<]*)</a>[^>]*>(?<request>[^<]*)</a>.*?questionId[^>]*target=""_blank"">(?<response>[^<]*)</a>.*?date"">(?<time>[^<]*)";

        //Id = 1 互动易 Post
        public static void GetCnInfoArticle(string html, string siteName)
        {
            html = Regex.Replace(html, Constant.TabFilter, "");
            html = Regex.Replace(html, Constant.EnterFilter, "");
            html = Regex.Replace(html, Constant.NextLineFilter, "");
            html = Regex.Replace(html, Constant.FontFilter, "");

            //做标记
            html = Regex.Replace(html, @"<a class=""blue2"" href=""http://irm.cninfo.com.cn/ssessgs/", @"<><a class=""blue2"" href=""http://irm.cninfo.com.cn/ssessgs/");

            IUnityContainer container = UnityConfig.GetConfiguredContainer();
            SearchMetaData searchMetaData = container.Resolve<SearchMetaData>();

            string pattern = @"<>";
            string timePattern = "[年月日]";
            string[] spliteString = Regex.Split(html, pattern);

            spliteString.ToList().ForEach(str =>
            {
                Match match = Regex.Match(str, CNINFO_PATTERN);
                if (match.Success)
                {
                    Article article = container.Resolve<Article>();
                    string time = match.Groups["time"].Value;
                    time = Regex.Replace(time, timePattern, " ");
                    article.PublishDate = DateTime.ParseExact(time, "yyyy MM dd  HH:mm", CultureInfo.InvariantCulture);

                    article.Title = match.Groups["title"].Value;
                    article.Content = "问题: " + match.Groups["request"].Value + "\n" + "回答: " + match.Groups["response"].Value;
                    article.Link = null;

                    article.SiteName = siteName;
                    searchMetaData.AddArticle(article);
                }
            });
        }


        //Id = 2
        public static void GetSseInfoArticle(string html, string siteName)
        {
            html = Regex.Replace(html, Constant.TabFilter, "");
            html = Regex.Replace(html, Constant.EnterFilter, "");
            html = Regex.Replace(html, Constant.NextLineFilter, "");
            html = Regex.Replace(html, Constant.FontFilter, "");

            //做标记
            html = Regex.Replace(html, @"<a href='user.do\?uid=", "<><a href='user.do?uid=");

            IUnityContainer container = UnityConfig.GetConfiguredContainer();
            SearchMetaData searchMetaData = container.Resolve<SearchMetaData>();

            string pattern = @"<>";
            string[] spliteString = Regex.Split(html, pattern);

            spliteString.ToList().ForEach(str =>
            {
                Match match = Regex.Match(str, SSEINFO_PATTERN);
                if (match.Success)
                {
                    DateTime? time = GetTime(match.Groups["time"].Value);
                    if(time != null)
                    {
                        Article article = container.Resolve<Article>();
                        article.PublishDate = (DateTime)time;

                        article.Title = match.Groups["title"].Value;
                        article.Content = "问题: " + match.Groups["request"].Value + "\n" + "回答: " + match.Groups["response"].Value;
                        article.Link = null;

                        article.SiteName = siteName;
                        searchMetaData.AddArticle(article);
                    }
                }
            });
        }

        private static DateTime? GetTime(string html)
        {
            string hourPattern = @"(?<hour>\d)小时前";
            Match hourMatch = Regex.Match(html, hourPattern);
            if (hourMatch.Success)
            {
                DateTime time = DateTime.Now;
                int passed = Int32.Parse(hourMatch.Groups["hour"].Value);
                time.AddHours(passed * -1);
                return time;
            }

            string minutePattern = @"(?<minute>\d)分钟前";
            Match minuteMatch = Regex.Match(html, minutePattern);
            if (minuteMatch.Success)
            {
                DateTime time = DateTime.Now;
                int passed = Int32.Parse(minuteMatch.Groups["minute"].Value);
                time.AddMinutes(passed * -1);
                return time;
            }
            return null;
        }

        //Id = 3
        public static void GetCcgpArticle(string html, string siteName)
        {
            html = Regex.Replace(html, Constant.TabFilter, "");
            html = Regex.Replace(html, Constant.EnterFilter, "");
            html = Regex.Replace(html, Constant.NextLineFilter, "");

            IUnityContainer container = UnityConfig.GetConfiguredContainer();
            SearchMetaData searchMetaData = container.Resolve<SearchMetaData>();

            MatchCollection collection = Regex.Matches(html, CCGP_PATTERN);
            foreach (Match match in collection)
            {
                Article article = container.Resolve<Article>();
                article.Title = match.Groups["title"].Value;
                article.Content = match.Groups["content"].Value;
                article.Link = match.Groups["link"].Value;
                article.PublishDate = DateTime.Parse(match.Groups["time"].Value);
                article.SiteName = siteName;
                searchMetaData.AddArticle(article);
            }
        }

        //Id = 4
        public static void GetIfengArticle(string html, string siteName)
        {
            html = Regex.Replace(html, Constant.TabFilter, "");
            html = Regex.Replace(html, Constant.EnterFilter, "");
            html = Regex.Replace(html, Constant.NextLineFilter, "");
            html = Regex.Replace(html, Constant.FontFilter, "");

            //做标记
            html = Regex.Replace(html, @"<a href=""http:", @"<><a href=""http:");

            IUnityContainer container = UnityConfig.GetConfiguredContainer();
            SearchMetaData searchMetaData = container.Resolve<SearchMetaData>();

            string pattern = @"<>";
            string[] spliteString = Regex.Split(html, pattern);

            spliteString.ToList().ForEach(str =>
            {
                Match match = Regex.Match(str, IFENG_PATTERN);
                if (match.Success)
                {
                    string time = match.Groups["time"].Value;
                    Article article = container.Resolve<Article>();
                    article.PublishDate = DateTime.ParseExact(time, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

                    article.Title = match.Groups["title"].Value;
                    article.Content = match.Groups["content"].Value;
                    article.Link = match.Groups["link"].Value;

                    article.SiteName = siteName;
                    searchMetaData.AddArticle(article);
                }
            });
        }
    }
}
