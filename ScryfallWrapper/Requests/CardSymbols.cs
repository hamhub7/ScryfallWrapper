using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ScryfallWrapper.Requests
{
    public partial class Scryfall
    {
        private const string CARD_SYMBOLS = "/symbology";

        /// <summary>
        /// Returns a List of all Card Symbols.
        /// </summary>
        /// <param name="format">The data format to return. This method only supports json.</param>
        /// <param name="pretty">If true, the returned JSON will be prettified. Avoid using for production code.</param>
        public async Task<HttpResponseMessage> GetSymbology(string? format = null, string? pretty = null)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            if (format is not null) query["format"] = format;
            if (pretty is not null) query["pretty"] = pretty.ToString();
            UriBuilder builder = new(ENDPOINT + CARD_SYMBOLS)
            {
                Query = query.ToString()
            };
            return await _httpClient.GetAsync(builder.Uri);
        }

        /// <summary>
        /// Parses the given mana cost parameter and returns Scryfall’s interpretation.
        /// The server understands most community shorthand for mana costs(such as 2WW for {2}{W}{W}). Symbols can also be out of order, lowercase, or have multiple colorless costs (such as 2{g}2 for {4}{G}).
        /// If part of the string could not be understood, the server will return an Error object describing the problem.
        /// </summary>
        /// <param name="cost">The mana string to parse.</param>
        /// <param name="format">The data format to return. This method only supports json.</param>
        /// <param name="pretty">If true, the returned JSON will be prettified. Avoid using for production code.</param>
        public async Task<HttpResponseMessage> GetSymbology(string cost, string? format = null, string? pretty = null)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            query["cost"] = cost;
            if (format is not null) query["format"] = format;
            if (pretty is not null) query["pretty"] = pretty.ToString();
            UriBuilder builder = new(ENDPOINT + CARD_SYMBOLS + "/parse-mana")
            {
                Query = query.ToString()
            };
            return await _httpClient.GetAsync(builder.Uri);
        }
    }
}
