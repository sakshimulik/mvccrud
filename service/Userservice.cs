using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication6.Models;
using WebApplication6.DAL;

namespace WebApplication6.service
{
    public class Userservice
    {
        UserDal ud = new UserDal();
        public int Insertemployeeservice (Users user)
        {
            return ud.Insertemployee(user);
        }
        public List<Users> getAllserviceUsers()
        {
            return ud.getAllserviceUsers();

        }
        public List<Users> getuserbyId(string edit)
        {
            return ud.getuserbyId(edit);

        }
        public int updateemployee(Users user)
        {
            return ud.updateemployee(user);
        }

        public int deleteEmployee(string id)
        {
            return ud.deleteEmployee(id);
        }


    }
}