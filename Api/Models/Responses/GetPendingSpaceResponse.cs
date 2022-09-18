using System;
using System.Collections.Generic;

namespace Api.Models.Responses
{
    public class GetPendingSpaceResponse
    {
        public List<PendingRequest> AllPendingSpaceRequests { get; set; }
        public string Comment { get; set; }
        public bool HasError { get; set; }
    }
    public class PendingRequest
    {
        public Guid SpaceRequestKey { get; set; }
        public string FullName { get; set; }
        public DateTime AllocationDateTime { get; set; }
        public int SeatCount { get; set; }
    }
}

