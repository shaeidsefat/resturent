using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RMS
{
    public partial class ULogout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("~/WebForm1.aspx");
        }
    }
}