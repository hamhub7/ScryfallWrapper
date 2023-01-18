using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScryfallWrapper.Objects
{
    public class BulkData
    {
        /// <summary>
        /// A unique ID for this bulk item.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The Scryfall API URI for this file.
        /// </summary>
        public string Uri { get; set; }

        /// <summary>
        /// A computer-readable string for the kind of bulk item.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// A human-readable name for this file.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// A human-readable description for this file.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The URI that hosts this bulk file for fetching.
        /// </summary>
        public string Download_Uri { get; set; }

        /// <summary>
        /// The time when this file was last updated.
        /// </summary>
        public string Updated_At { get; set; }

        /// <summary>
        /// The size of this file in integer bytes.
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// The MIME type of this file.
        /// </summary>
        public string Content_Type { get; set; }

        /// <summary>
        /// The Content-Encoding encoding that will be used to transmit this file when you download it.
        /// </summary>
        public string Content_Encoding { get; set; }
    }
}
