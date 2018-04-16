using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
namespace RMS
{
    public partial class FCake : System.Web.UI.MasterPage
    {
        public string email;
        protected void Page_Load(object sender, EventArgs e)
        {
            email = Session["User"].ToString();
        }
        string foodName;
        string Code;
        string price;
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow Gr = GridView1.SelectedRow;
            price = Gr.Cells[3].Text;
            Code = Gr.Cells[2].Text;
            foodName = Gr.Cells[1].Text;
            Label3.Text = price;
            Label1.Text = Code;
            Label2.Text = foodName;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int to = int.Parse(Label3.Text);
            int al = int.Parse(DropDownList1.Text);
            int tota = to * al;
            string total = tota.ToString();
            string Status = "Processing";
            using (SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-6HF1GFD\SQLEXPRESS;Initial Catalog=RMS;Integrated Security=True"))
            {

                sqlcon.Open();
                string SQL = "INSERT INTO [dbo].[Orderlist] ([Name ],[Address] ,[PhoneNumber] ,[Area] ,[Post] ,[State] ,[House] ,[DeliveryDate] ,[DeliveryTime] ,[Quantity] ,[FoodName] ,[FoodCode] ,[Price] ,[OrderStatus],[Email]) VALUES('" + TextBox1.Text + "', '" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + TextBox7.Text + "','" + TextBox8.Text + "','" + TextBox9.Text + "','" + DropDownList1.Text + "','" + Label2.Text + "','" + Label1.Text + "','" + total + "','" + Status + "','" + email + "')";

                SqlCommand sqlcmd = new SqlCommand(SQL, sqlcon);
                sqlcmd.ExecuteNonQuery();
                Label4.Text = "Order Successfully";
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
           
        }
    }
}