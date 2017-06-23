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
                case 2:
                    {
                        string requestUri = webSite.LinkAddress;
                        string contentFormat = "page=1&keyword={0}&sdate=&edate=";
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


                    //return await Task.Run(() => JsonObject.Parse(content));

                    //using (Stream stream = await responseMessage.Content.ReadAsStreamAsync())
                    //using(Stream stream = await httpClient.GetStreamAsync(requestUri))
                    ////using (Stream decompressed = new GZipStream(stream, CompressionMode.Decompress))
                    //using (StreamReader streamReader = new StreamReader(stream))
                    //{
                    //    content = streamReader.ReadToEnd();

                    //}

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


        //public async Task<JsonObject> PostAsync(string uri, string data)
        //{
        //    var httpClient = new HttpClient();
        //    response = await httpClient.PostAsync(uri, new StringContent(data));

        //    response.EnsureSuccessStatusCode();

        //    string content = await response.Content.ReadAsStringAsync();
        //    return await Task.Run(() => JsonObject.Parse(content));
        //}
    }
}
