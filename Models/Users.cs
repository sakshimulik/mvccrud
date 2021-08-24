using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    public class Users
    {
        public int id { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string email { get; set; }
        public string city { get; set; }
        public string address { get; set; }
        public string active { get; set; }
    }
}