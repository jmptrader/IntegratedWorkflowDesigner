using System.IO;
using Xceed.Wpf.AvalonDock;
using Xceed.Wpf.AvalonDock.Layout.Serialization;

namespace WorkfFlowRehosted
{
    public class Layout
    {
        /// <summary>
        /// Save the docking style to file
        /// </summary>
        /// <param name="dm">the docking manager</param>
        public static void Save(DockingManager dm)
        {
            using (var sw = new StreamWriter("designer.dock"))
            {
                using (StringWriter fs = new StringWriter())
                {
                    XmlLayoutSerializer xmlLayout = new XmlLayoutSerializer(dm);
                    xmlLayout.Serialize(fs);
                    sw.Write(fs.ToString());
                }
            }
        }

        /// <summary>
        /// load the dockign style from file
        /// </summary>
        /// <param name="dm">the docking manager</param>
        public static void Load(DockingManager dm)
        {
            if (File.Exists("designer.dock"))
            {
                XmlLayoutSerializer xmlLayout = new XmlLayoutSerializer(dm);
                using (var fs = new FileStream("designer.dock", FileMode.OpenOrCreate))
                {
                    xmlLayout.Deserialize(fs);
                }
            }
            else
            {
                // load default dock from ressource
            }
        }
    }
}