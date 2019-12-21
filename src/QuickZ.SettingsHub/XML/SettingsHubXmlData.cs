using QuickZ.Core.SettingsHub;
using System;

namespace QuickZ.SettingsHub.XML
{
    public class SettingsHubXmlData : ISettingsHubXmlData
    {
        public SettingsHubXmlData(SettingsHubContainer container, string file)
        {
            FileName = file;
            Container = container;
        }

        string fileName;
        public string FileName
        {
            get { return fileName; }
            set
            {
                fileName = value;
            }
        }

        SettingsHubContainer container;
        public SettingsHubContainer Container
        {
            get { return container; }
            set
            {
                container = value;
            }
        }

        ISettingsHubContainer ISettingsHubXmlData.Container
        {
            get
            {
                return Container;
            }

            set
            {
                Container = container;
            }
        }

        public void Import()
        {
            // Read xml file
            try
            {
                QuickZ.Data.Helpers.XmlHelper<SettingsHubContainer>.Deserialize(fileName, ref container, "");
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to read file.", ex);
            }            
        }

        public void Export()
        {
            // Read xml file
            try
            {
                QuickZ.Data.Helpers.XmlHelper<SettingsHubContainer>.Serialize(fileName, container);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to write to file.", ex);
            }

        }

    }
}
