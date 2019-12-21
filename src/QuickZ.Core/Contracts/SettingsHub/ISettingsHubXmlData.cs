using System;
using System.Linq;

namespace QuickZ.Core.SettingsHub
{
    public interface ISettingsHubXmlData
    {
        ISettingsHubContainer Container { get; set; }
        string FileName { get; set; }
        void Import();
        void Export();
    }
}
