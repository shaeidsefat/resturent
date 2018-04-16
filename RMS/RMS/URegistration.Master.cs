using System;
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
    public partial class Registration : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-6HF1GFD\SQLEXPRESS;Initial Catalog=RMS;Integrated Security=True"))
            {
                sqlcon.Open();
                string SQL = "INSERT INTO [dbo].[UserReg]([FullName] ,[Email] ,[Password],[Address],[PhoneNumber],[Gender])VALUES('" + TextBox1.Text + "', '" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + PhoneNumber.Text+ "','" + Gender.Text + "')";

                SqlCommand sqlcmd = new SqlCommand(SQL, sqlcon);
                sqlcmd.ExecuteNonQuery();
                Label1.Text = "Insert Successfully";
            }
        }
    }
}