using System;
using System.Collections.Generic;

namespace Api.Models.Responses
{
    public class AllOfficeDetailsResponse
    {
        public List<OfficeDetial> AllOfficeDetails { get; set; }
        public string Comment { get; set; }
        public bool HasError { get; set; }
    }
    public class OfficeDetial
    {
        public Guid OfficeKey { get; set; }
        public Guid OfficeFloorDetailKey { get; set; }
        public string OfficeName { get; set; }
        public string FloorName { get; set; }
        public string ZoneName { get; set; }
        public int SeatCount { get; set; }
    }
}
