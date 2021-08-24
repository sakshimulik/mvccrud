using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication6.Models;
using WebApplication6.service;

namespace WebApplication6.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
          
            Userservice us = new Userservice();
            List<Users> userlist = us.getAllserviceUsers();

            return View(userlist);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Employee(Users user)
        {
            Userservice us = new Userservice();
            int status = us.Insertemployeeservice(user);
            if (status > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {

            }
            return null;
        }

        public ActionResult editpage(string edit)
        {

            Userservice us = new Userservice();
            List<Users> updatelist = us.getuserbyId(edit);

            return View(updatelist);
        }

        public ActionResult Updateemp(Users user)
        {
            Userservice us = new Userservice();
            int status = us.updateemployee(user);
            if (status > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {

            }
            return null;
        }

        public ActionResult delete_employee(string id)
        {

            Userservice us = new Userservice();
            int status = us.deleteEmployee(id);
            if (status > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {

            }
            return null;
        }
    }
    }
