using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Packy.Adapters
{
    /// <summary>
    /// Helps to get or set data into xml files
    /// </summary>
    internal class XmlSerializer
    {

        /// <summary>
        /// Get object into xml
        /// </summary>
        internal static T GetFile<T>(string filename) where T : class
        {
            DataOrganizer.InitDataFolder();

            System.Xml.Serialization.XmlSerializer reader = new System.Xml.Serialization.XmlSerializer(typeof(T));

            var filePath = Path.Combine(DataOrganizer.GetDataFolderPath(), filename);

            if (new FileInfo(filePath).Exists)
            {

                var file = new StreamReader(filePath);
                
                var data = reader.Deserialize(file);
                
                file.Close();

                if (data != null)
                {
                    return (T)data;
                }

            }

            return null;

        }

        /// <summary>
        /// Save object into xml
        /// </summary>
        internal static void SaveFile<T>(T objectInstance, string filename)
        {

            DataOrganizer.InitDataFolder();

            System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(T));

            FileStream file = File.Create(Path.Combine(DataOrganizer.GetDataFolderPath(), filename));

            writer.Serialize(file, objectInstance);

            file.Close();

        }

    }
}
