
using System;
using System.ComponentModel.DataAnnotations;

namespace Service.ViewModels
{
    public class LoginViewModel
    {
        
        [Required(ErrorMessage ="login_id is required")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
        ErrorMessage = "Please enter correct email address")]
        public string login_id { get; set; }
        [Required(ErrorMessage = "login_pass is required")]
        public string login_pass { get; set; }
        public int CountError { get; set; }
        public DateTime DateLoginError { get; set; }
    }
}