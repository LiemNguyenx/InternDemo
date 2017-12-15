using InternDemo.Common;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service.Dao;
using Service.ViewModels;
using Service.Services;
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
            var dao = new UserService();
            if (ModelState.IsValid)
            {
                var errors = ModelState.Where(x => x.Value.Errors.Count > 0).Select(x => new { x.Key, x.Value.Errors }).ToArray();
                string encryptedPassword = Constants.SATL + EncryptMD5.MD5Hash(model.login_pass);
                var rs = dao.login(model.login_id, encryptedPassword);
                
                if (rs==1)
                {
                    if (!dao.CheckLock(model.login_id))
                    {
                        ModelState.AddModelError("", Constants.LOCK_MESSAGE);
                    }
                    else
                    {
                        // Reset cnt_login_error and date_login_error
                        dao.ResetCountAndDateError(model.login_id);
                        string now = DateTime.Now.ToString();
                        // Tao cookie
                        string loginkeyCrypt = EncryptMD5.MD5Hash(model.login_id) + encryptedPassword +
                            EncryptMD5.MD5Hash(DateTime.Now.ToString("yyyy-MM-dd HH':'mm':'ss.mmm"));
                        HttpCookie userLoginCookie = new HttpCookie(Constants.USER_LOGIN_COOKIE);
                        userLoginCookie.Value = loginkeyCrypt;
                        userLoginCookie.Expires = DateTime.Now.AddDays(dao.getSystemConfigByID(3));
                        Response.Cookies.Add(userLoginCookie);
                        // Tao session
                        Session.Add(Constants.USER_LOGIN_SESSION, model.login_id);
                        // Update loginkey
                        dao.updateLoginKeyToUser(model.login_id, loginkeyCrypt);
                        // Ve myHome
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    if(rs == 2)
                    {
                        ModelState.AddModelError("", Constants.LOGIN_FAILED);
                    }else if(rs == 3)
                    {
                        dao.addCountError(model.login_id);
                        dao.updateDateLoginError(model.login_id, DateTime.Now);
                        if (dao.CheckLock(model.login_id))
                        {
                            ModelState.AddModelError("", Constants.LOGIN_FAILED);
                        }
                        else
                        {
                            ModelState.AddModelError("", Constants.LOCK_MESSAGE);
                        }
                    }
                }
            }
            return View(model);



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