namespace ScryfallWrapper.Requests
{
    public partial class Scryfall
    {
        private HttpClient _httpClient;

        private const string ENDPOINT = "https://api.scryfall.com";

        public Scryfall()
        {
            _httpClient = new HttpClient();
        }
    }
}
