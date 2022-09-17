using System;

namespace Api.Models.Requests
{
    public class FreeAllocatedSpaceRequest
    {
        public Guid UserKey { get; set; }
        public Guid OfficeSeatDetailKey { get; set; }
        public DateTime AllocatedDateTime { get; set; }        
        public override string ToString()
        {
            return $"User Key: '{UserKey}', OfficeSeatDetailKey: '{OfficeSeatDetailKey}', AllocationDateTime: {AllocatedDateTime}";
        }
    }
}
