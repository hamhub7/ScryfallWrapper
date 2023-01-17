using ScryfallWrapper.Objects;
using ScryfallWrapper.Requests;

Scryfall scryfall = new();
HttpResponseMessage response = await scryfall.GetCatalogCardNames();
Console.WriteLine(await response.Content.ReadAsStringAsync());