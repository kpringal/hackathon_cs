using System;
using System.Collections.Generic;

namespace Api.Models.Responses
{
    public class GetSubOrdinateResponse
    {
        public Guid UserKey { get; set; }
        public List<SubOrdinate> SubOrdinates { get; set; }        
        public string Comment { get; set; }
        public bool HasError { get; set; }       
    }

    public class SubOrdinate
    {
        public string FullName { get; set; }
        public string OECode { get; set; }
        public int TeamCount { get; set; }
        public string FullNameWithOeCode { get; set; }
    }
}
