using DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    class ConfigValues
    {
        public dbContext db = null;
        public ConfigValues()
        {
           db = new dbContext();
        }
        public  int GetByID(int id)
        {
            return db.mst_system.SingleOrDefault(x => x.system_id == id).config_value;
        }
    }
}
