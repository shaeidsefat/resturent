﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace RMS
{
    public partial class Authority : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Access"] == null)
            {

            }else
            {
                Response.Redirect("~/AFoodCorner.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string email = TextBox1.Text;
            string password = TextBox2.Text;
            using (SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-6HF1GFD\SQLEXPRESS;Initial Catalog=RMS;Integrated Security=True"))
            {
                sqlcon.Open();
                string query = "select COUNT(1) from DataTable where Email='" + email + "'and Password='" + password + "'";

                SqlCommand sqlcmd = new SqlCommand(query, sqlcon);
                sqlcmd.Parameters.AddWithValue("@Email", email.Trim());
                sqlcmd.Parameters.AddWithValue("@Password", email.Trim());
                int count = Convert.ToInt32(sqlcmd.ExecuteScalar());
                
                if (count == 1)
                {
                    Session["Access"] = count;
                    Response.Redirect("~/AFoodCorner.aspx");
                }
                else
                {
                    Label1.Text = "Wrong infornation";
                }

            }
        }
    }
}