using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickZ.Mef.TemporaryImplementation {
    public interface IQuickZModuleStartup {
        void InitServices(IServiceCollection service);
        void ConfigureServices(IServiceProvider service);
    }
}