using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessEntity
{
    public class FloorDetail
    {
        public int Id { get; set; }
        public String FloorName { get; set; } = String.Empty;
        public String ZoneName { get; set; } = String.Empty;
        public int SeatCount { get; set; }
    }
}
