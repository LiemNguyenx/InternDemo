
using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.Dao
{
    public class UserDao
    {
        dbContext db = null;
        public UserDao()
        {
            db = new dbContext();
        }
        public mst_customer getCustomerByCode(string code)
        {
            return db.mst_customer.SingleOrDefault(x=>x.code_cst == code);
        }
        public mst_user getUserByEmail(string email)
        {
            return db.mst_user.SingleOrDefault(x => x.mail == email);
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
        public Boolean login(string login_id, string login_pass)
        {
            var findUser = db.mst_user.SingleOrDefault(x => x.mail == login_id && x.pass_login == login_pass);

            return (findUser != null && findUser.code_cst == findUser.mst_customer.code_cst
                && findUser.dest_flg == false && findUser.mst_customer.dest_flg == false) ? true : false;
            
        }
    }
}