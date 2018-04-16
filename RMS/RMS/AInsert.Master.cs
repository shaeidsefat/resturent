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
    public partial class AInsert : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            string type = DropDownList1.Text;
            if (type == "FastFood")
            {
                using (SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-6HF1GFD\SQLEXPRESS;Initial Catalog=RMS;Integrated Security=True"))
                {
                    sqlcon.Open();
                    string SQL = "INSERT INTO [dbo].[FastF]([FoodName],[FoodCode] ,[Price] ,[Company])VALUES('" + TextBox1.Text + "', '" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "')";

                    SqlCommand sqlcmd = new SqlCommand(SQL, sqlcon);
                    sqlcmd.ExecuteNonQuery();
                    Label1.Text = "Insert Successfully";
                }
            }
            else if (type== "IceCream")
            {
                using (SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-6HF1GFD\SQLEXPRESS;Initial Catalog=RMS;Integrated Security=True"))
                {
                    sqlcon.Open();
                    string SQL = "INSERT INTO [dbo].[IceCream]([FoodName],[FoodCode] ,[Price],[Company] )VALUES('" + TextBox1.Text + "', '" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "')";

                    SqlCommand sqlcmd = new SqlCommand(SQL, sqlcon);
                    sqlcmd.ExecuteNonQuery();
                    Label1.Text = "Insert Successfully";
                }
            }
            else if (type == "BirthdayCake")
            {
                using (SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-6HF1GFD\SQLEXPRESS;Initial Catalog=RMS;Integrated Security=True"))
                {
                    sqlcon.Open();
                    string SQL = "INSERT INTO [dbo].[Birthdaycake]([FoodName],[FoodCode] ,[Price],[Company]) )VALUES('" + TextBox1.Text + "', '" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "')";

                    SqlCommand sqlcmd = new SqlCommand(SQL, sqlcon);
                    sqlcmd.ExecuteNonQuery();
                    Label1.Text = "Insert Successfully";
                    
                }
            }

           
        }
    }
}