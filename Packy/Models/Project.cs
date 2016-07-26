using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packy.Models
{
    /// <summary>
    /// Holds project info
    /// </summary>
    public class Project
    {

        /// <summary>
        /// Represents the Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Represents the Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Represents the Destinations
        /// </summary>
        public List<Destination> Destinations { get; set; }

    }
}
