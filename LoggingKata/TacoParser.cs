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
            logger.LogInfo("Begin parsing");

            
            //Using line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            //If array.Length is less than 3 indexes, something went wrong and return null
            if (cells.Length < 3)
            {
                return null;
            }

            double lat = double.Parse(cells[0]);   //Grabbing the latitude from array at index 0

            double longitude = double.Parse(cells[1]);   //Grabbing the longitude from array at index 1 and parse the string as a `double`

            string name = cells[2];   //Grabbing the name from your array at index 2

            //Created a TacoBell class that conforms to ITrackable
            //Created an instance of the TacoBell class
            TacoBell taco = new TacoBell();
            taco.Name = name;
            taco.Location = new Point()
            {
                Latitude = lat,
                Longitude = longitude
            };

            //Returning the instance of the TacoBell class since it conforms to ITrackable
            return taco;
        }   

    }
}