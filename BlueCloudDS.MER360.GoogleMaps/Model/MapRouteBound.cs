namespace BlueCloudDS.MER360.GoogleMaps.Model.Maps
{
    public class MapRouteBound
    {
        public Point North { get; set; }
        public Point NorthEast { get; set; }
        public Point NorthWest { get; set; }
        public Point South { get; set; }
        public Point SouthEast { get; set; }
        public Point SouthWest { get; set; }
        public Point East { get; set; }
        public Point West { get; set; }

        public Point GetValue()
        {
            return North ?? NorthEast ?? NorthWest ?? South ?? SouthEast ?? SouthWest ?? East ?? West;
        }
    }
}