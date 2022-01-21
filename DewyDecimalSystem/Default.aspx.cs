using DewyDecimalSystem.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DewyDecimalSystem
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       
        protected void replaceBtn_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Replace.aspx");
        }

        protected void identifyBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Identify.aspx");
        }

        protected void searchBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Find.aspx");
        }
    }
}