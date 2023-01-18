using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScryfallWrapper.Objects
{
    public class ScryList<T>
    {
        /// <summary>
        /// An array of the requested objects, in a specific order.
        /// </summary>
        public T[] Data { get; set; }

        /// <summary>
        /// True if this List is paginated and there is a page beyond the current page.
        /// </summary>
        public bool Has_More { get; set; }

        /// <summary>
        /// If there is a page beyond the current page, this field will contain a full API URI to that page. You may submit a HTTP GET request to that URI to continue paginating forward on this List.
        /// </summary>
        public string? Next_Page { get; set; }

        /// <summary>
        /// If this is a list of Card objects, this field will contain the total number of cards found across all pages.
        /// </summary>
        public int? Total_Cards { get; set; }

        /// <summary>
        /// An array of human-readable warnings issued when generating this list, as strings. Warnings are non-fatal issues that the API discovered with your input. In general, they indicate that the List will not contain the all of the information you requested. You should fix the warnings and re-submit your request.
        /// </summary>
        public string[]? Warnings { get; set; }
    }
}
