using ScryfallWrapper.Objects;
using System.Collections.Specialized;
using System.Net.Http.Json;
using System.Web;

namespace ScryfallWrapper.Requests
{
    public partial class Scryfall
    {
        private const string SETS = "/sets";

        /// <summary>
        /// Returns a List object of all Sets on Scryfall.
        /// <param name="format">The data format to return. This method only supports json.</param>
        /// <param name="pretty">If true, the returned JSON will be prettified. Avoid using for production code.</param>
        /// </summary>
        public async Task<HttpResponseMessage> GetSets(string? format = null, bool? pretty = null)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            if (format is not null) query["format"] = format;
            if (pretty is not null) query["pretty"] = pretty.ToString();
            UriBuilder builder = new(ENDPOINT + SETS)
            {
                Query = query.ToString()
            };
            return await _httpClient.GetAsync(builder.Uri);
        }

        /// <summary>
        /// Returns a Set with the given set code. The code can be either the code or the mtgo_code for the set.
        /// </summary>
        /// <param name="code">The three to five-letter set code.</param>
        /// <param name="format">The data format to return. This method only supports json.</param>
        /// <param name="pretty">If true, the returned JSON will be prettified. Avoid using for production code.</param>
        public async Task<HttpResponseMessage> GetSetsCode(string code, string? format = null, bool? pretty = null)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            if (format is not null) query["format"] = format;
            if (pretty is not null) query["pretty"] = pretty.ToString();
            UriBuilder builder = new(ENDPOINT + SETS + $"/{code}")
            {
                Query = query.ToString()
            };
            return await _httpClient.GetAsync(builder.Uri);
        }

        /// <summary>
        /// Returns a Set with the given tcgplayer_id, also known as the groupId on TCGplayer’s API.
        /// </summary>
        /// <param name="code">	The tcgplayer_id or groupId.</param>
        /// <param name="format">The data format to return. This method only supports json.</param>
        /// <param name="pretty">If true, the returned JSON will be prettified. Avoid using for production code.</param>
        public async Task<HttpResponseMessage> GetSetsTcgplayerId(string id, string? format = null, bool? pretty = null)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            if (format is not null) query["format"] = format;
            if (pretty is not null) query["pretty"] = pretty.ToString();
            UriBuilder builder = new(ENDPOINT + SETS + $"/tcgplayer/{id}")
            {
                Query = query.ToString()
            };
            return await _httpClient.GetAsync(builder.Uri);
        }

        /// <summary>
        /// Returns a Set with the given Scryfall id.
        /// </summary>
        /// <param name="code">The Scryfall ID.</param>
        /// <param name="format">The data format to return. This method only supports json.</param>
        /// <param name="pretty">If true, the returned JSON will be prettified. Avoid using for production code.</param>
        public async Task<HttpResponseMessage> GetSetsId(string id, string? format = null, bool? pretty = null)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            if (format is not null) query["format"] = format;
            if (pretty is not null) query["pretty"] = pretty.ToString();
            UriBuilder builder = new(ENDPOINT + SETS + $"/{id}")
            {
                Query = query.ToString()
            };
            return await _httpClient.GetAsync(builder.Uri);
        }
    }
}
