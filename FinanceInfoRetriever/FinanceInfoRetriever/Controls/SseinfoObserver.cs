using FinanceInfoRetriever.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceInfoRetriever.Controls
{
    class SseinfoObserver : IObserver<WebSite>
    {
        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }

        public async void OnNext(WebSite webSite)
        {
            HttpClient httpClient = new HttpClient();
            Task<string> httpTask = httpClient.GetStringAsync(webSite.LinkAddress);

            string urlContent = await httpTask;

        }

        private string[] GetLinks(string html)
        {
            const string pattern = @"http://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";
            Regex r = new Regex(pattern, RegexOptions.IgnoreCase); //新建正则模式
            MatchCollection m = r.Matches(html); //获得匹配结果
            string[] links = new string[m.Count];

            for (int i = 0; i < m.Count; i++)
            {
                links[i] = m[i].ToString(); //提取出结果
            }
            return links;
        }
    }
}
