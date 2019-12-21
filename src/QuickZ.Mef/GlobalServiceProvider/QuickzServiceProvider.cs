using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickZ.Mef.GlobalServiceProvider {

    public sealed class QuickzServiceProvider {

        private static readonly Lazy<QuickzServiceProvider> serviceProvider = new Lazy<QuickzServiceProvider>(() => new QuickzServiceProvider());

        IServiceProvider serviceCollection;

        public QuickzServiceProvider() { }

        /// <summary>
        /// Instance for global service provider of MEF.
        /// </summary>
        public static QuickzServiceProvider ServiceInstance {
            get => serviceProvider.Value;
        }

        /// <summary>
        /// The MEF dependency injection resolver.
        /// </summary>
        public IServiceProvider ServiceProvider {
            get => serviceCollection;
            set => serviceCollection = value;
        }

    }
}
