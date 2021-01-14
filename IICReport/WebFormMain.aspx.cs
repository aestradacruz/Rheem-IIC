using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication.Classes;

namespace IICReport
{
    public partial class WebFormMain : System.Web.UI.Page
    {
        DBHelper db = new DBHelper();

        protected void Page_Load(object sender, EventArgs e)
        {
            TotalLabel.Text = db.GetLogsCount();

            LastLogLabel.Text = db.GetLastLog();
        }
    }
}