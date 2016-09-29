using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packy.Models
{

    /// <summary>
    /// Holds the destination data
    /// </summary>
    public class Destination
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
        /// Represents the sources
        /// </summary>
        public List<Source> Sources { get; set; }

        public Destination()
        {

        }

        public Destination(string fullname, string title)
        {
            LoadMeta(fullname, title);
        }

        public Destination(string fullname)
        {
            LoadMeta(fullname, null);
        }

        private void LoadMeta(string fullname, string title)
        {
            this.Fullname = fullname;

            var isDirectory = new DirectoryInfo(fullname).Exists;
            var fileInfo = new FileInfo(fullname);
            var isFile = fileInfo.Exists;

            if (isDirectory)
            {
                this.Name = new DirectoryInfo(fullname).Name;
                this.Title = string.IsNullOrEmpty(title) ? new DirectoryInfo(fullname).Name : title;
            }
            else if (isFile)
            {
                if (fileInfo.Directory != null)
                {

                    LoadMeta(fileInfo.Directory.FullName, title);

                }
                else
                {
                    throw new Exception("Destination should be a folder");
                }
            }
            else
            {
                throw new Exception("Destination should be a folder");
            }
        }

    }

    public class DestinationComparer : IEqualityComparer<Destination>
    {
        public bool Equals(Destination x, Destination y)
        {
            return x != null && y != null && String.Equals(x.Fullname, y.Fullname, StringComparison.CurrentCultureIgnoreCase);
        }

        public int GetHashCode(Destination obj)
        {
            return 0;
        }
    }
}
