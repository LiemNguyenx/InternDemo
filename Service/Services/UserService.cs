
using DataAccess.Entity;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.Dao
{
    public class UserService
    {
        dbContext db = null;
        public UserService()
        {
            db = new dbContext();
        }
        public void ResetCountAndDateError(string mail)
        {
            var User = db.mst_user.SingleOrDefault(x => x.mail == mail);
            User.cnt_login_error = 0;
            User.date_login_error = null;
            db.SaveChanges();
        }
        public mst_customer getCustomerByCode(string code)
        {
            return db.mst_customer.SingleOrDefault(x => x.code_cst == code);
        }
        public void addCountError(string mail)
        {
            var user = db.mst_user.SingleOrDefault(x => x.mail == mail);
            user.cnt_login_error += 1;
            db.SaveChanges();
        }
        public void updateDateLoginError(string mail, DateTime date)
        {
            var user = db.mst_user.SingleOrDefault(x => x.mail == mail);
            user.date_login_error = date;
            db.SaveChanges();
        }
        public bool CheckLock(string mail)
        {
            var user = db.mst_user.SingleOrDefault(x => x.mail == mail);
            bool checktime = false;
            var nowsub30 = DateTime.Now.AddMinutes(-getSystemConfigByID(3));

            if (user.date_login_error == null || (user.date_login_error != null && nowsub30 > user.date_login_error))
            {
                checktime = true;
            }
            return (user.dest_flg == false && user.mst_customer.dest_flg == false &&
                (user.cnt_login_error < getSystemConfigByID(2) || checktime) && 
                (user.code_cst == user.mst_customer.code_cst)) ? true : false;
        }
        public int getSystemConfigByID(int id)
        {
            return db.mst_system.SingleOrDefault(x => x.system_id == id).config_value;
        }
        public void updateLoginKeyToUser(string mail, string loginkey)
        {
            mst_user user = (from mst_user in db.mst_user where mst_user.mail == mail select mst_user).Single();
            user.loginkey = loginkey;
            db.SaveChanges();
        }
        public int login(string login_id, string login_pass)
        {
            // 1 : Login thanh cong
            // 2 : LoginID sai
            // 3 : Login_Password sai
            var findUser = db.mst_user.SingleOrDefault(x => x.mail == login_id);
            if (findUser == null)
            {
                return 2;
            }else if(findUser.pass_login != login_pass)
            {
                return 3;
            }
            else if (findUser.code_cst == findUser.mst_customer.code_cst && findUser.dest_flg == false 
                && findUser.mst_customer.dest_flg == false)
            {
                return 1;
            }else
            {
                return -1;
            }
        }
    }
}