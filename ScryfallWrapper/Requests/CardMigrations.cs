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
        public async Task<HttpResponseMessage> GetMigrations(int page)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            query["page"] = page.ToString();
            UriBuilder builder = new(ENDPOINT + CARD_MIGRATIONS)
            {
                Query = query.ToString()
            };
            return await _httpClient.GetAsync(builder.Uri);
        }

        /// <summary>
        /// Returns a single Card Migration with the given :id
        /// </summary>
        /// <param name="id">The ID of the migration.</param>
        public async Task<HttpResponseMessage> GetMigrationsId(string id)
        {
            NameValueCollection query = HttpUtility.ParseQueryString("");
            UriBuilder builder = new(ENDPOINT + CARD_MIGRATIONS + $"/{id}")
            {
                Query = query.ToString()
            };
            return await _httpClient.GetAsync(builder.Uri);
        }
    }
}
