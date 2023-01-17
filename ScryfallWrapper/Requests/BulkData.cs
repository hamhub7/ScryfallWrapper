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
        private const string BULK_DATA = "/bulk-data";

        /// <summary>
        /// Returns a List of all Bulk Data items on Scryfall.
        /// </summary>
        /// <param name="pretty">If true, the returned JSON will be prettified. Avoid using for production code.</param>
        public async Task<HttpResponseMessage> GetBulkData(string? pretty = null)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            if (pretty is not null) query["pretty"] = pretty.ToString();
            UriBuilder builder = new(ENDPOINT + BULK_DATA)
            {
                Query = query.ToString()
            };
            return await _httpClient.GetAsync(builder.Uri);
        }

        /// <summary>
        /// Returns a single Bulk Data object with the given id.
        /// </summary>
        /// <param name="id">The id of the Bulk Data object.</param>
        /// <param name="format">The data format to return: json or file. Defaults to json.</param>
        /// <param name="pretty">If true, the returned JSON will be prettified. Avoid using for production code.</param>
        public async Task<HttpResponseMessage> GetBulkDataId(string id, string? format = null, string? pretty = null)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            if (format is not null) query["format"] = format;
            if (pretty is not null) query["pretty"] = pretty.ToString();
            UriBuilder builder = new(ENDPOINT + BULK_DATA + $"/{id}")
            {
                Query = query.ToString()
            };
            return await _httpClient.GetAsync(builder.Uri);
        }

        /// <summary>
        /// Returns a single Bulk Data object with the given type.
        /// </summary>
        /// <param name="type">The Bulk Data type.</param>
        /// <param name="format">The data format to return: json or file. Defaults to json.</param>
        /// <param name="pretty">If true, the returned JSON will be prettified. Avoid using for production code.</param>
        public async Task<HttpResponseMessage> GetBulkDataType(string type, string? format = null, string? pretty = null)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            if (format is not null) query["format"] = format;
            if (pretty is not null) query["pretty"] = pretty.ToString();
            UriBuilder builder = new(ENDPOINT + BULK_DATA + $"/{type}")
            {
                Query = query.ToString()
            };
            return await _httpClient.GetAsync(builder.Uri);
        }
    }
}
