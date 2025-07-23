using System;
namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing.");
            
            var cells = line.Split(',');
            
            if (cells.Length < 3)
            {
                logger.LogWarning("Warning: Line contains less than 3 elements.");
                return null; 
            }

            var lat = double.Parse(cells[0]);
            var lon = double.Parse(cells[1]);
            var name = cells[2];
            
            var location = new Point();
            location.Latitude = lat;
            location.Longitude = lon;
            
            var tacoBell = new TacoBell(name, location);

            logger.LogInfo($"{tacoBell.Name} Taco Bell added");
            return tacoBell;
        }
    }
}
