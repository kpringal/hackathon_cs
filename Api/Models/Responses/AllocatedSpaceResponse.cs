using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Responses
{
    public class AllocatedSpaceResponse
    { 
        public List<AllocatedSpace> AllocatedSpaces { get; set; }
        public string Comment { get; set; }
        public bool HasError { get; set; }
    }


    public class AllocatedSpace
    {
        public DateTime AllocationDateTime { get; set; }
        public string OfficeName{ get; set; }
        public string  FloorName{ get; set; }
        public string ZoneName { get; set; }
        public string SeatNumber { get; set; }
        public Guid OfficeKey { get; set; }
        public Guid OfficeFloorDetailKey { get; set; }
        public Guid OfficeSeatDetailKey { get; set; }
        public Guid UserOfficeSeatAllocationDetailKey { get; set; }
        public string SpaceAllocatedTo { get; set; }
    }
}
