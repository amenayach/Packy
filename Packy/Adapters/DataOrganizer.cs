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
    /// Organize data folders
    /// </summary>
    internal class DataOrganizer
    {

        /// <summary>
        /// Returns the data folder path
        /// </summary>
        internal static string GetDataFolderPath()
        {
            
            return Path.Combine(Application.StartupPath, "Data");

        }

        /// <summary>
        /// Initialize data folder
        /// </summary>
        internal static void InitDataFolder()
        {
            
            var dataFolder = new DirectoryInfo(GetDataFolderPath());

            if (!dataFolder.Exists)
            {
                dataFolder.Create();
            }

        }
    }
}
