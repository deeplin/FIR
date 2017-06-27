using FinancialInformationRetrieval.Models;
using FinancialInformationRetrieval.Parser;
using FinancialInformationRetrieval.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FinancialInformationRetrieval.Controls
{
    class HttpObserver : IObserver<WebSite>
    {
        public void OnCompleted()
        {
        }

        public void OnError(Exception error)
        {
        }

        public async void OnNext(WebSite webSite)
        {
            switch (webSite.Id)
            {
                case 1:
                    {
                        DateTime now = DateTime.Now;
                        string dateTo = now.ToString("yyyy-MM-dd");
                        now = now.AddDays(-30);
                        string dateFrom = now.ToString("yyyy-MM-dd");
                        string requestUri = webSite.LinkAddress;
                        string contentFormat = webSite.ContentFormat;
                        string content = String.Format(contentFormat, webSite.Keyword, dateFrom, dateTo);
                        string referer = String.Format(webSite.Referer, webSite.Keyword);
                        string html = await HttpPost(requestUri, content, referer);
                        HtmlParser.GetCnInfoArticle(html, webSite.SiteName);
                    }
                    break;
                case 2:
                    {
                        string requestUri = webSite.LinkAddress;
                        string contentFormat = webSite.ContentFormat;
                        string content = String.Format(contentFormat, webSite.Keyword);
                        string referer = String.Format(webSite.Referer, webSite.Keyword);
                        string html = await HttpPost(requestUri, content, referer);
                        HtmlParser.GetSseInfoArticle(html, webSite.SiteName);
                    }
                    break;
                case 3:
                    {
                        string requestUri = String.Format(webSite.LinkAddress, webSite.Keyword);
                        string html = await HttpGet(requestUri);
                        HtmlParser.GetCcgpArticle(html, webSite.SiteName);
                    }
                    break;
                case 4:
                    {
                        string requestUri = String.Format(webSite.LinkAddress, webSite.Keyword);
                        string html = await HttpGet(requestUri);
                        HtmlParser.GetIfengArticle(html, webSite.SiteName);
                    }
                    break;
                case 5:
                    {
                        string requestUri = String.Format(webSite.LinkAddress, webSite.Keyword);
                        string html = await HttpGet(requestUri);
                        HtmlParser.GetBaiduArticle(html, webSite.SiteName);
                    }
                    break;
            }
        }

        private async Task<string> HttpGet(string requestUri)
        {
            var handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
            };

            using (HttpClient httpClient = new HttpClient(handler))
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", Constant.DefaultUserAgent);

                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Connection", "keep-alive");
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "*/*");
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate");

                //httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type",
                //    "application/x-www-form-urlencoded");

                HttpResponseMessage responseMessage = await httpClient.GetAsync(requestUri);

                //will throw an exception if not successful
                responseMessage.EnsureSuccessStatusCode();
                return await responseMessage.Content.ReadAsStringAsync();
            }
        }

        private async Task<string> HttpPost(string requestUri, string content, string referer)
        {
            var handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
            };

            using (HttpClient httpClient = new HttpClient(handler))
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", Constant.DefaultUserAgent);

                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Connection", "keep-alive");
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "*/*");
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate");
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Language", "zh-CN,zh;q=0.8");
                if (!string.IsNullOrEmpty(referer))
                {
                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Referer", referer);
                }

                HttpContent httpContent = new StringContent(content, Encoding.UTF8, "application/x-www-form-urlencoded");
                HttpResponseMessage responseMessage = await httpClient.PostAsync(requestUri, httpContent);

                //will throw an exception if not successful
                responseMessage.EnsureSuccessStatusCode();
                return await responseMessage.Content.ReadAsStringAsync();
            }
        }
    }
}
