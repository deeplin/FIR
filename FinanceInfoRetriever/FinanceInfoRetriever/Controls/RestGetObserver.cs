using FinanceInfoRetriever.Models;
using FinanceInfoRetriever.Parser;
using FinanceInfoRetriever.Utils;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceInfoRetriever.Controls
{
    class RestGetObserver : IObserver<WebSite>
    {
        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }

        public async void OnNext(WebSite webSite)
        {
            var handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                //AllowAutoRedirect = true
            };

            using (HttpClient httpClient = new HttpClient(handler))
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", Constant.DefaultUserAgent);

                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Connection", "keep-alive");
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "*/*");
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate");
                //httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type",
                //    "application/x-www-form-urlencoded");

                string requestUri = String.Format(webSite.LinkAddress, webSite.Keyword);

                HttpResponseMessage responseMessage = await httpClient.GetAsync(requestUri);

                //will throw an exception if not successful
                responseMessage.EnsureSuccessStatusCode();

                string html = await responseMessage.Content.ReadAsStringAsync();

                switch (webSite.Id)
                {
                    case 3:
                        HtmlParser.GetCcgpArticle(html, webSite.SiteName);



                        //return await Task.Run(() => JsonObject.Parse(content));

                        //using (Stream stream = await responseMessage.Content.ReadAsStreamAsync())
                        //using(Stream stream = await httpClient.GetStreamAsync(requestUri))
                        ////using (Stream decompressed = new GZipStream(stream, CompressionMode.Decompress))
                        //using (StreamReader streamReader = new StreamReader(stream))
                        //{
                        //    content = streamReader.ReadToEnd();

                        //}

                        break;
                }
            }
        }


        //public async Task<JsonObject> PostAsync(string uri, string data)
        //{
        //    var httpClient = new HttpClient();
        //    response = await httpClient.PostAsync(uri, new StringContent(data));

        //    response.EnsureSuccessStatusCode();

        //    string content = await response.Content.ReadAsStringAsync();
        //    return await Task.Run(() => JsonObject.Parse(content));
        //}

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
