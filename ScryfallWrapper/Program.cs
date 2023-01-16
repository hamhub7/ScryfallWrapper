using ScryfallWrapper.Objects;
using ScryfallWrapper.Requests;

Scryfall scryfall = new();
HttpResponseMessage response = await scryfall.GetCardsCodeNumber("dmu", "64", format: "text");
Console.WriteLine(await response.Content.ReadAsStringAsync());