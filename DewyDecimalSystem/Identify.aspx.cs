using DewyDecimalSystem.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DewyDecimalSystem
{
    public partial class Identify : System.Web.UI.Page
    {
        /// <summary>
        /// DECLARATION OF CLASSES
        /// DECLARATION OF GLOBAL LISTS TO BE USED FOR THE CALL NUMBERS AND DESCRIPITONS
        /// </summary>
        public IdentifyClass IdentifyClass = new IdentifyClass();
        public List<string> descriptionList = new List<string>();
        public List<string> callNumberList = new List<string>();
        public Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
        public DD_Class dD_Class = new DD_Class();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                mp1.Show();
            }

        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// LOADS NEW VALUES WHEN THE USER CLICKS ON START 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void startBtn_Click(object sender, EventArgs e)
        {
            ChangeValues();
        }
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// METHOD TO MOVE ONTO THE NEXT VALUE IF THEY CLICK ON NEXT. CHECKS THE ANSWERS 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void nextBtn_Click(object sender, EventArgs e)
        {
            var answers = new HashSet<string>();

            //this adds the values and does not add duplicate values
            answers.Add(dd1.SelectedValue);
            answers.Add(dd2.SelectedValue);
            answers.Add(dd3.SelectedValue);
            answers.Add(dd4.SelectedValue);

            //check if there were any duplicates
            if (answers.Count < 4)
            {
                errorLabel.Text = "No duplicates allowed";
            }
            else
            {
                //check whether it they are matching descriptions or numbers
                var type = IdentifyClass.DescriptionOrNumber(txt1.Text);

                //if the user is numbers
                if (type)
                {
                    //get the values 
                    keyValuePairs.Add(txt1.Text, dd1.SelectedValue);
                    keyValuePairs.Add(txt2.Text, dd2.SelectedValue);
                    keyValuePairs.Add(txt3.Text, dd3.SelectedValue);
                    keyValuePairs.Add(txt4.Text, dd4.SelectedValue);

                    //check whether they are correct
                    var found = IdentifyClass.CheckAnswer(keyValuePairs);

                    if (found)
                    {
                        //hide the error label
                        errorLabel.Visible = false;
                        //when the user clicks on next, show new information to sort
                        ChangeValues();
                    }
                    else
                    {
                        errorLabel.Visible = true;
                        errorLabel.Text = "Incorrect answer";
                    }
                }
                else
                {
                    //get the values 
                    keyValuePairs.Add(dd1.SelectedValue, txt1.Text);
                    keyValuePairs.Add(dd2.SelectedValue, txt2.Text);
                    keyValuePairs.Add(dd3.SelectedValue, txt3.Text);
                    keyValuePairs.Add(dd4.SelectedValue, txt4.Text);

                    //check whether they are correct
                    var found = IdentifyClass.CheckAnswer(keyValuePairs);

                    if (found)
                    {
                        //hide the error label
                        errorLabel.Visible = false;
                        //when the user clicks on next, show new information to sort
                        ChangeValues();
                    }
                    else
                    {
                        errorLabel.Visible = true;
                        errorLabel.Text = "Incorrect answer";
                    }
                }
                
            }
            
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// METHOD TO CHANGE THE VALUES OF THE CALL NUMBER AND DESCRIPTION
        /// </summary>
        private void ChangeValues()
        {
            //determine whether you are starting with a call number or descrition to match
            //var mode = IdentifyClass.Toss();
            var mode = true;
            //load up 3 descriptions if true
            if (mode)
            {
                descriptionList = IdentifyClass.GetRandomDescription(4);
                //get list of correct answers
                var correctList = IdentifyClass.GetCorrectCallNumbers(descriptionList);

                //for testing purposes
                var x = 1;
                System.Diagnostics.Debug.WriteLine("*****ANSWERS*****");
                foreach (var item in correctList)
                {
                    System.Diagnostics.Debug.WriteLine(x + ") " + item);
                    x++;
                }

                //generate 4 random call numbers
                callNumberList = IdentifyClass.GetNumberAnswers(correctList);

                //add descritions to label
                txt1.Text = descriptionList[0];

                txt2.Text = descriptionList[1];

                txt3.Text = descriptionList[2];

                txt4.Text = descriptionList[3];

                //add numbers to the drop down lists
                dd1.DataSource = callNumberList;
                dd1.DataBind();
                dd2.DataSource = callNumberList;
                dd2.DataBind();
                dd3.DataSource = callNumberList;
                dd3.DataBind();
                dd4.DataSource = callNumberList;
                dd4.DataBind();



                /*BulletedList1.DataSource = description;
                BulletedList1.DataBind();*/

                BulletedList2.DataSource = callNumberList;
                BulletedList2.DataBind();
            }
            //load up 3 call numbers
            else
            {
                callNumberList = IdentifyClass.GetRandomNumber(4);
                //get list of correct answers
                var correctList = IdentifyClass.GetCorrectDescriptions(callNumberList);

                //for testing purposes
                var x = 1;
                System.Diagnostics.Debug.WriteLine("*****ANSWERS*****");
                foreach (var item in correctList)
                {
                    System.Diagnostics.Debug.WriteLine(x + ") " + item);
                    x++;
                }

                //generate a list of correct and wrong answers
                descriptionList = IdentifyClass.GetDescriptionAnswers(correctList);

                //add descritions to label
                txt1.Text = callNumberList[0];
                txt2.Text = callNumberList[1];
                txt3.Text = callNumberList[2];
                txt4.Text = callNumberList[3];

                //add numbers to the drop down lists
                dd1.DataSource = descriptionList;
                dd1.DataBind();
                dd2.DataSource = descriptionList;
                dd2.DataBind();
                dd3.DataSource = descriptionList;
                dd3.DataBind();
                dd4.DataSource = descriptionList;
                dd4.DataBind();

                BulletedList2.DataSource = descriptionList;
                BulletedList2.DataBind();
            }

        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        protected void startGameBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("GameInstructions.aspx");
        }
    }
    /*--------------------------------------------------------------------------------------00oo END OF FILE oo00-------------------------------------------------------------------------------------------------*/
   
}