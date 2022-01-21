using DewyDecimalSystem.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DewyDecimalSystem
{
    public partial class GameInstructions : System.Web.UI.Page
    {
        User user;

        protected void Page_Load(object sender, EventArgs e)
        {
            errorLbl.Visible = false;
        }

        protected void returnBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Identify.aspx");
        }


        protected void proceedBtn_Click(object sender, EventArgs e)
        {
            var name = txbName.Text;
            var surname = txbSurname.Text;
            if(String.IsNullOrEmpty(name) || String.IsNullOrEmpty(surname))
            {
                errorLbl.Visible = true;
                errorLbl.Text = "Enter missing values!";
            }
            else
            {
                user = new User();
                user.Name = name;
                user.Surname = surname;

                Session["user"] = user;

                Response.Redirect("IdentifyGame.aspx");
            }
            
        }

        
    }
}