using DewyDecimalSystem.Classes;
using DewyDecimalSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DewyDecimalSystem
{
    public partial class FindGame : System.Web.UI.Page
    {
        public FindClass findClass = new FindClass();
        int correctAnswers;
        User user = new User();
        string gameType = "FIND";
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        protected void Page_Load(object sender, EventArgs e)
        {
            //check if page is refreshed
            if (!IsPostBack)
            {
                //show instructions
                mp1.Show();
                correctAnswers = 0;


                //make error images invisible
                Image1.Visible = false;
                Image2.Visible = false;
                Image3.Visible = false;

                errorLbl.Visible = false;
            }
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------//

        protected void startBtn_Click(object sender, EventArgs e)
        {
            RestartQuestions();
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------//

        protected void viewBtn_Click(object sender, EventArgs e)
        {
            mp3.Show();
            //Response.Redirect("Leaderboard.aspx");
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// METHOD TO ADD VALUES AND SEARCH FRO THE USER IN THE DATABASE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected async void proceedBtn_Click(object sender, EventArgs e)
        {
            //create user object to add to leaderboard
            var name = txbName.Text;
            var surname = txbSurname.Text;
            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(surname))
            {
                errorLbl.Visible = true;
                errorLbl.Text = "Enter missing values!";
            }
            else
            {
                user = new User()
                {
                    Name = name,
                    Surname = surname,
                    Score = Int32.Parse(lblcorrect.Text)
                };

                Task<bool> find = new Task<bool>(() => CheckUser(user));
                find.Start();

                bool found = await find;

                if (found)
                {
                    //start a new task to update values to the database
                    Task update = new Task(() => Update(user));
                    update.Start();
                    await update;
                }
                else
                {
                    //start a new task to add values to the database
                    Task add = new Task(() => AddToDatabase(user));
                    add.Start();
                    //wait for the task to finish in order to move onto the next page
                    await add;
                }

                //pass the names of the user and their score
                Session["user"] = user;
                Session["type"] = gameType;

                Response.Redirect("Leaderboard.aspx");
            }
            
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        #region DATABASE
        /// <summary>
        /// METHOD TO DETERMINE WHETHER THE USER ALREADY EXISTS IN THE TABLE
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool CheckUser(User user)
        {
            var found = User_DB.FindUser(user, gameType);
            return found;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// METHOD TO ADD A NEW USER INTO THE TABLE
        /// </summary>
        /// <param name="u"></param>
        public void AddToDatabase(User u)
        {
            //add to database
            User_DB.AddUser(u, gameType);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// METHOD TO UPDATE THE USER SCORE IN THE DATABASE
        /// </summary>
        /// <param name="user"></param>
        public void Update(User user)
        {
            User_DB.UpdateUser(user,gameType);
        }
        #endregion
        //--------------------------------------------------------------------------------------------------------------------------------------------//

        protected void stopGameBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Find.aspx");
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------//

        protected void nextBtn_Click(object sender, EventArgs e)
        {
            //get value of the key currently being used
            var key = keyVal.Value;

            correctAnswers = Int32.Parse(lblcorrect.Text);
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
                    //reload the second set of values using the third key
                    ChangeSecondLevel(key);
                    
                    correctAnswers++;
                }
                else
                {
                    //make an error appear
                    if (!Image1.Visible)
                    {
                        Image1.Visible = true;
                        RestartQuestions();
                    }
                    else if (!Image2.Visible)
                    {
                        Image2.Visible = true;
                        RestartQuestions();

                    }
                    else if (!Image3.Visible)
                    {
                        Image3.Visible = true;
                        //make them view the leaderboard
                        mp2.Show();
                    }
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
                    correctAnswers++;
                }
                else
                {
                    //make an error appear
                    if (!Image1.Visible)
                    {
                        Image1.Visible = true;
                        RestartQuestions();
                    }
                    else if (!Image2.Visible)
                    {
                        Image2.Visible = true;
                        RestartQuestions();
                    }
                    else if (!Image3.Visible)
                    {
                        Image3.Visible = true;
                        //make them view the leaderboard
                        mp2.Show();
                    }
                }

            }

            lblcorrect.Text = correctAnswers.ToString();
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
            catch (Exception ex)
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
        /// METHOD TO RESTART THE SELECTION
        /// </summary>
        private async void RestartQuestions()
        {
            //set the current start to the first level
            Session["CurrentSelection"] = "first";

            //begin task for getting the third level kvp
            Task<KeyValuePair<string, string>> thirdKvpTask = new Task<KeyValuePair<string, string>>(() => ChangeThirdLevel());
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
        /// METHOD TO CHANGE THE THIRD LEVEL DESCRIPTION
        /// </summary>
        private KeyValuePair<string, string> ChangeThirdLevel()
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
            foreach (var item in _firstRnd)
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

        /*----------------------------------------------------------------------------00oo END OF FILE oo00-------------------------------------------------------*/
    }
}