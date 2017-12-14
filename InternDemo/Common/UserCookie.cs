using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternDemo.Common
{
    [Serializable]
    public class UserCookie
    {
        public string login_id { get; set; }
        public string login_pass { get; set; }
        public string timestamp_login { get; set; }
    }
}