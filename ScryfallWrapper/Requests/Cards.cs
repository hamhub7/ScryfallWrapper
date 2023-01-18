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
        private const string CARDS = "/cards";

        /// <summary>
        /// Returns a List object containing Cards found using a fulltext search string. This string supports the same fulltext search system that the main site uses.
        /// This method is paginated, returning 175 cards at a time.Review the documentation for paginating the List type and and the Error type type to understand all of the possible output from this method.
        /// If only one card is found, this method will still return a List.
        /// </summary>
        /// <param name="q">A fulltext search query. Make sure that your parameter is properly encoded. Maximum length: 1000 Unicode characters.</param>
        /// <param name="unique">The strategy for omitting similar cards. See below.</param>
        /// <param name="order">The method to sort returned cards. See below.</param>
        /// <param name="dir">The direction to sort cards. See below.</param>
        /// <param name="includeExtras">If true, extra cards (tokens, planes, etc) will be included. Equivalent to adding include:extras to the fulltext search. Defaults to false.</param>
        /// <param name="includeMultilinguals">If true, cards in every language supported by Scryfall will be included.Defaults to false.</param>
        /// <param name="includeVariations">If true, rare care variants will be included, like the Hairy Runesword. Defaults to false.</param>
        /// <param name="page">The page number to return, default 1.</param>
        /// <param name="format">The data format to return: json or csv. Defaults to json.</param>
        /// <param name="pretty">If true, the returned JSON will be prettified. Avoid using for production code.</param>
        /// <exception cref="ScryfallException">Thrown when the API returns an error</exception>
        /// <exception cref="NullReferenceException">Thrown when a cast fails</exception>
        /// <exception cref="Exception">Thrown when an unexpected type is received</exception>
        public async Task<ScryList<Card>> GetCardsSearch(string q, string? unique = null, string? order = null, string? dir = null, bool? includeExtras = null, bool? includeMultilinguals = null, bool? includeVariations = null, int? page = null, string? format = null, bool? pretty = null)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            query["q"] = q;
            if (unique is not null) query["unique"] = unique;
            if (order is not null) query["order"] = order;
            if (dir is not null) query["dir"] = dir;
            if (includeExtras is not null) query["includeExtras"] = includeExtras.ToString();
            if (includeMultilinguals is not null) query["includeMultilinguals"] = includeMultilinguals.ToString();
            if (includeVariations is not null) query["includeVariations"] = includeVariations.ToString();
            if (page is not null) query["page"] = page.ToString();
            if (format is not null) query["format"] = format;
            if (pretty is not null) query["pretty"] = pretty.ToString();
            UriBuilder builder = new(ENDPOINT + CARDS + "/search")
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
                ScryList<Card>? list = jObject.ToObject<ScryList<Card>>();
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
        /// Returns a Card based on a name search string. This method is designed for building chat bots, forum bots, and other services that need card details quickly.
        /// If you provide the exact parameter, a card with that exact name is returned.Otherwise, a 404 Error is returned because no card matches.
        /// If you provide the fuzzy parameter and a card name matches that string, then that card is returned.If not, a fuzzy search is executed for your card name.The server allows misspellings and partial words to be provided.For example: jac bele will match Jace Beleren.
        /// When fuzzy searching, a card is returned if the server is confident that you unambiguously identified a unique name with your string. Otherwise, you will receive a 404 Error object describing the problem: either more than 1 one card matched your search, or zero cards matched.
        /// You may also provide a set code in the set parameter, in which case the name search and the returned card print will be limited to the specified set.
        /// For both exact and fuzzy, card names are case-insensitive and punctuation is optional (you can drop apostrophes and periods etc). For example: fIReBALL is the same as Fireball and smugglers copter is the same as Smuggler's Copter.
        /// </summary>
        /// <param name="exact">The exact card name to search for, case insenstive.</param>
        /// <param name="fuzzy">A fuzzy card name to search for.</param>
        /// <param name="set">A set code to limit the search to one set.</param>
        /// <param name="format">The data format to return: json, text, or image. Defaults to json. </param>
        /// <param name="face">If using the image format and this parameter has the value back, the back face of the card will be returned. Will return a 422 if this card has no back face.</param>
        /// <param name="version">The image version to return when using the image format: small, normal, large, png, art_crop, or border_crop. Defaults to large.</param>
        /// <param name="pretty">If true, the returned JSON will be prettified. Avoid using for production code.</param>
        /// <exception cref="ScryfallException">Thrown when the API returns an error</exception>
        /// <exception cref="NullReferenceException">Thrown when a cast fails</exception>
        /// <exception cref="Exception">Thrown when an unexpected type is received</exception>
        public async Task<Card> GetCardsNamed(string? exact = null, string? fuzzy = null, string? set = null, string? format = null, string? face = null, string? version = null, bool? pretty = null)
        {
            if (exact is null && fuzzy is null) throw new NullReferenceException();

            NameValueCollection query = HttpUtility.ParseQueryString("");
            if (exact is not null) query["exact"] = exact;
            if (fuzzy is not null) query["fuzzy"] = fuzzy;
            if (set is not null) query["set"] = set;
            if (format is not null) query["format"] = format;
            if (face is not null) query["face"] = face;
            if (version is not null) query["version"] = version;
            if (pretty is not null) query["pretty"] = pretty.ToString();
            UriBuilder builder = new(ENDPOINT + CARDS + "/named")
            {
                Query = query.ToString()
            };

            HttpResponseMessage response = await _httpClient.GetAsync(builder.Uri);
            string json = await response.Content.ReadAsStringAsync();
            JObject jObject = JObject.Parse(json);
            string? objectValue = (string?)jObject["object"];

            if (objectValue == "card")
            {
                Card? card = jObject.ToObject<Card>();
                return card ?? throw new NullReferenceException();
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
        /// Returns a Catalog object containing up to 20 full English card names that could be autocompletions of the given string parameter.
        /// This method is designed for creating assistive UI elements that allow users to free-type card names.
        /// The names are sorted with the nearest match first, highly favoring results that begin with your given string.
        /// Spaces, punctuation, and capitalization are ignored.
        /// If q is less than 2 characters long, or if no names match, the Catalog will contain 0 items (instead of returning any errors).
        /// </summary>
        /// <param name="q">The string to autocomplete.</param>
        /// <param name="format">The data format to return. This method only supports json.</param>
        /// <param name="pretty">If true, the returned JSON will be prettified. Avoid using for production code.</param>
        /// <param name="includeExtras">If true, extra cards (tokens, planes, vanguards, etc) will be included. Defaults to false.</param>
        /// <exception cref="ScryfallException">Thrown when the API returns an error</exception>
        /// <exception cref="NullReferenceException">Thrown when a cast fails</exception>
        /// <exception cref="Exception">Thrown when an unexpected type is received</exception>
        public async Task<Catalog> GetCardsAutocomplete(string q, string? format = null, bool? pretty = null, bool? includeExtras = null)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            query["q"] = q;
            if (format is not null) query["format"] = format;
            if (pretty is not null) query["pretty"] = pretty.ToString();
            if (includeExtras is not null) query["includeExtras"] = includeExtras.ToString();
            UriBuilder builder = new(ENDPOINT + CARDS + "/autocomplete")
            {
                Query = query.ToString()
            };

            HttpResponseMessage response = await _httpClient.GetAsync(builder.Uri);
            string json = await response.Content.ReadAsStringAsync();
            JObject jObject = JObject.Parse(json);
            string? objectValue = (string?)jObject["object"];

            if (objectValue == "catalog")
            {
                Catalog? catalog = jObject.ToObject<Catalog>();
                return catalog ?? throw new NullReferenceException();
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
        /// Returns a single random Card object.
        /// The optional parameter q supports the same fulltext search system that the main site uses.Providing q will filter the pool of cards before returning a random entry.
        /// </summary>
        /// <param name="q">An optional fulltext search query to filter the pool of random cards. Make sure that your parameter is properly encoded.</param>
        /// <param name="format">The data format to return: json, text, or image. Defaults to json.</param>
        /// <param name="face">If using the image format and this parameter has the value back, the back face of the card will be returned. Will return a 422 if this card has no back face.</param>
        /// <param name="version">The image version to return when using the image format: small, normal, large, png, art_crop, or border_crop. Defaults to large.</param>
        /// <param name="pretty">If true, the returned JSON will be prettified. Avoid using for production code.</param>
        /// <exception cref="ScryfallException">Thrown when the API returns an error</exception>
        /// <exception cref="NullReferenceException">Thrown when a cast fails</exception>
        /// <exception cref="Exception">Thrown when an unexpected type is received</exception>
        public async Task<Card> GetCardsRandom(string? q = null, string? format = null, string? face = null, string? version = null, string? pretty = null)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            if(q is not null) query["q"] = q;
            if (format is not null) query["format"] = format;
            if (face is not null) query["face"] = face;
            if (version is not null) query["version"] = version;
            if (pretty is not null) query["pretty"] = pretty.ToString();
            UriBuilder builder = new(ENDPOINT + CARDS + "/random")
            {
                Query = query.ToString()
            };

            HttpResponseMessage response = await _httpClient.GetAsync(builder.Uri);
            string json = await response.Content.ReadAsStringAsync();
            JObject jObject = JObject.Parse(json);
            string? objectValue = (string?)jObject["object"];

            if (objectValue == "card")
            {
                Card? card = jObject.ToObject<Card>();
                return card ?? throw new NullReferenceException();
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

        //TODO: collection

        /// <summary>
        /// Returns a single card with the given set code and collector number. You may optionally also append a lang part to the URL to retrieve a non-English version of the card.
        /// </summary>
        /// <param name="code">The three to five-letter set code.</param>
        /// <param name="number">The collector number.</param>
        /// <param name="lang">The 2-3 character language code.</param>
        /// <param name="format">The data format to return: json, text, or image. Defaults to json.</param>
        /// <param name="face">If using the image format and this parameter has the value back, the back face of the card will be returned. Will return a 422 if this card has no back face.</param>
        /// <param name="version">The image version to return when using the image format: small, normal, large, png, art_crop, or border_crop. Defaults to large.</param>
        /// <param name="pretty">If true, the returned JSON will be prettified. Avoid using for production code.</param>
        /// <exception cref="ScryfallException">Thrown when the API returns an error</exception>
        /// <exception cref="NullReferenceException">Thrown when a cast fails</exception>
        /// <exception cref="Exception">Thrown when an unexpected type is received</exception>
        public async Task<Card> GetCardsCodeNumber(string code, string number, string? lang = null, string? format = null, string? face = null, string? version = null, string? pretty = null)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            if (format is not null) query["format"] = format;
            if (face is not null) query["face"] = face;
            if (version is not null) query["version"] = version;
            if (pretty is not null) query["pretty"] = pretty.ToString();
            UriBuilder builder = new(ENDPOINT + CARDS + $"/{code}" + $"/{number}" + (lang is not null ? $"/{lang}" : ""))
            {
                Query = query.ToString()
            };

            HttpResponseMessage response = await _httpClient.GetAsync(builder.Uri);
            string json = await response.Content.ReadAsStringAsync();
            JObject jObject = JObject.Parse(json);
            string? objectValue = (string?)jObject["object"];

            if (objectValue == "card")
            {
                Card? card = jObject.ToObject<Card>();
                return card ?? throw new NullReferenceException();
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
        /// Returns a single card with the given Multiverse ID. If the card has multiple multiverse IDs, this method can find either of them.
        /// </summary>
        /// <param name="id">The multiverse ID.</param>
        /// <param name="format">The data format to return: json, text, or image. Defaults to json.</param>
        /// <param name="face">If using the image format and this parameter has the value back, the back face of the card will be returned. Will return a 422 if this card has no back face.</param>
        /// <param name="version">The image version to return when using the image format: small, normal, large, png, art_crop, or border_crop. Defaults to large.</param>
        /// <param name="pretty">If true, the returned JSON will be prettified. Avoid using for production code.</param>
        /// <exception cref="ScryfallException">Thrown when the API returns an error</exception>
        /// <exception cref="NullReferenceException">Thrown when a cast fails</exception>
        /// <exception cref="Exception">Thrown when an unexpected type is received</exception>
        public async Task<Card> GetCardsMultiverseId(int id, string? format = null, string? face = null, string? version = null, string? pretty = null)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            if (format is not null) query["format"] = format;
            if (face is not null) query["face"] = face;
            if (version is not null) query["version"] = version;
            if (pretty is not null) query["pretty"] = pretty.ToString();
            UriBuilder builder = new(ENDPOINT + CARDS + "/multiverse" + $"/{id}")
            {
                Query = query.ToString()
            };

            HttpResponseMessage response = await _httpClient.GetAsync(builder.Uri);
            string json = await response.Content.ReadAsStringAsync();
            JObject jObject = JObject.Parse(json);
            string? objectValue = (string?)jObject["object"];

            if (objectValue == "card")
            {
                Card? card = jObject.ToObject<Card>();
                return card ?? throw new NullReferenceException();
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
        /// Returns a single card with the given MTGO ID (also known as the Catalog ID). The ID can either be the card’s mtgo_id or its mtgo_foil_id.
        /// </summary>
        /// <param name="id">The MTGO ID.</param>
        /// <param name="format">The data format to return: json, text, or image. Defaults to json.</param>
        /// <param name="face">If using the image format and this parameter has the value back, the back face of the card will be returned. Will return a 422 if this card has no back face.</param>
        /// <param name="version">The image version to return when using the image format: small, normal, large, png, art_crop, or border_crop. Defaults to large.</param>
        /// <param name="pretty">If true, the returned JSON will be prettified. Avoid using for production code.</param>
        /// <exception cref="ScryfallException">Thrown when the API returns an error</exception>
        /// <exception cref="NullReferenceException">Thrown when a cast fails</exception>
        /// <exception cref="Exception">Thrown when an unexpected type is received</exception>
        public async Task<Card> GetCardsMtgoId(int id, string? format = null, string? face = null, string? version = null, string? pretty = null)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            if (format is not null) query["format"] = format;
            if (face is not null) query["face"] = face;
            if (version is not null) query["version"] = version;
            if (pretty is not null) query["pretty"] = pretty.ToString();
            UriBuilder builder = new(ENDPOINT + CARDS + "/mtgo" + $"/{id}")
            {
                Query = query.ToString()
            };

            HttpResponseMessage response = await _httpClient.GetAsync(builder.Uri);
            string json = await response.Content.ReadAsStringAsync();
            JObject jObject = JObject.Parse(json);
            string? objectValue = (string?)jObject["object"];

            if (objectValue == "card")
            {
                Card? card = jObject.ToObject<Card>();
                return card ?? throw new NullReferenceException();
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
        /// Returns a single card with the given Magic: The Gathering Arena ID.
        /// </summary>
        /// <param name="id">The Arena ID.</param>
        /// <param name="format">The data format to return: json, text, or image. Defaults to json.</param>
        /// <param name="face">If using the image format and this parameter has the value back, the back face of the card will be returned. Will return a 422 if this card has no back face.</param>
        /// <param name="version">The image version to return when using the image format: small, normal, large, png, art_crop, or border_crop. Defaults to large.</param>
        /// <param name="pretty">If true, the returned JSON will be prettified. Avoid using for production code.</param>
        /// <exception cref="ScryfallException">Thrown when the API returns an error</exception>
        /// <exception cref="NullReferenceException">Thrown when a cast fails</exception>
        /// <exception cref="Exception">Thrown when an unexpected type is received</exception>
        public async Task<Card> GetCardsArenaId(int id, string? format = null, string? face = null, string? version = null, string? pretty = null)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            if (format is not null) query["format"] = format;
            if (face is not null) query["face"] = face;
            if (version is not null) query["version"] = version;
            if (pretty is not null) query["pretty"] = pretty.ToString();
            UriBuilder builder = new(ENDPOINT + CARDS + "/arena" + $"/{id}")
            {
                Query = query.ToString()
            };

            HttpResponseMessage response = await _httpClient.GetAsync(builder.Uri);
            string json = await response.Content.ReadAsStringAsync();
            JObject jObject = JObject.Parse(json);
            string? objectValue = (string?)jObject["object"];

            if (objectValue == "card")
            {
                Card? card = jObject.ToObject<Card>();
                return card ?? throw new NullReferenceException();
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
        /// Returns a single card with the given tcgplayer_id or tcgplayer_etched_id, also known as the productId on TCGplayer’s API.
        /// </summary>
        /// <param name="id">The tcgplayer_id or productId.</param>
        /// <param name="format">The data format to return: json, text, or image. Defaults to json.</param>
        /// <param name="face">If using the image format and this parameter has the value back, the back face of the card will be returned. Will return a 422 if this card has no back face.</param>
        /// <param name="version">The image version to return when using the image format: small, normal, large, png, art_crop, or border_crop. Defaults to large.</param>
        /// <param name="pretty">If true, the returned JSON will be prettified. Avoid using for production code.</param>
        /// <exception cref="ScryfallException">Thrown when the API returns an error</exception>
        /// <exception cref="NullReferenceException">Thrown when a cast fails</exception>
        /// <exception cref="Exception">Thrown when an unexpected type is received</exception>
        public async Task<Card> GetCardsTcgplayerId(int id, string? format = null, string? face = null, string? version = null, string? pretty = null)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            if (format is not null) query["format"] = format;
            if (face is not null) query["face"] = face;
            if (version is not null) query["version"] = version;
            if (pretty is not null) query["pretty"] = pretty.ToString();
            UriBuilder builder = new(ENDPOINT + CARDS + "/tcgplayer" + $"/{id}")
            {
                Query = query.ToString()
            };

            HttpResponseMessage response = await _httpClient.GetAsync(builder.Uri);
            string json = await response.Content.ReadAsStringAsync();
            JObject jObject = JObject.Parse(json);
            string? objectValue = (string?)jObject["object"];

            if (objectValue == "card")
            {
                Card? card = jObject.ToObject<Card>();
                return card ?? throw new NullReferenceException();
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
        /// Returns a single card with the given cardmarket_id, also known as the idProduct" or the Product ID on Cardmarket’s APIs.
        /// </summary>
        /// <param name="id">The cardmarket_id.</param>
        /// <param name="format">The data format to return: json, text, or image. Defaults to json.</param>
        /// <param name="face">If using the image format and this parameter has the value back, the back face of the card will be returned. Will return a 422 if this card has no back face.</param>
        /// <param name="version">The image version to return when using the image format: small, normal, large, png, art_crop, or border_crop. Defaults to large.</param>
        /// <param name="pretty">If true, the returned JSON will be prettified. Avoid using for production code.</param>
        /// <exception cref="ScryfallException">Thrown when the API returns an error</exception>
        /// <exception cref="NullReferenceException">Thrown when a cast fails</exception>
        /// <exception cref="Exception">Thrown when an unexpected type is received</exception>
        public async Task<Card> GetCardsCardmarketId(int id, string? format = null, string? face = null, string? version = null, string? pretty = null)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            if (format is not null) query["format"] = format;
            if (face is not null) query["face"] = face;
            if (version is not null) query["version"] = version;
            if (pretty is not null) query["pretty"] = pretty.ToString();
            UriBuilder builder = new(ENDPOINT + CARDS + "/cardmarket" + $"/{id}")
            {
                Query = query.ToString()
            };

            HttpResponseMessage response = await _httpClient.GetAsync(builder.Uri);
            string json = await response.Content.ReadAsStringAsync();
            JObject jObject = JObject.Parse(json);
            string? objectValue = (string?)jObject["object"];

            if (objectValue == "card")
            {
                Card? card = jObject.ToObject<Card>();
                return card ?? throw new NullReferenceException();
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
        /// Returns a single card with the given Scryfall ID.
        /// </summary>
        /// <param name="id">The Scryfall ID.</param>
        /// <param name="format">The data format to return: json, text, or image. Defaults to json.</param>
        /// <param name="face">If using the image format and this parameter has the value back, the back face of the card will be returned. Will return a 422 if this card has no back face.</param>
        /// <param name="version">The image version to return when using the image format: small, normal, large, png, art_crop, or border_crop. Defaults to large.</param>
        /// <param name="pretty">If true, the returned JSON will be prettified. Avoid using for production code.</param>
        /// <exception cref="ScryfallException">Thrown when the API returns an error</exception>
        /// <exception cref="NullReferenceException">Thrown when a cast fails</exception>
        /// <exception cref="Exception">Thrown when an unexpected type is received</exception>
        public async Task<Card> GetCardsId(int id, string? format = null, string? face = null, string? version = null, string? pretty = null)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            if (format is not null) query["format"] = format;
            if (face is not null) query["face"] = face;
            if (version is not null) query["version"] = version;
            if (pretty is not null) query["pretty"] = pretty.ToString();
            UriBuilder builder = new(ENDPOINT + CARDS + $"/{id}")
            {
                Query = query.ToString()
            };

            HttpResponseMessage response = await _httpClient.GetAsync(builder.Uri);
            string json = await response.Content.ReadAsStringAsync();
            JObject jObject = JObject.Parse(json);
            string? objectValue = (string?)jObject["object"];

            if (objectValue == "card")
            {
                Card? card = jObject.ToObject<Card>();
                return card ?? throw new NullReferenceException();
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