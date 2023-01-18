using ScryfallWrapper.Errors;
using ScryfallWrapper.Objects;
using ScryfallWrapper.Requests;

Scryfall scryfall = new();
try
{
    ScryList<Set> sets = await scryfall.GetSets();
    foreach (Set set in sets.Data)
    {
        Console.WriteLine(set.Name);
    }
}
catch(ScryfallException se)
{
    Console.WriteLine(se.Message);
}