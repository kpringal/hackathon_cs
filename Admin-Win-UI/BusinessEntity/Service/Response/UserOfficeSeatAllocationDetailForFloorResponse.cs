using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessEntity.Service.Response
{
    public class UserOfficeSeatAllocationDetailForFloorResponse
    {
        public Allocatedspace[] allocatedSpaces { get; set; }
        public string comment { get; set; }
        public bool hasError { get; set; }

        public class Allocatedspace
        {
            public DateTime allocationDateTime { get; set; }
            public string officeName { get; set; }
            public string floorName { get; set; }
            public object zoneName { get; set; }
            public string seatNumber { get; set; }
            public string officeKey { get; set; }
            public string officeFloorDetailKey { get; set; }
            public string officeSeatDetailKey { get; set; }
            public string userOfficeSeatAllocationDetailKey { get; set; }
            public string spaceAllocatedTo { get; set; }
        }

    }
}
