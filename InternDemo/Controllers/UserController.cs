using InternDemo.Common;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Dao;
using Service.ViewModels;
namespace InternDemo.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var errors = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors }).ToArray();
                string encryptedPassword = Constants.SATL + EncryptMD5.MD5Hash(model.login_pass);
                var dao = new UserDao();
                var rs = dao.login(model.login_id, encryptedPassword);
                if (rs)
                {
                    var user = dao.getUserByEmail(model.login_id);
                    string now = DateTime.Now.ToString();
                    // Tao cookie
                    string loginkeyCrypt = EncryptMD5.MD5Hash(model.login_id) + encryptedPassword +
                        EncryptMD5.MD5Hash(DateTime.Now.ToString("yyyy-MM-dd HH':'mm':'ss.mmm"));
                    HttpCookie userLoginCookie = new HttpCookie(Constants.USER_LOGIN_COOKIE);
                    userLoginCookie.Value = loginkeyCrypt;
                    userLoginCookie.Expires = DateTime.Now.AddDays(dao.getSystemConfigByID(21));
                    Response.Cookies.Add(userLoginCookie);
                    // Update loginkey
                    dao.updateLoginKeyToUser(user.mail, loginkeyCrypt);
                    // Ve myHome
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Login Failed");
                    return View("ResetPassword");

                }

            }
            else
            {
                return View("ChangePassword");
            }

        }
        public ActionResult ChangePassword()
        {
            return View();
        }
        public ActionResult ResetPassword()
        {
            return View();
        }
    }
}