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
            logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();

            var locations = lines.Select(parser.Parse).ToArray();

            // TODO:  Find the two Taco Bells in Alabama that are the furthest from one another.
            // HINT: ** You'll need two nested forloops **
            
            //DONE//
            // Now, here's the new code - This is your code
            // Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the furthest from each other.
            ITrackable locA = null;
            ITrackable locB = null;

            //DONE//
            // Create a `double` variable to store the distance
            double distance = 0;
            double maxDistance = 0;

            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;` - Make sure .DotNet Core is installed
            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)
                

            // Create a new corA Coordinate with your locA's lat and long - Coordinate is a class so it's just like instantiating a class
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
            //DONE// Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)
            //DONE// Create a new Coordinate with your locB's lat and long
            //DONE// Now, compare the two using `.GetDistanceTo()`, which returns a double
            //DONE// If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above
            //DONE// Once you've looped through everything, you've found the two Taco Bells furthest away from each other.

            Console.WriteLine($"The 1st location is {locA.Name}, the 2nd location is {locB.Name} and the max distance between the two is {Math.Ceiling(maxDistance/1609.34)}");
        }
    }
}
            //DONE AT THE TOP//
            // DON'T FORGET TO LOG YOUR STEPS
            // Grab the path from the name of your file

            // use File.ReadAllLines(path) to grab all the lines from your csv file
            // Log and error if you get 0 lines and a warning if you get 1 line

            // Create a new instance of your TacoParser class
            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            //meters/feet 3.28
            //meters/miles 1609.34
            