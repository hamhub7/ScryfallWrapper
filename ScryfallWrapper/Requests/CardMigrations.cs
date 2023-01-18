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
        private const string CARD_MIGRATIONS = "/migrations";

        /// <summary>
        /// Returns a list of all Card Migrations on Scryfall.
        /// This method is paginated, returning 350 objects at a time.Review the documentation for paginating the List type to understand all of the possible output from this method.
        /// </summary>
        /// <param name="page">The page number to return.</param>
        /// <exception cref="ScryfallException">Thrown when the API returns an error</exception>
        /// <exception cref="NullReferenceException">Thrown when a cast fails</exception>
        /// <exception cref="Exception">Thrown when an unexpected type is received</exception>
        public async Task<ScryList<CardMigration>> GetMigrations(int page)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            query["page"] = page.ToString();
            UriBuilder builder = new(ENDPOINT + CARD_MIGRATIONS)
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
                ScryList<CardMigration>? list = jObject.ToObject<ScryList<CardMigration>>();
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
        /// Returns a single Card Migration with the given :id
        /// </summary>
        /// <param name="id">The ID of the migration.</param>
        /// <exception cref="ScryfallException">Thrown when the API returns an error</exception>
        /// <exception cref="NullReferenceException">Thrown when a cast fails</exception>
        /// <exception cref="Exception">Thrown when an unexpected type is received</exception>
        public async Task<CardMigration> GetMigrationsId(string id)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            UriBuilder builder = new(ENDPOINT + CARD_MIGRATIONS + $"/{id}")
            {
                Query = query.ToString()
            };

            HttpResponseMessage response = await _httpClient.GetAsync(builder.Uri);
            string json = await response.Content.ReadAsStringAsync();
            JObject jObject = JObject.Parse(json);
            string? objectValue = (string?)jObject["object"];

            if (objectValue == "migration")
            {
                CardMigration? migration = jObject.ToObject<CardMigration>();
                return migration ?? throw new NullReferenceException();
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
