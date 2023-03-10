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
        private const string CARD_SYMBOLS = "/symbology";

        /// <summary>
        /// Returns a List of all Card Symbols.
        /// </summary>
        /// <param name="format">The data format to return. This method only supports json.</param>
        /// <param name="pretty">If true, the returned JSON will be prettified. Avoid using for production code.</param>
        /// <exception cref="ScryfallException">Thrown when the API returns an error</exception>
        /// <exception cref="NullReferenceException">Thrown when a cast fails</exception>
        /// <exception cref="Exception">Thrown when an unexpected type is received</exception>
        public async Task<ScryList<CardSymbol>> GetSymbology(string? format = null, string? pretty = null)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            if (format is not null) query["format"] = format;
            if (pretty is not null) query["pretty"] = pretty.ToString();
            UriBuilder builder = new(ENDPOINT + CARD_SYMBOLS)
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
                ScryList<CardSymbol>? list = jObject.ToObject<ScryList<CardSymbol>>();
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
        /// Parses the given mana cost parameter and returns Scryfall’s interpretation.
        /// The server understands most community shorthand for mana costs(such as 2WW for {2}{W}{W}). Symbols can also be out of order, lowercase, or have multiple colorless costs (such as 2{g}2 for {4}{G}).
        /// If part of the string could not be understood, the server will return an Error object describing the problem.
        /// </summary>
        /// <param name="cost">The mana string to parse.</param>
        /// <param name="format">The data format to return. This method only supports json.</param>
        /// <param name="pretty">If true, the returned JSON will be prettified. Avoid using for production code.</param>
        /// <exception cref="ScryfallException">Thrown when the API returns an error</exception>
        /// <exception cref="NullReferenceException">Thrown when a cast fails</exception>
        /// <exception cref="Exception">Thrown when an unexpected type is received</exception>
        public async Task<ManaCost> GetSymbology(string cost, string? format = null, string? pretty = null)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            query["cost"] = cost;
            if (format is not null) query["format"] = format;
            if (pretty is not null) query["pretty"] = pretty.ToString();
            UriBuilder builder = new(ENDPOINT + CARD_SYMBOLS + "/parse-mana")
            {
                Query = query.ToString()
            };

            HttpResponseMessage response = await _httpClient.GetAsync(builder.Uri);
            string json = await response.Content.ReadAsStringAsync();
            JObject jObject = JObject.Parse(json);
            string? objectValue = (string?)jObject["object"];

            if (objectValue == "mana_cost")
            {
                ManaCost? manaCost = jObject.ToObject<ManaCost>();
                return manaCost ?? throw new NullReferenceException();
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
