using FinanceInfoRetriever.Models;
using FinanceInfoRetriever.Utils;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
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
            Stop();

            cancellationTokenSource = new CancellationTokenSource();

            IUnityContainer container = UnityConfig.GetConfiguredContainer();
            SearchSetting searchSetting = container.Resolve<SearchSetting>();

            List<WebSite> webSiteList = searchSetting.WebSiteList;
            Parallel.ForEach(webSiteList, website => Search(website));

        }

        public void Stop()
        {
            lock (this)
            {
                if(cancellationTokenSource != null)
                {
                    cancellationTokenSource.Cancel();
                    cancellationTokenSource.Dispose();
                    cancellationTokenSource = null;
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

            switch (website.Id)
            {
                case 2:
                    IUnityContainer container = UnityConfig.GetConfiguredContainer();
                    IObserver<WebSite> observer = container.Resolve<SseinfoObserver>();

                    IObservable<WebSite> source = Observable.Interval(TimeSpan.FromSeconds(Constants.REFRESH_RATE))
                        .Select(num => website);
                    IDisposable subscription = source.Subscribe(observer);
                    break;
            }


        }

    }
}
