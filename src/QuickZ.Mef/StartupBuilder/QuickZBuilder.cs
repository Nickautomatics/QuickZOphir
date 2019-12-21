using Microsoft.Extensions.DependencyInjection;
using QuickZ.Mef.TemporaryImplementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickZ.Mef.StartupBuilder {
    public static class QuickZBuilder {
        /// <summary>
        /// Builds the service collection 
        /// </summary>
        /// <returns>IQuickZStartupBuilder</returns>
        public static IQuickZStartupBuilder CreateDefultBuilder() {
            var builder = new QuickZDefaultStartupBuilder();
            builder.ServiceCollection = new ServiceCollection();
            return builder;
        }
    }
}
