using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Requests
{
    public class AllocateSpaceRequest
    {
        public Guid UserKey { get; set; }
        public string OfficeSeatDetailKeys { get; set; }
        public DateTime StartAllocationDateTime { get; set; }
        public string UserName { get; set; }

        public override string ToString()
        {
            return $"Request to allocate space for {UserName} for {StartAllocationDateTime}";
        }
    }

    public class AllocateSeatRequest
    {
        public Guid UserKey { get; set; }
        public string OfficeSeatDetailKeys { get; set; }
        public DateTime StartAllocationDateTime { get; set; }
        public DateTime EndAllocationDateTime { get; set; }
        public string UserName { get; set; }

        public override string ToString()
        {
            return $"Request to allocate space for {UserName} from {StartAllocationDateTime} to {EndAllocationDateTime}";
        }
    }
}
