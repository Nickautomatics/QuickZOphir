using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickZ.Core.GlobalInstance {
    /// <summary>
    /// Needs to be confirm...
    /// Jeff: This is am abstract singleton class
    /// </summary>
    /// <typeparam name="T">Class type of the singleton</typeparam>
    public abstract class BaseEngine<T> where T : class {

        /// <summary>
        /// Private static lazy instantiation.
        /// This creates an instance of T via reflection.
        /// Note: A singleton's constructor must be considered private.
        /// </summary>
        private static readonly Lazy<T> instance = new Lazy<T>(() => Activator.CreateInstance(typeof(T), true) as T);

        /// <summary>
        /// Gets the single instance base on the type of T
        /// </summary>
        public static T Self {
            get => instance.Value;
        }
        
    }
}
