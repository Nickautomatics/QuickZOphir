using System;
using System.Collections.Generic;
using System.Text;

namespace QuickZ.Cipher.Extensions {
    public static class GuidHashExtension {
        public static string Hash(this Guid guid) => CipherEngine.Self.Encrypt(guid.ToString(), true);
    }
}
