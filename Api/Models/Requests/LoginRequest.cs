using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Requests
{
    public class LoginRequest
    {
        public string EMail { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return $"Email: {EMail}, Password: {Password}";
        }
    }
}
