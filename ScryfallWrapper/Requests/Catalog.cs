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
        private const string CATALOG = "/catalog";

        /// <summary>
        /// Returns a list of all nontoken English card names in Scryfall’s database. Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        /// <param name="format">The data format to return. This method only supports json.</param>
        /// <param name="pretty">If true, the returned JSON will be prettified. Avoid using for production code.</param>
        public async Task<HttpResponseMessage> GetCatalogCardNames(string? format = null, string? pretty = null)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            if (format is not null) query["format"] = format;
            if (pretty is not null) query["pretty"] = pretty.ToString();
            UriBuilder builder = new(ENDPOINT + CATALOG + "/card-names")
            {
                Query = query.ToString()
            };
            return await _httpClient.GetAsync(builder.Uri);
        }

        /// <summary>
        /// Returns a list of all canonical artist names in Scryfall’s database. This catalog won’t include duplicate, misspelled, or funny names for artists. Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        /// <param name="format">The data format to return. This method only supports json.</param>
        /// <param name="pretty">If true, the returned JSON will be prettified. Avoid using for production code.</param>
        public async Task<HttpResponseMessage> GetCatalogArtistNames(string? format = null, string? pretty = null)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            if (format is not null) query["format"] = format;
            if (pretty is not null) query["pretty"] = pretty.ToString();
            UriBuilder builder = new(ENDPOINT + CATALOG + "/artist-names")
            {
                Query = query.ToString()
            };
            return await _httpClient.GetAsync(builder.Uri);
        }

        /// <summary>
        /// Returns a Catalog of all English words, of length 2 or more, that could appear in a card name. Values are drawn from cards currently in Scryfall’s database. Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        /// <param name="format">The data format to return. This method only supports json.</param>
        /// <param name="pretty">If true, the returned JSON will be prettified. Avoid using for production code.</param>
        public async Task<HttpResponseMessage> GetCatalogWordBank(string? format = null, string? pretty = null)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            if (format is not null) query["format"] = format;
            if (pretty is not null) query["pretty"] = pretty.ToString();
            UriBuilder builder = new(ENDPOINT + CATALOG + "/word-bank")
            {
                Query = query.ToString()
            };
            return await _httpClient.GetAsync(builder.Uri);
        }

        /// <summary>
        /// Returns a Catalog of all creature types in Scryfall’s database. Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        /// <param name="format">The data format to return. This method only supports json.</param>
        /// <param name="pretty">If true, the returned JSON will be prettified. Avoid using for production code.</param>
        public async Task<HttpResponseMessage> GetCatalogCreatureTypes(string? format = null, string? pretty = null)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            if (format is not null) query["format"] = format;
            if (pretty is not null) query["pretty"] = pretty.ToString();
            UriBuilder builder = new(ENDPOINT + CATALOG + "/creature-types")
            {
                Query = query.ToString()
            };
            return await _httpClient.GetAsync(builder.Uri);
        }

        /// <summary>
        /// Returns a Catalog of all Planeswalker types in Scryfall’s database. Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        /// <param name="format">The data format to return. This method only supports json.</param>
        /// <param name="pretty">If true, the returned JSON will be prettified. Avoid using for production code.</param>
        public async Task<HttpResponseMessage> GetCatalogPlaneswalkerTypes(string? format = null, string? pretty = null)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            if (format is not null) query["format"] = format;
            if (pretty is not null) query["pretty"] = pretty.ToString();
            UriBuilder builder = new(ENDPOINT + CATALOG + "/planeswalker-types")
            {
                Query = query.ToString()
            };
            return await _httpClient.GetAsync(builder.Uri);
        }

        /// <summary>
        /// Returns a Catalog of all Land types in Scryfall’s database. Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        /// <param name="format">The data format to return. This method only supports json.</param>
        /// <param name="pretty">If true, the returned JSON will be prettified. Avoid using for production code.</param>
        public async Task<HttpResponseMessage> GetCatalogLandTypes(string? format = null, string? pretty = null)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            if (format is not null) query["format"] = format;
            if (pretty is not null) query["pretty"] = pretty.ToString();
            UriBuilder builder = new(ENDPOINT + CATALOG + "/land-types")
            {
                Query = query.ToString()
            };
            return await _httpClient.GetAsync(builder.Uri);
        }

        /// <summary>
        /// Returns a Catalog of all artifact types in Scryfall’s database. Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        /// <param name="format">The data format to return. This method only supports json.</param>
        /// <param name="pretty">If true, the returned JSON will be prettified. Avoid using for production code.</param>
        public async Task<HttpResponseMessage> GetCatalogArtifactTypes(string? format = null, string? pretty = null)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            if (format is not null) query["format"] = format;
            if (pretty is not null) query["pretty"] = pretty.ToString();
            UriBuilder builder = new(ENDPOINT + CATALOG + "/artifact-types")
            {
                Query = query.ToString()
            };
            return await _httpClient.GetAsync(builder.Uri);
        }

        /// <summary>
        /// Returns a Catalog of all enchantment types in Scryfall’s database. Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        /// <param name="format">The data format to return. This method only supports json.</param>
        /// <param name="pretty">If true, the returned JSON will be prettified. Avoid using for production code.</param>
        public async Task<HttpResponseMessage> GetCatalogEnchantmentTypes(string? format = null, string? pretty = null)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            if (format is not null) query["format"] = format;
            if (pretty is not null) query["pretty"] = pretty.ToString();
            UriBuilder builder = new(ENDPOINT + CATALOG + "/enchantment-types")
            {
                Query = query.ToString()
            };
            return await _httpClient.GetAsync(builder.Uri);
        }

        /// <summary>
        /// Returns a Catalog of all spell types in Scryfall’s database. Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        /// <param name="format">The data format to return. This method only supports json.</param>
        /// <param name="pretty">If true, the returned JSON will be prettified. Avoid using for production code.</param>
        public async Task<HttpResponseMessage> GetCatalogSpellTypes(string? format = null, string? pretty = null)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            if (format is not null) query["format"] = format;
            if (pretty is not null) query["pretty"] = pretty.ToString();
            UriBuilder builder = new(ENDPOINT + CATALOG + "/spell-types")
            {
                Query = query.ToString()
            };
            return await _httpClient.GetAsync(builder.Uri);
        }

        /// <summary>
        /// Returns a Catalog of all possible values for a creature or vehicle’s power in Scryfall’s database. Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        /// <param name="format">The data format to return. This method only supports json.</param>
        /// <param name="pretty">If true, the returned JSON will be prettified. Avoid using for production code.</param>
        public async Task<HttpResponseMessage> GetCatalogPowers(string? format = null, string? pretty = null)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            if (format is not null) query["format"] = format;
            if (pretty is not null) query["pretty"] = pretty.ToString();
            UriBuilder builder = new(ENDPOINT + CATALOG + "/powers")
            {
                Query = query.ToString()
            };
            return await _httpClient.GetAsync(builder.Uri);
        }

        /// <summary>
        /// Returns a Catalog of all possible values for a creature or vehicle’s toughness in Scryfall’s database. Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        /// <param name="format">The data format to return. This method only supports json.</param>
        /// <param name="pretty">If true, the returned JSON will be prettified. Avoid using for production code.</param>
        public async Task<HttpResponseMessage> GetCatalogToughnesses(string? format = null, string? pretty = null)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            if (format is not null) query["format"] = format;
            if (pretty is not null) query["pretty"] = pretty.ToString();
            UriBuilder builder = new(ENDPOINT + CATALOG + "/toughnesses")
            {
                Query = query.ToString()
            };
            return await _httpClient.GetAsync(builder.Uri);
        }

        /// <summary>
        /// Returns a Catalog of all possible values for a Planeswalker’s loyalty in Scryfall’s database. Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        /// <param name="format">The data format to return. This method only supports json.</param>
        /// <param name="pretty">If true, the returned JSON will be prettified. Avoid using for production code.</param>
        public async Task<HttpResponseMessage> GetCatalogLoyalties(string? format = null, string? pretty = null)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            if (format is not null) query["format"] = format;
            if (pretty is not null) query["pretty"] = pretty.ToString();
            UriBuilder builder = new(ENDPOINT + CATALOG + "/loyalties")
            {
                Query = query.ToString()
            };
            return await _httpClient.GetAsync(builder.Uri);
        }

        /// <summary>
        /// Returns a Catalog of all card watermarks in Scryfall’s database. Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        /// <param name="format">The data format to return. This method only supports json.</param>
        /// <param name="pretty">If true, the returned JSON will be prettified. Avoid using for production code.</param>
        public async Task<HttpResponseMessage> GetCatalogWatermarks(string? format = null, string? pretty = null)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            if (format is not null) query["format"] = format;
            if (pretty is not null) query["pretty"] = pretty.ToString();
            UriBuilder builder = new(ENDPOINT + CATALOG + "/watermarks")
            {
                Query = query.ToString()
            };
            return await _httpClient.GetAsync(builder.Uri);
        }

        /// <summary>
        /// Returns a Catalog of all keyword abilities in Scryfall’s database. Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        /// <param name="format">The data format to return. This method only supports json.</param>
        /// <param name="pretty">If true, the returned JSON will be prettified. Avoid using for production code.</param>
        public async Task<HttpResponseMessage> GetCatalogKeywordAbilities(string? format = null, string? pretty = null)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            if (format is not null) query["format"] = format;
            if (pretty is not null) query["pretty"] = pretty.ToString();
            UriBuilder builder = new(ENDPOINT + CATALOG + "/keyword-abilities")
            {
                Query = query.ToString()
            };
            return await _httpClient.GetAsync(builder.Uri);
        }

        /// <summary>
        /// Returns a Catalog of all keyword actions in Scryfall’s database. Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        /// <param name="format">The data format to return. This method only supports json.</param>
        /// <param name="pretty">If true, the returned JSON will be prettified. Avoid using for production code.</param>
        public async Task<HttpResponseMessage> GetCatalogKeywordActions(string? format = null, string? pretty = null)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            if (format is not null) query["format"] = format;
            if (pretty is not null) query["pretty"] = pretty.ToString();
            UriBuilder builder = new(ENDPOINT + CATALOG + "/keyword-actions")
            {
                Query = query.ToString()
            };
            return await _httpClient.GetAsync(builder.Uri);
        }

        /// <summary>
        /// Returns a Catalog of all ability words in Scryfall’s database. Values are updated as soon as a new card is entered for spoiler seasons.
        /// </summary>
        /// <param name="format">The data format to return. This method only supports json.</param>
        /// <param name="pretty">If true, the returned JSON will be prettified. Avoid using for production code.</param>
        public async Task<HttpResponseMessage> GetCatalogAbilityWords(string? format = null, string? pretty = null)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            if (format is not null) query["format"] = format;
            if (pretty is not null) query["pretty"] = pretty.ToString();
            UriBuilder builder = new(ENDPOINT + CATALOG + "/ability-words")
            {
                Query = query.ToString()
            };
            return await _httpClient.GetAsync(builder.Uri);
        }
    }
}
