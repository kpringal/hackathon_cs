using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Requests
{
    public class GetAllocatedSpaceRequest
    {
        public Guid UserKey { get; set; }
        public DateTime StartAllocationDateTime { get; set; }
        public DateTime EndAllocationDateTime { get; set; }

        public override string ToString()
        {
            return $"{UserKey} {StartAllocationDateTime} {EndAllocationDateTime}";
        }
    }

    public class GetAllocatedSeatForFloorRequest
    {
        public Guid UserKey { get; set; }
        public Guid OfficeFloorDetailKey { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public override string ToString()
        {
            return $"Get allocated seats for user {UserKey} floor {OfficeFloorDetailKey} from {StartDate} to {EndDate}";
        }
    }
}
