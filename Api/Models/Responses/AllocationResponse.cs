using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Responses
{
    public class AllocationResponse
    {
        public string Comment { get; set; }

        public bool HasError { get; set; }
    }

}
