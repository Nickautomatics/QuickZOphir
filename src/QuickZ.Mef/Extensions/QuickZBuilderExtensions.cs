using QuickZ.Mef.TemporaryImplementation;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace QuickZ.Mef.Extensions {
    public static class QuickZBuilderExtensions {

        public static IQuickZStartupBuilder PlugModuleStarter<T>(this IQuickZStartupBuilder builder) where T : IQuickZModuleStartup, new() {
            var definer = new T();
            definer.InitServices(builder.ServiceCollection);
            builder.BuildFinished += new EventHandler<EventArgs>((s, e) => {
               definer.ConfigureServices(builder.ServiceProvider);
            });

            return builder;
        }

    }
}
