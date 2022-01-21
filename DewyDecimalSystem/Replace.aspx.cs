using DewyDecimalSystem.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DewyDecimalSystem.Pages
{
    public partial class Replace : System.Web.UI.Page
    {
        //INITIALIZE SOUND TO BE USED TO CONGRATULATE THE USER WHEN THEY GET THE ORDER CORRECT
        SoundPlayer soundPlayer = new SoundPlayer(@"C:\Users\koket\source\repos\DewyDecimalSystem\DewyDecimalSystem\Sound\applause.wav");

        protected void Page_Load(object sender, EventArgs e)
        {
            //make the modal visible when the page first loads
            if (!IsPostBack)
            {
                 mp1.Show();
            }
            
            //make the label invincible when the page first loads
            incorrectLbl.Visible=false;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// METHOD TO GET THE DATA SUBMITTED BY THE USER. CHECK FOR SUPLICATES AND THE VALIDITY OF ANSWERS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void submitBtn_Click(object sender, EventArgs e)
        {
            var answersInput = new List<string>();
            var callNumber = new List<string>();
            RandomClass randomClass = new RandomClass();

            //GATHER THE INPUT TO COMPARE WITH ORDERED LIST
            answersInput.Add(dd1.SelectedValue);
            answersInput.Add(dd2.SelectedValue);
            answersInput.Add(dd3.SelectedValue);
            answersInput.Add(dd4.SelectedValue);
            answersInput.Add(dd5.SelectedValue);
            answersInput.Add(dd6.SelectedValue);
            answersInput.Add(dd7.SelectedValue);
            answersInput.Add(dd8.SelectedValue);
            answersInput.Add(dd9.SelectedValue);
            answersInput.Add(dd10.SelectedValue);

            var duplicates = CheckDuplicates(answersInput);

            if (duplicates)
            {
                // show that the user did not input all values
                incorrectLbl.Text = "Duplicate entries are not allowed.";
                incorrectLbl.Visible = true;
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    callNumber.Add(BulletedList1.Items[i].Text);
                }
                //check the input against the sorted values
                onSubmit(answersInput, callNumber);

            }

            //var correct = randomClass.CheckOrder(answersInput, callNumber);


        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// METHOD TO CHECK IF THE ENTRY HAS ANY DUPLICATES
        /// </summary>
        /// <param name="answersInput"></param>
        /// <returns></returns>
        private bool CheckDuplicates(List<string> answersInput)
        {
            var eventHandling = new EventHandling();
            //call the method to get whetehr duplicates exist or not
            var duplicates = eventHandling.FindDuplicates(answersInput);
            return duplicates;

        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// METHOD TO CHECK THE ANSWERS WHEN THE USER CLICKS ON SUBMIT
        /// </summary>
        /// <param name="answersInput"></param>
        /// <param name="callNumber"></param>
        public void onSubmit(List<string> answersInput, List<string> callNumber)
        {
            var eventHandling = new EventHandling();
            var valid = eventHandling.EntryValidation(answersInput, callNumber);
            var rnd = new RandomClass();
            int correctCount = rnd.CorrectAnswerCount(answersInput, callNumber);

            //check whether the answer is valid or not
            if (valid)
            {  
                //play clapping sound
                soundPlayer.Play();
                //show the congradulations message
                mpSuccess.Show();
                
            }
            else
            {
                incorrectLbl.Text = "You got " + correctCount + "/10 :(";
                //show that the user got the order wrong
                incorrectLbl.Visible = true;



            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// when the user clicks to start generate a list of 10 random call numbers and display them
        /// </summary>
        protected void startBtn_Click(object sender, EventArgs e)
        {
            var callNumber = new List<string>();
            var orderedCallNumbers = new List<string>();
            var randomGenerator = new RandomClass();

           //CALL METHOD TO GENERATE 10 RANDOM CALL NUMBERS
            callNumber = randomGenerator.CallNumberListGenerator();

            //DISPLAY THE RANDOM CALL NUMBERS IN A BULLETED LIST
            BulletedList1.DataSource = callNumber;
            BulletedList1.DataBind();

            //add list to the drop down lists
            dd1.DataSource = callNumber;
            dd1.DataBind();
            dd2.DataSource = callNumber;
            dd2.DataBind();
            dd3.DataSource = callNumber;
            dd3.DataBind();
            dd4.DataSource = callNumber;
            dd4.DataBind();
            dd5.DataSource = callNumber;
            dd5.DataBind();
            dd6.DataSource = callNumber;
            dd6.DataBind();
            dd7.DataSource = callNumber;
            dd7.DataBind();
            dd8.DataSource = callNumber;
            dd8.DataBind();
            dd9.DataSource = callNumber;
            dd9.DataBind();
            dd10.DataSource = callNumber;
            dd10.DataBind();

            //OUTPUT THE CORRECT ORDER IN THE OUTPUT CONSOLE FOR TESTING
            orderedCallNumbers = randomGenerator.CallingNumberSortingAlgorithm(callNumber);
            var x = 1;
            foreach(var item in orderedCallNumbers)
            {
                System.Diagnostics.Debug.WriteLine(x + ") " + item);
                x++ ;
            }
            //Hide the modal pop up when the user starts the game
            mp1.Hide();
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------//

        protected void winBtn_Click(object sender, EventArgs e)
        {
            //DISPLAY THE COLLECT PRIZE MODAL
            mpCollectPrize.Show();
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------//

        protected void claimBtn_Click(object sender, EventArgs e)
        {
            //STOP PLAYING SOUND WHEN THE USER CLAIMS THEIR PRIZE
            soundPlayer.Stop();
            Response.Redirect("Default.aspx");

        }


        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        #region METHOD TO REMOVE SELECTED VALUES FROM THE LIST
        protected void dd1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dd2.Items.Remove(dd1.SelectedItem.Value);
            dd3.Items.Remove(dd1.SelectedItem.Value);
            dd4.Items.Remove(dd1.SelectedItem.Value);
            dd5.Items.Remove(dd1.SelectedItem.Value);
            dd6.Items.Remove(dd1.SelectedItem.Value);
            dd7.Items.Remove(dd1.SelectedItem.Value);
            dd8.Items.Remove(dd1.SelectedItem.Value);
            dd9.Items.Remove(dd1.SelectedItem.Value);
            dd10.Items.Remove(dd1.SelectedItem.Value);
        }

        protected void dd2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dd1.Items.Remove(dd2.SelectedItem.Value);
            dd3.Items.Remove(dd2.SelectedItem.Value);
            dd4.Items.Remove(dd2.SelectedItem.Value);
            dd5.Items.Remove(dd2.SelectedItem.Value);
            dd6.Items.Remove(dd2.SelectedItem.Value);
            dd7.Items.Remove(dd2.SelectedItem.Value);
            dd8.Items.Remove(dd2.SelectedItem.Value);
            dd9.Items.Remove(dd2.SelectedItem.Value);
            dd10.Items.Remove(dd2.SelectedItem.Value);
        }

        protected void dd3_SelectedIndexChanged(object sender, EventArgs e)
        {
            dd1.Items.Remove(dd3.SelectedItem.Value);
            dd2.Items.Remove(dd3.SelectedItem.Value);
            dd4.Items.Remove(dd3.SelectedItem.Value);
            dd5.Items.Remove(dd3.SelectedItem.Value);
            dd6.Items.Remove(dd3.SelectedItem.Value);
            dd7.Items.Remove(dd3.SelectedItem.Value);
            dd8.Items.Remove(dd3.SelectedItem.Value);
            dd9.Items.Remove(dd3.SelectedItem.Value);
            dd10.Items.Remove(dd3.SelectedItem.Value);
        }

        protected void dd4_SelectedIndexChanged(object sender, EventArgs e)
        {
            dd1.Items.Remove(dd4.SelectedItem.Value);
            dd3.Items.Remove(dd4.SelectedItem.Value);
            dd2.Items.Remove(dd4.SelectedItem.Value);
            dd5.Items.Remove(dd4.SelectedItem.Value);
            dd6.Items.Remove(dd4.SelectedItem.Value);
            dd7.Items.Remove(dd4.SelectedItem.Value);
            dd8.Items.Remove(dd4.SelectedItem.Value);
            dd9.Items.Remove(dd4.SelectedItem.Value);
            dd10.Items.Remove(dd4.SelectedItem.Value);
        }

        protected void dd5_SelectedIndexChanged(object sender, EventArgs e)
        {
            dd1.Items.Remove(dd2.SelectedItem.Value);
            dd3.Items.Remove(dd2.SelectedItem.Value);
            dd4.Items.Remove(dd2.SelectedItem.Value);
            dd2.Items.Remove(dd2.SelectedItem.Value);
            dd6.Items.Remove(dd2.SelectedItem.Value);
            dd7.Items.Remove(dd2.SelectedItem.Value);
            dd8.Items.Remove(dd2.SelectedItem.Value);
            dd9.Items.Remove(dd2.SelectedItem.Value);
            dd10.Items.Remove(dd2.SelectedItem.Value);
        }

        protected void dd6_SelectedIndexChanged(object sender, EventArgs e)
        {
            dd1.Items.Remove(dd6.SelectedItem.Value);
            dd3.Items.Remove(dd6.SelectedItem.Value);
            dd4.Items.Remove(dd6.SelectedItem.Value);
            dd5.Items.Remove(dd6.SelectedItem.Value);
            dd2.Items.Remove(dd6.SelectedItem.Value);
            dd7.Items.Remove(dd6.SelectedItem.Value);
            dd8.Items.Remove(dd6.SelectedItem.Value);
            dd9.Items.Remove(dd6.SelectedItem.Value);
            dd10.Items.Remove(dd6.SelectedItem.Value);
        }

        protected void dd7_SelectedIndexChanged(object sender, EventArgs e)
        {
            dd1.Items.Remove(dd7.SelectedItem.Value);
            dd3.Items.Remove(dd7.SelectedItem.Value);
            dd4.Items.Remove(dd7.SelectedItem.Value);
            dd5.Items.Remove(dd7.SelectedItem.Value);
            dd6.Items.Remove(dd7.SelectedItem.Value);
            dd2.Items.Remove(dd7.SelectedItem.Value);
            dd8.Items.Remove(dd7.SelectedItem.Value);
            dd9.Items.Remove(dd7.SelectedItem.Value);
            dd10.Items.Remove(dd7.SelectedItem.Value);
        }

        protected void dd8_SelectedIndexChanged(object sender, EventArgs e)
        {
            dd1.Items.Remove(dd8.SelectedItem.Value);
            dd3.Items.Remove(dd8.SelectedItem.Value);
            dd4.Items.Remove(dd8.SelectedItem.Value);
            dd5.Items.Remove(dd8.SelectedItem.Value);
            dd6.Items.Remove(dd8.SelectedItem.Value);
            dd7.Items.Remove(dd8.SelectedItem.Value);
            dd2.Items.Remove(dd8.SelectedItem.Value);
            dd9.Items.Remove(dd8.SelectedItem.Value);
            dd10.Items.Remove(dd8.SelectedItem.Value);
        }

        protected void dd9_SelectedIndexChanged(object sender, EventArgs e)
        {
            dd1.Items.Remove(dd9.SelectedItem.Value);
            dd3.Items.Remove(dd9.SelectedItem.Value);
            dd4.Items.Remove(dd9.SelectedItem.Value);
            dd5.Items.Remove(dd9.SelectedItem.Value);
            dd6.Items.Remove(dd9.SelectedItem.Value);
            dd7.Items.Remove(dd9.SelectedItem.Value);
            dd8.Items.Remove(dd9.SelectedItem.Value);
            dd2.Items.Remove(dd9.SelectedItem.Value);
            dd10.Items.Remove(dd9.SelectedItem.Value);
        }

        protected void dd10_SelectedIndexChanged(object sender, EventArgs e)
        {
            dd1.Items.Remove(dd10.SelectedItem.Value);
            dd3.Items.Remove(dd10.SelectedItem.Value);
            dd4.Items.Remove(dd10.SelectedItem.Value);
            dd5.Items.Remove(dd10.SelectedItem.Value);
            dd6.Items.Remove(dd10.SelectedItem.Value);
            dd7.Items.Remove(dd10.SelectedItem.Value);
            dd8.Items.Remove(dd10.SelectedItem.Value);
            dd9.Items.Remove(dd10.SelectedItem.Value);
            dd2.Items.Remove(dd10.SelectedItem.Value);
        }
        #endregion

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// REFRESH PAGE FOR THE USER TO SELECT AGAIN
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void refreshBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);
        }
    }
    /*--------------------------------------------------------------------------------------00oo END OF FILE oo00-------------------------------------------------------------------------------------------------*/

}