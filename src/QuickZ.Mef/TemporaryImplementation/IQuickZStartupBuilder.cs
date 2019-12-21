using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickZ.Mef.TemporaryImplementation {
    public interface IQuickZStartupBuilder {
        event EventHandler<EventArgs> BuildFinished;
        IServiceProvider ServiceProvider { get; }
        IServiceCollection ServiceCollection { get; set; }
        void Build();
    }
}
