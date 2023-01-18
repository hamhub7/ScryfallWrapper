using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScryfallWrapper.Objects
{
    public class Catalog
    {
        /// <summary>
        /// A link to the current catalog on Scryfall’s API.
        /// </summary>
        public string Uri { get; set; }

        /// <summary>
        /// The number of items in the data array.
        /// </summary>
        public int TotalValue { get; set; }

        /// <summary>
        /// An array of datapoints, as strings.
        /// </summary>
        public string[] Data { get; set; }
    }
}
