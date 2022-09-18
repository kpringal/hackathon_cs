using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Responses
{
    public class AutoSeatAllocateResponse
    {
        public Guid UserKey { get; set; }
        public List<DownstreamUerInfo> DownstreamUerInfos { get; set; }
        public string Comment { get; set; }
        public bool HasError { get; set; }
    }

    public class DownstreamUerInfo
    {
        public Guid UserKey { get; set; }
        public string FullName { get; set; }
        public int TeamSize { get; set; }
        public bool HasError { get; set; }
        public string Comment { get; set; }
        public int AllocatedSeats { get; set; }
        public List<string> SeatsList { get; set; }
    }
}
