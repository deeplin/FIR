using FinanceInfoRetriever.Models;
using FinanceInfoRetriever.Utils;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceInfoRetriever.Controls
{
    public class SearchControl
    {
        private CancellationTokenSource cancellationTokenSource;

        public SearchControl()
        {
        }

        public void Start()
        {
            lock (this)
            {
                if(cancellationTokenSource != null)
                {
                    cancellationTokenSource.Cancel();
                }
                cancellationTokenSource = new CancellationTokenSource();
            }

            IUnityContainer container = UnityConfig.GetConfiguredContainer();
            SearchSetting searchSetting = container.Resolve<SearchSetting>();

            ParallelOptions parallelOptions = new ParallelOptions();
            parallelOptions.CancellationToken = cancellationTokenSource.Token;

            List<WebSite> webSiteList = searchSetting.WebSiteList;
            Parallel.ForEach(webSiteList, parallelOptions, website => Search(website));

            int id = Thread.CurrentThread.ManagedThreadId;
        }

        public void Stop()
        {
            lock (this)
            {
                if(cancellationTokenSource != null)
                {
                    cancellationTokenSource.Cancel();
                }
            }

        }

        private void Search(WebSite website)
        {
            string linkAddress = website.LinkAddress;
            if(string.IsNullOrEmpty(linkAddress))
            {
                return;
            }


            return;
        }

    }
}
