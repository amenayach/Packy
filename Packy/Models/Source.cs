using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packy.Models
{
    /// <summary>
    /// Holds the source file or directory to be packed
    /// </summary>
    public class Source
    {

        /// <summary>
        /// Represents the Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Represents the Filename
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Represents the Fullname
        /// </summary>
        public string Fullname { get; set; }

        /// <summary>
        /// Represents the Directory
        /// </summary>
        public string Directory { get; set; }

        /// <summary>
        /// Represents the file Extension
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// True if Directory, false if file
        /// </summary>
        public bool IsDirectory { get; set; }

        public Source()
        {

        }

        public Source(string fullname, string title)
        {
            LoadMeta(fullname, title);
        }

        public Source(string fullname)
        {
            LoadMeta(fullname, null);
        }

        private void LoadMeta(string fullname, string title)
        {
            this.Fullname = fullname;
            
            this.IsDirectory = new DirectoryInfo(fullname).Exists;

            if (IsDirectory)
            {
                this.Directory = fullname;
                this.Name = new DirectoryInfo(fullname).Name;
                this.Title = string.IsNullOrEmpty(title) ? new DirectoryInfo(fullname).Name : title;
            }
            else
            {

                var directoryInfo = new FileInfo(fullname).Directory;

                if (directoryInfo != null) this.Directory = directoryInfo.FullName;

                var fileInfo = new FileInfo(fullname);
                this.Name = fileInfo.Name;
                this.Extension = fileInfo.Extension;
                this.Title = string.IsNullOrEmpty(title) ? fileInfo.Name : title;

            }
        }
    }
}
