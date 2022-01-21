using DewyDecimalSystem.Classes;
using DewyDecimalSystem.Model;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DewyDecimalSystem
{
    
    public partial class IdentifyGame : System.Web.UI.Page
    {
        /*firebase
        IFirebaseConfig config = new FirebaseConfig()
        {
            AuthSecret = "rj1YIyA3emotRJiMhNUaGMYTT3W4aGhCCd9aRSq4",
            BasePath = "https://dewydecimal-fb78d-default-rtdb.firebaseio.com/"
        };

        //firebase client
        IFirebaseClient client;*/


        public IdentifyClass IdentifyClass = new IdentifyClass();
        public List<string> descriptionList = new List<string>();
        public List<string> callNumberList = new List<string>();
        public Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
        public DD_Class dD_Class = new DD_Class();
        User user;
        string name, surname;
        EventHandling ev = new EventHandling();
        CountdownTimer countdownTimer = new CountdownTimer();
        SoundPlayer soundPlayer = new SoundPlayer(@"C:\Users\koket\source\repos\DewyDecimalSystem\DewyDecimalSystem\Sound\timeout.wav");
        int correctAnswers;

        string gameType = "IDENTIFY";

        protected void Page_Load(object sender, EventArgs e)
        {
            Thread changeValuesThread = new Thread(ChangeValues);
            if (!Page.IsPostBack)
            {
                user = new User();
                if (Session["user"] != null)
               {

                    //load the values up on a seperate thread
                    changeValuesThread.Start();
                    //fetch the information passed in the session
                    user = (User)Session["user"];
                    hiddenName.Value = user.Name;
                    hiddenSurname.Value = user.Surname;

                    //hide the view results button
                    //viewBtn.Visible = false;

                    //strat with no correct answers
                    correctAnswers = 0;
                    //initialise timer value
                    Session["Timer"] = DateTime.Now.AddMinutes(1).ToString();
                }
                else
                {
                    Response.Redirect("GameInstructions.aspx");
                }
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// MAKE THE TIMER EVENT COUNTDOWN
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Timer_Tick(object sender, EventArgs e)
        {
            //check if the countdown is finished
            if (DateTime.Compare(DateTime.Now, DateTime.Parse(Session["Timer"].ToString())) < 0)
            {
                //decrease the time per second
                lblTime.Text = (((Int32)DateTime.Parse(Session["Timer"].ToString()).Subtract(DateTime.Now).TotalSeconds + 2) % 60)
                    .ToString() + " Seconds";
            }
            else
            {
                lblTime.Text = "Time Expired...";

            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// VERIFY ANSWERS PROVIDED BY THE USER AND CHANGE THEM TO NEW ONES. KEEP COUNT OF HOW MANY THEY GET CORRECT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        protected void nextBtn_Click(object sender, EventArgs e)
        {
                var answers = new HashSet<string>();
                correctAnswers = Int32.Parse(lblcorrect.Text);
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
                            //start thread to change the values
                            ChangeValues();

                            //incement the amount of answers they get correct
                            correctAnswers++;

                            //hide the error label
                            errorLabel.Visible = false;
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
                            ChangeValues();
                            //when the user clicks on next, show new information to sort
                            correctAnswers++;
                            errorLabel.Visible = false;
                            //incement the amount of answers they get correct
                        }
                        else
                        {
                            errorLabel.Visible = true;
                            errorLabel.Text = "Incorrect answer";
                        }
                    }

                }

                lblcorrect.Text = correctAnswers.ToString();
            
           
            
        }
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// METHOD TO CHANGE THE VALUES OF THE CALL NUMBER AND DESCRIPTION
        /// </summary>
        public void ChangeValues()
        {
            
            //determine whether you are starting with a call number or descrition to match
            var mode = IdentifyClass.Toss();
            //var mode = true;
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

                //get a list of wrong and correct values
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

        protected async void viewBtn_Click(object sender, EventArgs e)
        {
            //create user object to add to leaderboard
            name = hiddenName.Value;
            surname = hiddenSurname.Value;

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

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        protected void stopGameBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("GameInstructions.aspx");
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
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
        /// METHOD TO UPDATE THE USER SCORE IN THE DATABASE
        /// </summary>
        /// <param name="user"></param>
        
        public void Update(User user)
        {
            User_DB.UpdateUser(user, gameType);
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
        
    } 
    
    /*--------------------------------------------------------------------------------------00oo END OF FILE oo00-------------------------------------------------------------------------------------------------*/
   
    public class CountdownTimer
    {
        //event listener for when the time has run out

        public void StartSound(object source, EventArgs args)
        {
            SoundPlayer soundPlayer = new SoundPlayer(@"C:\Users\koket\source\repos\DewyDecimalSystem\DewyDecimalSystem\Sound\applause.wav");
            soundPlayer.Play();
        }

    }
    /*--------------------------------------------------------------------------------------00oo END OF FILE oo00-------------------------------------------------------------------------------------------------*/
   
}