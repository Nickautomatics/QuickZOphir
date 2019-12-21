using Microsoft.Extensions.DependencyInjection;
using QuickZ.Mef.TemporaryImplementation;
using System;
using System.Collections.Generic;
using System.Text;
using static QuickZ.Mef.GlobalServiceProvider.QuickzServiceProvider;

namespace QuickZ.Mef.StartupBuilder {
    public class QuickZDefaultStartupBuilder : IQuickZStartupBuilder {

        public event EventHandler<EventArgs> BuildFinished;

        public QuickZDefaultStartupBuilder() { }

        public IServiceProvider ServiceProvider => ServiceInstance.ServiceProvider;

        public IServiceCollection ServiceCollection { get; set; }

        public void Build() {
            ServiceInstance.ServiceProvider = ServiceCollection.BuildServiceProvider();
            OnBuildFinished(new EventArgs());
        }
        protected virtual void OnBuildFinished(EventArgs e) {
            EventHandler<EventArgs> handler = BuildFinished;
            if (handler != null) {
                handler(this, e);
            }
        }
    }
}
