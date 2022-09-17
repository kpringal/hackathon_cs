using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Responses
{
    public class LoginResponse
    {
        public string UserName { get; set; }
        public string UserKey { get; set; }
        public List<string> Role { get; set; }
        public string Comment { get; set; }
        public bool IsError { get; set; }
    }
}
