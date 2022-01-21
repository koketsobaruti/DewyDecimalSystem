using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DewyDecimalSystem.Classes;

namespace DewyDecimalSystem
{
    public partial class Find : System.Web.UI.Page
    {
        public FindClass findClass = new FindClass();
        public bool first = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            //check if page is refreshed
            if (!IsPostBack)
            {
                //show instructions
                mp1.Show();

            }

        }
        //--------------------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// METHOD TO LOAD FIRST VALUES ON START
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void startBtn_Click(object sender, EventArgs e)
        {
            //reload a new set of values from the first value
            RestartQuestions();

        }
        //--------------------------------------------------------------------------------------------------------------------------------------------//

        protected void nextBtn_Click(object sender, EventArgs e)
        {
            //get value of the key currently being used
            var key = keyVal.Value;

            //get the current levl being assessed
            var current = Session["CurrentSelection"].ToString();

            //check if it is the first or second level
            if (current.Equals("first"))
            {
                //get the selected answer
                var selectedOption = RadioButtonList1.SelectedValue;

                //check whether it is correct
                var correct = CheckFirstAnswer(selectedOption);

                //change values if it is correct
                if (correct)
                {
                    ChangeSecondLevel(key);
                }
                else
                {
                    //show error rmessage if they failed
                    mp2.Show();
                }

            }
            else if (current.Equals("second"))
            {
                //get the selected answer
                var selectedOption = RadioButtonList1.SelectedValue;

                //check whether it is correct
                var correct = CheckSecondAnswer(selectedOption);

                //change values if it is correct
                if (correct)
                {
                    //reload a new set of values from the first value
                    RestartQuestions();
                }
                else
                {
                    //show error rmessage if they failed
                    mp2.Show();
                }

            }
            
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// METHOD TO RESTART THE SELECTION
        /// </summary>
        private async void RestartQuestions()
        {
            //set the current start to the first level
            Session["CurrentSelection"] = "first";

            //begin task for getting the third level kvp
            Task<KeyValuePair<string, string>> thirdKvpTask = new Task<KeyValuePair<string, string>>(()=> ChangeThirdLevel());
            thirdKvpTask.Start();

            //wait for the value to be fetched
            var kvp = await thirdKvpTask;

            //fetch the key and value of the third level 
            var val = kvp.Value;
            var key = kvp.Key;
            keyVal.Value = key;

            //begin the thread to get the first level values
            Thread firstLevelThread = new Thread(() => ChangeFirstLevelValues(key));
            firstLevelThread.Start();

            //display the third level description
            classLabel.Text = val;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// METHOD TO CHANGE THE FIRST LEVEL VALUES WHEN THE PAGE IS ACTIVE
        /// </summary>
        /// <param name="key"></param>
        private void ChangeFirstLevelValues(string key)
        {
            var fkvp = new List<string>();
            //get the key value pair of the correct first level
            var kvp = findClass.GetCorrectFirstLevel(key);

            //FOR TESTING PURPOSES
            System.Diagnostics.Debug.WriteLine("CORRECT: " + kvp);
            //get the randomised list of kvp for the first level
            var _firstRnd = findClass.GetRandomFirstLevel(4, kvp);

            //loop through dictionary to create a string list for displaying purposes
            foreach(var item in _firstRnd)
            {
                //get the values and keys in string format
                var v = item.Value;
                var k = item.Key;

                //add hte string into the list
                fkvp.Add(k + " , " + v );
            }
            
            //bind and display the list of first level options
            RadioButtonList1.DataSource = fkvp;
            RadioButtonList1.DataBind();

        }
        //--------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// METHOD TO CHANGE THE THIRD LEVEL DESCRIPTION
        /// </summary>
        private KeyValuePair<string,string> ChangeThirdLevel()
        {
            var kvp = new KeyValuePair<string, string>();
            //try to fetch the third level call values
            try
            {
                //get the kvp for the third level values
                kvp = findClass.GetRandomThirdLevel();
                
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Find.aspx Page_Load() ERROR: \t" + ex.Message);
            }

            return kvp;
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// METHOD TO SET THE RADIOBUTTON LIST TO SECOND LEVEL VALUES
        /// </summary>
        /// <param name="key"></param>
        private void ChangeSecondLevel(string key)
        {
            var fkvp = new List<string>();
            //get the key value pair of the correct second level
            var kvp = findClass.GetCorrectSecondLevel(key);

            //FOR TESTING PURPOSES
            System.Diagnostics.Debug.WriteLine("CORRECT: " + kvp);

            //get the randomised list of kvp for the second level
            var _secondRnd = findClass.GetRandomSecondLevel(4, kvp);

            //loop through dictionary to create a string list for displaying purposes
            foreach (var item in _secondRnd)
            {
                //get the values and keys in string format
                var v = item.Value;
                var k = item.Key;

                //add hte string into the list
                fkvp.Add(k + " , " + v);
            }

            //bind and display the list of first level options
            RadioButtonList1.DataSource = fkvp;
            RadioButtonList1.DataBind();
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// METHOD TO CHECK IF THE FIRST ANSWER SELECTED BY THE USER WAS CORRECT OR NOT
        /// </summary>
        /// <param name="selected"></param>
        /// <returns></returns>
        private bool CheckFirstAnswer(string selected)
        {
            var correct = false;
            try
            {
                //get third level description
                var val = keyVal.Value;

                var keyStr = selected.Substring(0, 3);

                //pass the session key from the third level to get the correct key answer
                var correctAnswer = findClass.GetCorrectFirstLevel(val).Key;

                //get the key of the answer for the first level selected
                var _selectedAnswer = findClass.GetCorrectFirstLevel(keyStr).Key;

                //if the user select sthe correct option change the state of answers
                if (correctAnswer == _selectedAnswer)
                {
                    correct = true;
                    Session["CurrentSelection"] = "second";
                }
                    

            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("CheckFirstAnswer() ERROR: " + ex.Message);
            }

            return correct;

        }


        //--------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// METHOD TO CHECK IF THE SECOND ANSWER SELECTED BY THE USER WAS CORRECT OR NOT
        /// </summary>
        /// <param name="selected"></param>
        /// <returns></returns>
        private bool CheckSecondAnswer(string selected)
        {
            var correct = false;
            try
            {
                //get third level description
                var val = keyVal.Value;

                var keyStr = selected.Substring(0, 3);

                //pass the session key from the third level to get the correct key answer
                var correctAnswer = findClass.GetCorrectSecondLevel(val).Key;

                //get the key of the answer for the first level selected
                var _selectedAnswer = findClass.GetCorrectSecondLevel(keyStr).Key;

                //check if they chose the correct values and show if they did not
                if (correctAnswer == _selectedAnswer)
                {
                    correct = true;
                    Session["CurrentSelection"] = "first";
                }


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("CheckSecondAnswer() ERROR: " + ex.Message);
            }

            return correct;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// METHOD TO REFRESH QUESTIONS IF THEY GOT THEM WRONG
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void restartBtn_Click(object sender, EventArgs e)
        {
            RestartQuestions();
        }

        protected void startGameBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("FindGame.aspx");
        }


        /*----------------------------------------------------------------------------00oo END OF FILE oo00-------------------------------------------------------*/
    }
}