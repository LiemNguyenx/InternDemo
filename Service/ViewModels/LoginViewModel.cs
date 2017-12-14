
using System.ComponentModel.DataAnnotations;

namespace Service.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="login_id is required")]
        public string login_id { get; set; }
        [Required(ErrorMessage = "login_pass is required")]
        public string login_pass { get; set; }
    }
}