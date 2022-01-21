using DewyDecimalSystem.Classes;
using DewyDecimalSystem.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DewyDecimalSystem
{
    public partial class Leaderboard : System.Web.UI.Page
    {
        User user = new User();
        string gameType = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] != null)
                {
                    user = (User)Session["user"];
                    gameType = Session["type"].ToString();
                    //display user's performance
                    Label3.Text = "Well done " + user.Name + "!";
                    scorelbl.Text = "You scored: " + user.Score;
                    BindTable(gameType);
                }

            }
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// METHOD TO DISPLAY VALUES INTO THE TABLE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
         //highlight the users row if they appear in top 10   
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                foreach (TableCell cell in e.Row.Cells)
                {
                    if(cell.Text == user.Name)
                    {
                        cell.BackColor = Color.LightSkyBlue;
                    }
                }
            }
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// METHOD TO BIND THE DATA FETCHED FROM THE TABLE TO THE GRIDVIEW
        /// </summary>
        /// <param name="type"></param>
        private void BindTable(string type)
        {
            var u = User_DB.GetList(type);
           
            GridView1.DataSource = u;
            GridView1.DataBind();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// METHOD TO RETURN TO THE IDENTIFY MAIN PAGE
        /// </summary>
        /// <returns></returns>
        protected void done_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
        /*----------------------------------------------------------------------------00oo END OF FILE oo00-------------------------------------------------------*/
   
    }
}