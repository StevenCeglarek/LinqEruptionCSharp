using LinqEruption;

List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
//IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
//PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!

// Helper method to print each item in a List or IEnumerable. This should remain at the bottom of your class!
static void PrintEach(IEnumerable<Eruption> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (Eruption item in items)
    {
        Console.WriteLine(item.ToString());
    }
}

Eruption? firstInChile = eruptions.FirstOrDefault(e => e.Location.Equals("Chile"));
Console.WriteLine("First in Chile: " + firstInChile);

Eruption? firstInHawaiinIs = eruptions.FirstOrDefault(e => e.Location.Equals("Hawaiin Is"));
if(firstInHawaiinIs == null)
{
    Console.WriteLine("No Hawaiin Is eruption found");
}
else
{
    Console.WriteLine(firstInHawaiinIs);
}

Eruption? firstInGreenLand = eruptions.FirstOrDefault(e => e.Location.Equals("Greenland"));
if (firstInHawaiinIs == null)
{
    Console.WriteLine("No Greenland eruption found");
}
else
{
    Console.WriteLine(firstInHawaiinIs);
}

Eruption? firstBefore1900 = eruptions.FirstOrDefault(e => e.Year > 1900 && e.Location.Equals("New Zealand"));
Console.WriteLine("First after 1900 and in New Zealand: " + firstBefore1900);

IEnumerable<Eruption> eruptionsWithElevationOver200M = eruptions.Where(e => e.ElevationInMeters > 200);
PrintEach(eruptionsWithElevationOver200M, "Eruptions with over 200M elevation");

IEnumerable<Eruption> eruptionsStartsWithL = eruptions.Where(e => e.Volcano.StartsWith("L"));
PrintEach(eruptionsStartsWithL, "Where Volcano names start with L");
Console.WriteLine("Number of Volcanoes where the Volcano Name starts with an L: " + eruptionsStartsWithL.Count());

int? biggestElevation = eruptions.Max(eruptions => eruptions.ElevationInMeters);
Console.WriteLine("The biggest elevation in all of the Volcanoes is: " + biggestElevation);

Eruption? eruptionWithHighestElevation = eruptions.FirstOrDefault(e => e.ElevationInMeters == biggestElevation);
Console.WriteLine("The name of the Volcano with the biggest elevation is: " + eruptionWithHighestElevation.Volcano);

IEnumerable<Eruption> eruptionsInAlphabeticalOrder = eruptions.OrderBy(e => e.Volcano);
PrintEach(eruptionsInAlphabeticalOrder, "In Alphabetical Order");

float? elevationsCombined = eruptions.Sum(e => e.ElevationInMeters);
Console.WriteLine("Elevations summed up: " + elevationsCombined);

bool? anyEruptionInYear2000 = eruptions.Any(e => e.Year == 2000);
Console.WriteLine("Did any eruption occur in the year 2000: " + anyEruptionInYear2000);

IEnumerable<Eruption> eruptionsWithTypeStratovolcanoJustThree = eruptions.Where(e => e.Type.Equals("Stratovolcano")).Take(3);
PrintEach(eruptionsWithTypeStratovolcanoJustThree, "Eruptions with type Stratovolcano, limit to 3");

IEnumerable<Eruption> eruptionsBefore1000AndAlphabetical = eruptions.Where(e => e.Year < 1000).OrderBy(er => er.Volcano);
PrintEach(eruptionsBefore1000AndAlphabetical, "Eruptions before the year 1000 and in alphabetical order");

List<String>? eruptionsBefore1000AndAlphabeticalNameOnly = eruptions.Where(e => e.Year < 1000).OrderBy(er => er.Volcano).Select(e => e.Volcano).ToList();
foreach (var item in eruptionsBefore1000AndAlphabeticalNameOnly)
{
    Console.WriteLine("Volcano Name: " + item);
}