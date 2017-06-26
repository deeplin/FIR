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
        private List<IDisposable> disposableList;

        public SearchControl()
        {
            disposableList = new List<IDisposable>();
        }

        public void Start()
        {
            lock (this)
            {
                Stop();

                IUnityContainer container = UnityConfig.GetConfiguredContainer();
                SystemMetaData systemMetaData = container.Resolve<SystemMetaData>();

                List<WebSite> webSiteList = systemMetaData.WebSiteList;

                Parallel.ForEach(webSiteList, website => Search(website));
            }
        }

        public void Stop()
        {
            lock (this)
            {
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
            IObserver<WebSite> httpObserver = container.Resolve<HttpObserver>();

            IObservable<WebSite> source = Observable
                .Timer(TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(Constant.REFRESH_RATE))
                .Select(num => website);
            IDisposable subscription = source.Subscribe(httpObserver);

            disposableList.Add(subscription);
        }
    }
}
