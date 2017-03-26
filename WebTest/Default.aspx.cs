using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebTest
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Application.Lock();
            Application["PageRequestCount"] =
                ((int)Application["PageRequestCount"]) + 1;

            lblCounts.Text = Application["PageRequestCount"].ToString();
            Application.UnLock();
            
        }
    }
}