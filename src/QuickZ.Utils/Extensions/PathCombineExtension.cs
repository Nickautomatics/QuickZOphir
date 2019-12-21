using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickZ.Utils.Extensions {
    public static class PathCombineExtension {
        public static string CombinePath(this string original, string nextDir) => Path.Combine(original, nextDir);
    }
}
