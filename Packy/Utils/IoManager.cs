using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Packy.Utils
{
    public static class IoManager
    {

        /// <summary>
        /// Browse file(s)
        /// </summary>
        /// <param name="multipleFiles">true for multiple</param>
        /// <param name="filter">file name filter string, which determines the choices that appear in the "Save as file type" or "Files of type" box in the dialog box.</param>
        public static string[] BrowseFiles(bool multipleFiles = false, string filter = "")
        {

            using (var openFileDialog = new OpenFileDialog() { Multiselect = multipleFiles, Filter = filter })
            {

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return openFileDialog.FileNames;
                }

            }

            return null;

        }

    }
}
