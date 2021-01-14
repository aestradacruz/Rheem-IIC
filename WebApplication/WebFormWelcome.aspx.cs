using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Classes;

namespace WebApplication
{
    public partial class WebFormWelcome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonGo_Click(object sender, EventArgs e)
        {

            new DBHelper().AddLog();

            Response.Redirect("WebFormMain.aspx");
        }
    }
}