using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessEntity.Service.Response
{
    public class AllOfficeFloorDetailResponse
    {

        public OfficeFloorDetailResponse[] allOfficeDetails { get; set; }
        public string comment { get; set; }
        public bool hasError { get; set; }

        public class OfficeFloorDetailResponse
        {
            public Guid officeKey { get; set; }
            public Guid officeFloorDetailKey { get; set; }
            public string officeName { get; set; }
            public string floorName { get; set; }
            public string zoneName { get; set; }
            public int seatCount { get; set; }
        }

    }
}
