namespace Api.Models.Requests
{
    public class InsertOfficeRequest
    {
        public string OfficeName { get; set; }
        public string FloorName { get; set; }
        public string ZoneName { get; set; }
        public int SeatCount { get; set; }
        public string UserName { get; set; }
        public override string ToString()
        {
            return $"OfficeName: '{OfficeName}', FloorName: '{FloorName}', ZoneName: {ZoneName}, SeatCount: {SeatCount}";
        }
    }
}
