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

            // used File.ReadAllLines(path) to grab all the lines from the csv file
            // Log and error for 0 lines and a warning for 1 line
        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();

            var locations = lines.Select(parser.Parse).ToArray();

            // Finding the two Taco Bells in Alabama that are the furthest from one another.
            
            // Creating two `ITrackable` variables with initial values of `null`. These will be used to store the two taco bells that are the furthest from each other.
            ITrackable locA = null;
            ITrackable locB = null;

            // Created a `double` variable to store the distance
            double distance = 0;
            double maxDistance = 0;

            // Includes the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;` - .DotNet Core was installed
            // A for loop for the locations to grab each location as the origin (using: `locA`)
                

            // Created a new corA Coordinate with the locA's lat and long - Coordinate is a class so it's just like instantiating a class
            for (int i = 0; i < locations.Length; i++)
            {
                GeoCoordinate cordA = new GeoCoordinate();
                cordA.Latitude = locations[i].Location.Latitude;
                cordA.Longitude = locations[i].Location.Longitude;

                for (int j =0; j < locations.Length; j++)
                {
                    GeoCoordinate cordB = new GeoCoordinate();
                    cordB.Latitude = locations[j].Location.Latitude;
                    cordB.Longitude = locations[j].Location.Longitude;

                    distance = cordA.GetDistanceTo(cordB);

                    if(maxDistance < distance)
                    {
                        locA = locations[i];
                        locB = locations[j];
                        maxDistance = distance;
                    }
                }
            }
            // Did another loop on the locations with the scope of the first loop
            // Createed a new Coordinate with locB's lat and long
            // Compared the two using `.GetDistanceTo()`, which returns a double
            // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables set above
            
            Console.WriteLine($"The 1st location is {locA.Name}, the 2nd location is {locB.Name} and the max distance between the two is {Math.Ceiling(maxDistance/1609.34)}");
        }
    }
}
            // Grabbed the path from the name of the file


            // Created a new instance of the TacoParser class
            // Grabbed an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            //meters/feet 3.28
            //meters/miles 1609.34
            