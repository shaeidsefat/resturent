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
    public partial class AOrderList : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        private void GridView1_SelectedIndexChanged()
        {
            
        }

        string Name;
        string OrderID;
        string Location;
       
      
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow Gr = GridView1.SelectedRow;
            Location = Gr.Cells[3].Text;
            Name = Gr.Cells[2].Text;
            OrderID = Gr.Cells[1].Text;
            Label2.Text = OrderID;
            Label1.Text = Name;
            Label3.Text = Location;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string status = DropDownList1.Text;
            using (SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-6HF1GFD\SQLEXPRESS;Initial Catalog=RMS;Integrated Security=True"))
            {
                sqlcon.Open();
                string SQL = "UPDATE [dbo].[Orderlist] SET [OrderStatus]='"+status+"' WHERE [OrderID]='"+Label2.Text+"'";

                SqlCommand sqlcmd = new SqlCommand(SQL, sqlcon);
                sqlcmd.ExecuteNonQuery();

                Response.Redirect("AOrderList.aspx");
            }
        }

       
    }
}