using System;

namespace Api.Models.Responses
{
    public class InsertOfficeResponse
    {
        public Guid OfficeKey { get; set; }
        public bool IsError { get; set; }
        public string Comment { get; set; }
        public override string ToString()
        {
            return $"Office created : {OfficeKey}";
        }
    }
}
