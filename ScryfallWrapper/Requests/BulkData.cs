using Newtonsoft.Json.Linq;
using ScryfallWrapper.Errors;
using ScryfallWrapper.Objects;
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
        /// <exception cref="ScryfallException">Thrown when the API returns an error</exception>
        /// <exception cref="NullReferenceException">Thrown when a cast fails</exception>
        /// <exception cref="Exception">Thrown when an unexpected type is received</exception>
        public async Task<ScryList<BulkData>> GetBulkData(string? pretty = null)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            if (pretty is not null) query["pretty"] = pretty.ToString();
            UriBuilder builder = new(ENDPOINT + BULK_DATA)
            {
                Query = query.ToString()
            };

            HttpResponseMessage response = await _httpClient.GetAsync(builder.Uri);
            string json = await response.Content.ReadAsStringAsync();
            JObject jObject = JObject.Parse(json);
            string? objectValue = (string?)jObject["object"];

            if (objectValue == "list")
            {
                // TODO: double check this guy
                ScryList<BulkData>? list = jObject.ToObject<ScryList<BulkData>>();
                return list ?? throw new NullReferenceException();
            }
            else if (objectValue == "error")
            {
                throw jObject.ToObject<ScryfallException>() ?? throw new NullReferenceException();
            }
            else
            {
                throw new Exception($"Unexpected type received: {objectValue}");
            }
        }

        /// <summary>
        /// Returns a single Bulk Data object with the given id.
        /// </summary>
        /// <param name="id">The id of the Bulk Data object.</param>
        /// <param name="format">The data format to return: json or file. Defaults to json.</param>
        /// <param name="pretty">If true, the returned JSON will be prettified. Avoid using for production code.</param>
        /// <exception cref="ScryfallException">Thrown when the API returns an error</exception>
        /// <exception cref="NullReferenceException">Thrown when a cast fails</exception>
        /// <exception cref="Exception">Thrown when an unexpected type is received</exception>
        public async Task<BulkData> GetBulkDataId(string id, string? format = null, string? pretty = null)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            if (format is not null) query["format"] = format;
            if (pretty is not null) query["pretty"] = pretty.ToString();
            UriBuilder builder = new(ENDPOINT + BULK_DATA + $"/{id}")
            {
                Query = query.ToString()
            };

            HttpResponseMessage response = await _httpClient.GetAsync(builder.Uri);
            string json = await response.Content.ReadAsStringAsync();
            JObject jObject = JObject.Parse(json);
            string? objectValue = (string?)jObject["object"];

            if (objectValue == "bulk_data")
            {
                BulkData? data = jObject.ToObject<BulkData>();
                return data ?? throw new NullReferenceException();
            }
            else if (objectValue == "error")
            {
                throw jObject.ToObject<ScryfallException>() ?? throw new NullReferenceException();
            }
            else
            {
                throw new Exception($"Unexpected type received: {objectValue}");
            }
        }

        /// <summary>
        /// Returns a single Bulk Data object with the given type.
        /// </summary>
        /// <param name="type">The Bulk Data type.</param>
        /// <param name="format">The data format to return: json or file. Defaults to json.</param>
        /// <param name="pretty">If true, the returned JSON will be prettified. Avoid using for production code.</param>
        /// <exception cref="ScryfallException">Thrown when the API returns an error</exception>
        /// <exception cref="NullReferenceException">Thrown when a cast fails</exception>
        /// <exception cref="Exception">Thrown when an unexpected type is received</exception>
        public async Task<BulkData> GetBulkDataType(string type, string? format = null, string? pretty = null)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            if (format is not null) query["format"] = format;
            if (pretty is not null) query["pretty"] = pretty.ToString();
            UriBuilder builder = new(ENDPOINT + BULK_DATA + $"/{type}")
            {
                Query = query.ToString()
            };

            HttpResponseMessage response = await _httpClient.GetAsync(builder.Uri);
            string json = await response.Content.ReadAsStringAsync();
            JObject jObject = JObject.Parse(json);
            string? objectValue = (string?)jObject["object"];

            if (objectValue == "bulk_data")
            {
                BulkData? data = jObject.ToObject<BulkData>();
                return data ?? throw new NullReferenceException();
            }
            else if (objectValue == "error")
            {
                throw jObject.ToObject<ScryfallException>() ?? throw new NullReferenceException();
            }
            else
            {
                throw new Exception($"Unexpected type received: {objectValue}");
            }
        }
    }
}
