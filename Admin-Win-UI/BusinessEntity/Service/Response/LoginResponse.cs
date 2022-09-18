using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessEntity.Service.Response
{
    public class LoginResponse
    {
        public string userName { get; set; }
        public string userKey { get; set; }
        public string[] role { get; set; }
        public object comment { get; set; }
        public bool hasError { get; set; }

    }
}
