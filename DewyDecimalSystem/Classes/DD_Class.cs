using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DD_ClassLibrary;

namespace DewyDecimalSystem.Classes
{
    public class DD_Class
    {
        /// <summary>
        /// DECLARATION OF LIST OF DESCRIPTIONS
        /// DECLARATION OF THE FIRST, SECOND AND THIRD LEVEL CLASSIFICATIONS
        /// DECLARATION OF A LIST OF DESCRIPTIONS
        /// DECLARATION OF THE CALL NUMBER DICTIONARY FOR STORING THE VALUES OF THE IDENTIFY GAME
        /// DECLARATION OF RANDOM CLASS TO USE FOR DESCRIPTIONS
        /// </summary>
        private List<string> _descripitonList = new List<string>();

        private ReadFileClass readFile = new ReadFileClass();

        public SortedDictionary<string, string> FirstLevelClassifications = new SortedDictionary<string, string>();
        public SortedDictionary<string, string> SecondlevelClassifications = new SortedDictionary<string, string>();
        public SortedDictionary<string, string> ThirdlevelClassifications = new SortedDictionary<string, string>();

        
        public List<string> Description { get; set; }

        public Dictionary<string, string> CallNumberDictionary = new Dictionary<string, string>();
        public RandomClass randomClass = new RandomClass();

        RandomClass rnd = new RandomClass();

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// POPULATE THE LIST OF DESCRIPTIONS
        /// </summary>
        /// <returns></returns>
        public List<string> GetDescription()
        {
            var list = new List<string>();

            list.Add("general works");
            list.Add("philosophy and psychology");
            list.Add("relegion");
            list.Add("social sciences");
            list.Add("language");
            list.Add("natural sciences and mathematics");
            list.Add("technology");
            list.Add("the arts");
            list.Add("literature and rhetoric");
            list.Add("history, biology and geography");

            _descripitonList = list;
            return _descripitonList;

        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// METHOD TO GET THE KEYVALUE PAIRS OF THE DEWY DECIMAL CLASS FOR THE INDENTIFY OPTION
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetKeyValuePairs()
        {
            var dictionary = new Dictionary<string, string>();

            //throw exeption if thee is an error fetching the values
            try
            {
                this._descripitonList = GetDescription();
                //var index = 0;
                var calVal = 0;
                var x = 0;

                foreach (var currentDescrition in _descripitonList)
                {
                    while (x < 100)
                    {
                        //convert the top level call number into string
                        var callValString = randomClass.TopLevelNumber(calVal);

                        //add generated call number and descrition to dictionary
                        dictionary.Add(callValString, currentDescrition);

                        x++;
                        //increment the value of the call number
                        calVal++;
                    }
                    x = 0;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetKeyValuePairs() ERROR MESSAGE: " + ex);
            }
            
            //set the dictionary to the global variable
            CallNumberDictionary = dictionary;
            return CallNumberDictionary;
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        #region SET THE VALUES OF THE CLASSES FROM THE DD_CLASSLIBRARY. INCLUDES try catch exceptionS for effecient error detection
        /// <summary>
        /// METHOD TO GET THE FIRST LEVEL CLASSIFICATION
        /// </summary>
        /// <returns></returns>
        public SortedDictionary<string, string> SetFirstLevelClassifications()
        {
            try
            {
                //add value to sorted dictionary from txt file
                FirstLevelClassifications = readFile.GetFirstLevelClassifications();

            }catch(Exception ex)
            {
                Console.WriteLine("SetFirstLevelClassifications() ERROR MESSAGE: " + ex);
            }
            
            return FirstLevelClassifications;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// METHOD TO GET THE SECOND LEVEL CLASSIFICATION
        /// </summary>
        /// <returns></returns>
        public SortedDictionary<string, string> SetSecondLevelClassifications()
        {
            try
            {
                //add value to sorted dictionary from txt file
                SecondlevelClassifications = readFile.GetSecondLevelClassifications();
            }
            catch (Exception ex)
            {
                Console.WriteLine("SetSecondLevelClassifications() ERROR MESSAGE: " + ex);
            }

            return SecondlevelClassifications;

        }
        
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// METHOD TO GET THE THIRD LEVEL CLASSIFICATION
        /// </summary>
        /// <returns></returns>
        public SortedDictionary<string, string> SetThirdLevelClassifications()
        {
            try
            {
                //add value to sorted dictionary from txt file
                ThirdlevelClassifications = readFile.GetThirdLevelClassifications();
            }
            catch (Exception ex)
            {
                Console.WriteLine("SetThirdLevelClassifications() ERROR MESSAGE: " + ex);
            }

            return ThirdlevelClassifications;
        }
        #endregion

        //--------------------------------------------------------------------------------------00oo END OF FILE oo00-----------------------------------------------------------------------------------------//

    }
}