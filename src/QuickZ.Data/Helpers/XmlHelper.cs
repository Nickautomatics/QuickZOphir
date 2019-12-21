using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace QuickZ.Data.Helpers
{
    public static class XmlHelper<T>
    {

        public static void Serialize(string filename, T value)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextWriter writer = new StreamWriter(filename))
            {
                serializer.Serialize(writer, value);
            }
        }

        public static void Serialize(string filename, T value, string prefix, string xmlns)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(prefix, xmlns);

            using (TextWriter writer = new StreamWriter(filename))
            {
                serializer.Serialize(writer, value, ns);
            }
        }

        public static bool Deserialize(string filename, ref T value)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(T));
            using (TextReader reader = new StreamReader(filename))
            {
                value = (T)deserializer.Deserialize(reader);
            }
            return true;
        }

        public static bool Deserialize(string filename, ref T value, string xmlns)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(T));
            using (TextReader reader = new StreamReader(filename))
            {
                value = (T)deserializer.Deserialize(reader);
            }
            return true;
        }

    }

}
