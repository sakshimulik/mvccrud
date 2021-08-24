using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication6.Models;
using WebApplication6.service;


namespace WebApplication6.DAL
{
    public class UserDal
    {
        string strcon = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString;

        public int Insertemployee(Users users)
        {
            SqlConnection conn = null;
            conn = new SqlConnection(strcon);
            conn.Open();
            string sql = "insert into employee(fname,lname,email,city,address) values('" + users.fname + "', '" + users.lname + "', '" + users.email + "', '" + users.city + "', '" + users.address + "')";
            SqlCommand cmd = new SqlCommand(sql, conn);
            int status = cmd.ExecuteNonQuery();
            if (status > 0)
            {
                return status;
            }
            else
            {
                return status;
            }
        }
        public List<Users> getAllserviceUsers()
        {
            string sqlquery = "select id,fname,lname,email,city,address from employee where active='Y'";
            List<Users> userlist = new List<Users>();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                using (SqlCommand cmd1 = new SqlCommand(sqlquery, con))
                {
                    cmd1.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd1))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                Users users = new Users();
                                users.id = Convert.ToInt32(dr[0]);
                                users.fname = dr[1].ToString();
                                users.lname = dr[2].ToString();
                                users.email = dr[3].ToString();
                                users.city = dr[4].ToString();
                                users.address = dr[5].ToString();
                                userlist.Add(users);
                            }
                        }

                    }
                }
                con.Close();
            }
            return userlist;
        }

        public List<Users> getuserbyId(string edit)
        {
            string sql = "select id, fname,lname,email,city,address from employee where id ='"+ edit + "'";
            List<Users> updatelist = new List<Users>();
            using (SqlConnection con = new SqlConnection(strcon))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            foreach (DataRow dr in dt.Rows)
                            {
                                Users users = new Users();
                                users.id = Convert.ToInt32(dr[0]);
                                users.fname = dr[1].ToString();
                                users.lname = dr[2].ToString();
                                users.email = dr[3].ToString();
                                users.city = dr[4].ToString();
                                users.address = dr[5].ToString();
                                updatelist.Add(users);
                            }
                        }

                    }
                    con.Close();
                }
                return updatelist;
            }
        }
        public int updateemployee(Users users)
        {
            SqlConnection conn = null;
            conn = new SqlConnection(strcon);
            conn.Open();
            string sql = "update employee set fname='" + users.fname + "',lname='" + users.lname + "',email='" + users.email + "',city='" + users.city + "',address='" + users.address + "' where id='"+users.id+"'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            int status = cmd.ExecuteNonQuery();
            if (status > 0)
            {
                return status;
            }
            else
            {
                return status;
            }
        }

        public int deleteEmployee(string id)
        {
            SqlConnection conn = null;
            conn = new SqlConnection(strcon);
            conn.Open();
            string sql = "update employee set active = 'N' where id='" + id + "'";
            SqlCommand cmd = new SqlCommand(sql, conn);
            int status = cmd.ExecuteNonQuery();
            if (status > 0)
            {
                return status;
            }
            else
            {
                return status;
            }
        }
    }
}

        