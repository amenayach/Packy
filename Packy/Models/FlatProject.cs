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
    [Serializable]
    public class FlatProject
    {
        
        /// <summary>
        /// Represents the project name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Represents the Tuples of Sources and Destinations
        /// </summary>
        public List<Tuple<string, string>> Tracks { get; set; }
        
    }
}
