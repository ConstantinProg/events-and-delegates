using EventsAndDelegates;

var temperatures = new List<Temperature>
{
            new Temperature(TemperatureScales.Celsius, 20),
            new Temperature(TemperatureScales.Fahrenheit, 68),
            new Temperature(TemperatureScales.Kelvin, 298.15f),
            new Temperature(TemperatureScales.Celsius, 30),
            new Temperature(TemperatureScales.Fahrenheit, 104),
            new Temperature(TemperatureScales.Kelvin, 313.15f)
        };

var maxTemperature = temperatures.GetMax(t => t.ToCelsius());
Console.WriteLine($"Maximum temperature: {maxTemperature}");

string currentDirectory = Directory.GetCurrentDirectory();
var fileSearcher = new FileSearcher();

fileSearcher.FileFound += (sender, e) =>
{
    Console.WriteLine($"File found: {e.FileName}");
    if (e.FileName.EndsWith(".exe"))
    {
        Console.WriteLine("Found a file with an exe extension. Stopping the search.");
        fileSearcher.StopSearch();
    }
};

Console.WriteLine($"start searching for files in the directory: {currentDirectory}");
fileSearcher.SearchFiles(currentDirectory);