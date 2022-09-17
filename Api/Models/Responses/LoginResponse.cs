using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Api.Models.Responses
{
    public class LoginResponse 
    {
        public string UserName { get; set; }
        public Guid UserKey { get; set; }
        public List<string> Role { get; set; }
        public string Comment { get; set; }
        public bool IsError { get; set; }

       

       

        public override string ToString()
        {
            return $"User found {UserName} {UserKey} with {string.Join(',', Role)} roles";
        }
    }
}
    