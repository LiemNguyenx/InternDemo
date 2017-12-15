using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ViewModels
{
    class UserViewModel
    {
        public string login_id { get; set; }
        public string login_pass { get; set; }
        public int CountError { get; set; }
        public DateTime DateLoginError { get; set; }
    }
}
