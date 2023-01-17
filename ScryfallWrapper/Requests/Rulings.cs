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
        private const string RULINGS = "/rulings";

        /// <summary>
        /// Returns a List of rulings for a card with the given Multiverse ID. If the card has multiple multiverse IDs, this method can find either of them.
        /// </summary>
        /// <param name="id">The multiverse ID.</param>
        /// <param name="format">The data format to return. This method only supports json.</param>
        /// <param name="pretty">If true, the returned JSON will be prettified. Avoid using for production code.</param>
        public async Task<HttpResponseMessage> GetRulingsMultiverseId(int id, string? format = null, string? pretty = null)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            if (format is not null) query["format"] = format;
            if (pretty is not null) query["pretty"] = pretty.ToString();
            UriBuilder builder = new(ENDPOINT + CARDS + "/multiverse" + $"/{id}" + RULINGS)
            {
                Query = query.ToString()
            };
            return await _httpClient.GetAsync(builder.Uri);
        }

        /// <summary>
        /// Returns rulings for a card with the given MTGO ID (also known as the Catalog ID). The ID can either be the card’s mtgo_id or its mtgo_foil_id.
        /// </summary>
        /// <param name="id">The MTGO ID.</param>
        /// <param name="format">The data format to return. This method only supports json.</param>
        /// <param name="pretty">If true, the returned JSON will be prettified. Avoid using for production code.</param>
        public async Task<HttpResponseMessage> GetRulingsMtgoId(int id, string? format = null, string? pretty = null)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            if (format is not null) query["format"] = format;
            if (pretty is not null) query["pretty"] = pretty.ToString();
            UriBuilder builder = new(ENDPOINT + CARDS + "/mtgo" + $"/{id}" + RULINGS)
            {
                Query = query.ToString()
            };
            return await _httpClient.GetAsync(builder.Uri);
        }

        /// <summary>
        /// Returns rulings for a card with the given Magic: The Gathering Arena ID.
        /// </summary>
        /// <param name="id">The Arena ID.</param>
        /// <param name="format">The data format to return. This method only supports json.</param>
        /// <param name="pretty">If true, the returned JSON will be prettified. Avoid using for production code.</param>
        public async Task<HttpResponseMessage> GetRulingsArenaId(int id, string? format = null, string? pretty = null)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            if (format is not null) query["format"] = format;
            if (pretty is not null) query["pretty"] = pretty.ToString();
            UriBuilder builder = new(ENDPOINT + CARDS + "/arena" + $"/{id}" + RULINGS)
            {
                Query = query.ToString()
            };
            return await _httpClient.GetAsync(builder.Uri);
        }

        /// <summary>
        /// Returns a List of rulings for the card with the given set code and collector number.
        /// </summary>
        /// <param name="code">The three to five-letter set code.</param>
        /// <param name="number">The collector number.</param>
        /// <param name="format">The data format to return. This method only supports json.</param>
        /// <param name="pretty">If true, the returned JSON will be prettified. Avoid using for production code.</param>
        public async Task<HttpResponseMessage> GetRulingsCodeNumber(string code, string number, string? format = null, string? pretty = null)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            if (format is not null) query["format"] = format;
            if (pretty is not null) query["pretty"] = pretty.ToString();
            UriBuilder builder = new(ENDPOINT + CARDS + "/arena" + $"/{code}" + $"/{number}" + RULINGS)
            {
                Query = query.ToString()
            };
            return await _httpClient.GetAsync(builder.Uri);
        }

        /// <summary>
        /// Returns a List of rulings for a card with the given Scryfall ID.
        /// </summary>
        /// <param name="id">The Scryfall ID.</param>
        /// <param name="format">The data format to return. This method only supports json.</param>
        /// <param name="pretty">If true, the returned JSON will be prettified. Avoid using for production code.</param>
        public async Task<HttpResponseMessage> GetRulingsId(string id, string? format = null, string? pretty = null)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            if (format is not null) query["format"] = format;
            if (pretty is not null) query["pretty"] = pretty.ToString();
            UriBuilder builder = new(ENDPOINT + CARDS + $"/{id}" + RULINGS)
            {
                Query = query.ToString()
            };
            return await _httpClient.GetAsync(builder.Uri);
        }
    }
}