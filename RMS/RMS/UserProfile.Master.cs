using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
namespace RMS
{
    public partial class UserProfile : System.Web.UI.MasterPage
    {
        
        public string email;
        protected void Page_Load(object sender, EventArgs e)
        {
             email = Session["User"].ToString();
            loadGrid();
        }
        
        public void loadGrid()
        {
            string bn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlConnection conn = new SqlConnection(bn);
            SqlCommand cmd = new SqlCommand(@"SELECT  [Name]
      ,[Address]
      ,[PhoneNumber]
      ,[DeliveryDate]
      ,[Quantity]
      ,[FoodName]
      ,[Price]
      ,[OrderStatus]
     ,[OrderID]
      ,[DeliveryStatus]
  FROM [dbo].[Orderlist] where [Email]='" + email+ "'");

            SqlDataAdapter ba = new SqlDataAdapter();
            cmd.Connection = conn;
            ba.SelectCommand = cmd;
            DataTable bt = new DataTable();
            ba.Fill(bt);
            GridView1.DataSource = bt;
            GridView1.DataBind();

        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string status = DropDownList1.Text;
            using (SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-6HF1GFD\SQLEXPRESS;Initial Catalog=RMS;Integrated Security=True"))
            {
                sqlcon.Open();
                string SQL = "UPDATE [dbo].[Orderlist] SET [OrderStatus]='" + status + "' WHERE [OrderID]='" + TextBox10.Text + "'";

                SqlCommand sqlcmd = new SqlCommand(SQL, sqlcon);
                sqlcmd.ExecuteNonQuery();

                Response.Redirect("UserProfile.aspx");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            
                  string status = "Received";
            using (SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-6HF1GFD\SQLEXPRESS;Initial Catalog=RMS;Integrated Security=True"))
            {
                sqlcon.Open();
                string SQL = "UPDATE [dbo].[Orderlist] SET [DeliveryStatus]='" + status + "' WHERE [OrderID]='" + TextBox11.Text + "'";

                SqlCommand sqlcmd = new SqlCommand(SQL, sqlcon);
                sqlcmd.ExecuteNonQuery();

                Response.Redirect("UserProfile.aspx");
            }

        }
    }
}