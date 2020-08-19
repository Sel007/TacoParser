namespace LoggingKata
{
    public struct Point
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        //Point is a custom struct for longitude and latitude
        public Point (double longitude, double lat)
        {
            Longitude = longitude;
            Latitude = lat;
        }
    }
}