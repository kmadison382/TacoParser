using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // Objective: Find the two Taco Bells that are the farthest apart from one another.

            logger.LogInfo("Log initialized");
            
            string[] lines = File.ReadAllLines(csvPath);
            if (lines.Length == 0)
            {
                logger.LogError("Error: No lines found.");
            }

            if (lines.Length == 1)
            {
                logger.LogWarning("Warning: Only one line found.");
            }
            
            logger.LogInfo($"Lines: {lines[0]}");
            
            var parser = new TacoParser();
            
            var locations = lines.Select(parser.Parse).ToArray();
            
            ITrackable tacoA = null;
            ITrackable tacoB = null;
            
            double distance = 0;
            
            for (int i = 0; i < locations.Length; i++)
            {
                var locA = locations[i];
                var corA = new GeoCoordinate(locA.Location.Latitude, locA.Location.Longitude);

                for (int j = 0; j < locations.Length; j++)
                {
                    var locB = locations[j];
                    var corB = new GeoCoordinate(locB.Location.Latitude, locB.Location.Longitude);
                    var distanceB = corA.GetDistanceTo(corB);
                    if (distanceB > distance)
                    {
                        distance = distanceB;
                        tacoA = locA;
                        tacoB = locB;
                    }
                }
            }
            
            Console.WriteLine($"{tacoA.Name} and {tacoB.Name} are the two Taco Bells farthest apart.");
            
        }
    }
}
