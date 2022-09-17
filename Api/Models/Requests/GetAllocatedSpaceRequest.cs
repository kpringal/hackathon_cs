using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Requests
{
    public class GetAllocatedSpaceRequest
    {
        public Guid UserId { get; set; }
        public DateTime StartAllocationDateTime { get; set; }
        public DateTime EndAllocationDateTime { get; set; }

        public override string ToString()
        {
            return $"{UserId} {StartAllocationDateTime} {EndAllocationDateTime}";
        }
    }
}
