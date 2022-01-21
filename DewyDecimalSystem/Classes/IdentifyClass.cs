using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace DewyDecimalSystem.Classes
{
    public class IdentifyClass
    {
        /// <summary>
        /// DECLARATION OF RANDOM VARIABLE FOR RANDOMISATION
        /// DECLARATION OF DD_CLASS AND RANDOMCLASS TO MAKE USE OF METHODS
        /// </summary>
        private Random _rnd = new Random();

        public RandomClass randomClass = new RandomClass();
        public DD_Class dD_Class = new DD_Class();

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// GET 4 RANDOM DESCRIPTION
        /// </summary>
        /// <returns></returns>

        private int RandomInt()
        {
            return _rnd.Next(1, 10);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// GENERATE 4 RANDOM DESCRIPTIONS
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>

        public List<string> GetRandomDescription(int count)
        {
            var indexList = new List<int>();
            var randomDescription = new List<string>();

            //throw an exeption when there is an error fetching values
            try
            {
                var rnd = RandomInt();
                var descriptionList = dD_Class.GetDescription();

                for (int i = 0; i < count; i++)
                {
                    //verify if the value has already been used or not
                    if (!indexList.Contains(rnd))
                    {
                        indexList.Add(rnd);
                        randomDescription.Add(descriptionList[rnd]);
                    }
                    else
                    {
                        i--;
                    }

                    rnd = RandomInt();
                }
            }
            catch(Exception ex)
            {
                //show error message in debug console
                System.Diagnostics.Debug.WriteLine("GetRandomDescription() ERROR: " +ex.Message);
            }
            //generate a random index number
            

            return randomDescription;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// METHOD TO GET A LIST OF ALL THE WRONG AND CORRECT DECRIPTIONS
        /// </summary>
        /// <param name="correctList"></param>
        /// <returns></returns>
        public List<string> GetDescriptionAnswers(List<string> correctList)
        {
            var d = new List<string>();
            //generate a random index
            var rnd = _rnd.Next(0, 9);

            //throw exception when the program fails to get descriptions
            try
            {
                //get a list of all the descriptions
                var descriptions = dD_Class.GetDescription();

                for (int i = 0; i < 3; i++)
                {
                    //check if the current value is not already in the list of correct values and the list of wrong values
                    if (!correctList.Contains(descriptions[rnd]) && !d.Contains(descriptions[rnd]))
                        d.Add(descriptions[rnd]);
                    else
                        i--;

                    //generate another random index
                    rnd = _rnd.Next(0, 9);
                }

                d.AddRange(correctList);
                //shuffle the list of answers
                d = ShuffleList(d);
            }
            catch (Exception ex)
            {
                //show error message in debug console
                System.Diagnostics.Debug.WriteLine("GetDescriptionAnswers() ERROR: " + ex.Message);

            }
            

            return d;
            

        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// GENERATE 4 RANDOM CALL NUMBERS
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>

        public List<string> GetRandomNumber(int count)
        {
            var callNumberList = new List<string>();
            var blacklist = new List<string>();
            //generate a random number and produce a call number from the generated value
            var rndCal = randomClass.RandomInt();

            //throw exception when the program fails to get top level numbers
            try
            {
                var callValString = randomClass.TopLevelNumber(rndCal);

                for (int i = 0; i < count; i++)
                {
                    //check if the call number has already been generated
                    if (!callNumberList.Contains(callValString))
                    {
                        //check if the call number is already part of the range added to the list
                        if (!blacklist.Contains(callValString.Substring(0, 1)))
                        {
                            callNumberList.Add(callValString);
                            //blacklist call numbers within the same range as a numbre added to the list
                            blacklist.Add(callValString.Substring(0, 1));
                        }
                        else
                        {
                            //decrement counter when there is a duplicate found
                            i--;
                        }
                    }
                    else
                    {
                        i--;
                    }

                    rndCal = randomClass.RandomInt();
                    callValString = randomClass.TopLevelNumber(rndCal);
                }

            }
            catch (Exception ex)
            {
                //show error message in debug console
                System.Diagnostics.Debug.WriteLine("GetRandomNumber() ERROR: " + ex.Message);
            }
            
            return callNumberList;
        }


        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// METHOD TO GET A LIST OF ALL THE RIGHT AND WRONG CALL NUMBERS
        /// </summary>
        /// <param name="correctList"></param>
        /// <returns></returns>

        public List<string> GetNumberAnswers(List<string> correctList)
        {
            var blackList = new List<string>();
            var newList = new List<string>();

            //create a blacklist with the range of values already added from each call number category
            foreach (var item in correctList)
            {
                blackList.Add(item.Substring(0, 1));
            }

            //generate a random number and produce a call number from the generated value
            var rndCal = randomClass.RandomInt();

            //throw an exeption when there is an error in getting the top level numbers
            try
            {
                var callValString = randomClass.TopLevelNumber(rndCal);

                for (int i = 0; i < 3; i++)
                {
                    //check if the randomly generated call number's category is not already included
                    if (!blackList.Contains(callValString.Substring(0, 1)) && !newList.Contains(callValString.Substring(0, 1)))
                    {
                        newList.Add(callValString);
                        blackList.Add(callValString.Substring(0, 1));
                    }
                    else
                    {
                        i--;
                    }
                    rndCal = randomClass.RandomInt();
                    callValString = randomClass.TopLevelNumber(rndCal);
                }
                //merge the two lists
                newList.AddRange(correctList);
                //shuffle the list
                newList = ShuffleList(newList);

            }
            catch (Exception ex)
            {
                //show error message in debug console
                System.Diagnostics.Debug.WriteLine("GetNumberAnswers() ERROR: " + ex.Message);
            }
            
            return newList;

        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// THIS METHOD RANDOMLY DETERMINES WHETHER THE USER WILL START WITH MATCHING CALL NUMBERS OR DESCRIPTION
        /// </summary>
        /// <returns></returns>

        public bool Toss()
        {
            var state = true;
            // 0 = Call Number, 1 = Description
            if (_rnd.Next(2) == 0)
            {
                state = false;
            }

            return state;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// METHOD USED TO GET THE CORRECT LIST OF DESCRIPTIONS
        /// </summary>
        /// <param name="callNumbers"></param>
        /// <returns></returns>

        public List<string> GetCorrectDescriptions(List<string> callNumbers)
        {
            var descriptionList = new List<string>();

            //throw exeption when there is an error getting the kvp
            try
            {
                var dictionary = dD_Class.GetKeyValuePairs();
                string value;
                //loop through call number list
                foreach (var item in callNumbers)
                {
                    //search for the value matching the current call number
                    if (dictionary.TryGetValue(item, out value))
                    {
                        descriptionList.Add(value);
                    }
                }

            }
            catch (Exception ex)
            {
                //show error message in debug console
                System.Diagnostics.Debug.WriteLine("GetCorrectDescriptions() ERROR: " + ex.Message);
            }
            
            return descriptionList;

        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// METHOD USED TO RANDIMLY GENERATE THE CORRECT CALL NUMBER
        /// </summary>
        /// <param name="descriptions"></param>
        /// <returns></returns>
        
        public List<string> GetCorrectCallNumbers(List<string> descriptions)
        {
            var numberList = new List<string>();

            //throw exeption when there is an error getting the kvp
            try {
                var dictionary = dD_Class.GetKeyValuePairs();

                //loop through call number list
                foreach (var item in descriptions)
                {
                    //get the category of call number using the description
                    int myKey = (int)Int64.Parse(dictionary.FirstOrDefault(x => x.Value == item).Key);

                    //generate a random number using the category of the call numeber
                    var rnd = _rnd.Next(myKey, myKey + 99).ToString();

                    //add to list
                    numberList.Add(rnd);
                }

            }
            catch (Exception ex)
            {
                //show error message in debug console
                System.Diagnostics.Debug.WriteLine("GetCorrectCallNumbers() ERROR: " +ex.Message);

            }
            
            return numberList;

        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// RANDOMISE THE LIST OF ANSWERS
        /// </summary>
        /// <param name="answers"></param>
        /// <returns></returns>

        public List<string> ShuffleList(List<string> answers)
        {
            var shuffled = answers.OrderBy(x => Guid.NewGuid()).ToList();
            return shuffled;
        }


        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// METHOD TO CHECK THE ANSWERS
        /// </summary>
        /// <param name="callNumber"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        public bool CheckAnswer2(List<string> callNumber, List<string> description)
        {
            var found = false;
            
            //get the stored key value pairs 
            var numbCallList = dD_Class.GetKeyValuePairs();
            string result;
            for(int i = 0; i < 4; i++)
            {
                //use TryGetValue() to get a value of key
                if (numbCallList.TryGetValue(callNumber[i], out result))
                {
                    if (result.Equals(description[i]))
                        found = true;
                }
            }

            return found;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// METHOD TO CHECK IF THE KEY VALUE PAIRS/ANSWERS ARE CORRECT
        /// </summary>
        /// <param name="answers"></param>
        /// <returns></returns>
        public bool CheckAnswer(Dictionary<string,string> answers)
        {
            var occurance = 0;
            var found = false;
            //throw exeption when there is an error getting the kvp
            try
            {
                //get the stored key value pairs 
                var numbCallList = dD_Class.GetKeyValuePairs();
                //var i = 0;
                foreach (var item in answers)
                {
                    if (numbCallList.Contains(item))
                        occurance++;

                }

                if (occurance == 4)
                    found = true;
            }
            catch (Exception ex)
            {
                //show error message in debug console
                System.Diagnostics.Debug.WriteLine("CheckAnswer() ERROR: " +ex.Message);
            }
            

            return found;
        }
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// DETERMINES IF THE VALUE IS STRING OR NUMBER: TRUE FOR NUMBER | FALSE FOR STRING 
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public bool DescriptionOrNumber(string val)
        {
            var type = false;

            if (Regex.IsMatch(val, @"^\d+$"))
            {
                type = true;
            }

            return type;
        }

    /*--------------------------------------------------------------------------------------00oo END OF FILE oo00-------------------------------------------------------------------------------------------------*/
   

    }
}