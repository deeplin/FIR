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
        private List<IDisposable> disposableList;

        public SearchControl()
        {
            disposableList = new List<IDisposable>();
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

                disposableList.ToList().ForEach(disposable => disposable.Dispose());
                disposableList.Clear();
            }
        }

        private void Search(WebSite website)
        {
            if(string.IsNullOrEmpty(website.LinkAddress))
            {
                return;
            }

            if(string.IsNullOrEmpty(website.Keyword))
            {
                return;
            }


            IUnityContainer container = UnityConfig.GetConfiguredContainer();
            IObserver<WebSite> observer = container.Resolve<RestGetObserver>();

            IObservable<WebSite> source = Observable
                .Timer(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(Constant.REFRESH_RATE))
                .Select(num => website);
            IDisposable subscription = source.Subscribe(observer);

            disposableList.Add(subscription);
        }
    }
}
