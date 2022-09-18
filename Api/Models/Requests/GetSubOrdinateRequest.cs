using System;

namespace Api.Models.Requests
{
    public class GetSubOrdinateRequest
    {
        public Guid UserKey { get; set; }
        public override string ToString()
        {
            return $"GetSubOrdinateRequest request for Manager '{UserKey}'";
        }
    }
}

