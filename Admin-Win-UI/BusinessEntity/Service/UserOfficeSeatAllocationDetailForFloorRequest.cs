using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessEntity.Service
{
    public class UserOfficeSeatAllocationDetailForFloorRequest
    {
        public Guid userKey { get; set; }
        public Guid OfficeFloorDetailKey { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}
