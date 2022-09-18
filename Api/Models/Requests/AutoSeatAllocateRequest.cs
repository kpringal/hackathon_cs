using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Requests
{
    public class AutoSeatAllocateRequest
    {
        public Guid UserKey { get; set; }
        public decimal Allocation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate{ get; set; }

        public override string ToString()
        {
            return $"Allocation request for User {UserKey} for {Allocation} allocation from {StartDate} to {EndDate}";
        }
    }

}
