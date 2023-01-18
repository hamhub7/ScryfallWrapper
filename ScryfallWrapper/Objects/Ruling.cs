using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScryfallWrapper.Objects
{
    public class Ruling
    {
        /// <summary>
        /// A computer-readable string indicating which company produced this ruling, either wotc or scryfall.
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// The date when the ruling or note was published.
        /// </summary>
        public string PublishedAt { get; set; }

        /// <summary>
        /// The text of the ruling.
        /// </summary>
        public string Comment { get; set; }
    }
}
