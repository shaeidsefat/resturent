using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RMS
{
    public partial class AFoodCorner : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("Authority.aspx");
        }
    }
}