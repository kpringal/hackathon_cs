using System;

namespace Api.Models.Responses
{
    public class FreeAllocatedSpaceResponse
    {
        public Guid UserKey { get; set; }
        public string Comment { get; set; }
        public bool IsError { get; set; }
        public override string ToString()
        {
            return $"User Key: '{UserKey}' has freed up sapce.";
        }
    }
}
