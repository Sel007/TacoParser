namespace LoggingKata
{
    public struct Point
    {
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        public Point (double longitude, double lat)
        {
            Longitude = longitude;
            Latitude = lat;
        }
    }
}