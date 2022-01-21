using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DewyDecimalSystem.Classes
{
    public class FindClass
    {
        /// <summary>
        /// DECLARATION DD_CLASS
        /// DECLARATION OF RND VARIABLE FOR RANDOMISATION
        /// </summary>
        public DD_Class dD_Class = new DD_Class();

        private Random _rnd = new Random();

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// RANDOMLY GENERATES A NUMBER BETWEEN 0 AND SPECIFIED MAX VALUE
        /// </summary>
        public int RandomInt(int val)
        {
            return _rnd.Next(0, val);
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// METHOD TO GET THE THIRD LEVEL CALL NUMBER
        /// </summary>
        /// <param name="thirdlevelClassifications"></param>
        /// <returns></returns>
        public KeyValuePair<string, string> GetRandomThirdLevel()
        {

            SortedDictionary<string, string> thirdlevelClassifications = dD_Class.SetThirdLevelClassifications();

            var count = thirdlevelClassifications.Count;

            //select a random index from the third level classifications
            var pos = RandomInt(count);

            //get the key value pair at the specified index
            var kvp = thirdlevelClassifications.ElementAt(pos);

            return kvp;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// GET THE CORRECT SECOND LEVEL OF THE CALL NUMBERS
        /// </summary>
        /// <param name="secondlevelClassifications"></param>
        /// <param name="thirdLevelKvp"></param>
        /// <returns></returns>
        public KeyValuePair<string, string> GetCorrectSecondLevel(string val)
        {
            SortedDictionary<string, string> secondlevelClassifications = dD_Class.SetSecondLevelClassifications();
            //get the key of the third level selected. Get the first two values
            var key = val.Substring(0, 2);
            KeyValuePair<string, string> kvp = new KeyValuePair<string, string>();


            //loop through the second classification to find the matching value key pair
            foreach (var item in secondlevelClassifications)
            {
                //check if the current key is within the class of the third class selected
                if (item.Key.Substring(0, 2).Equals(key))
                {
                    kvp = item;
                    // found = true;
                }
            }

            return kvp;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// GET RANDOM LIST OF SECOND LEVEL ANSWERS INCLUDING CORRECT ANSWER 
        /// </summary>
        /// <param name="count"></param>
        /// <param name="kvp"></param>
        /// <returns></returns>
        public SortedDictionary<string, string> GetRandomSecondLevel(int count, KeyValuePair<string, string> kvp)
        {
            SortedDictionary<string, string> secondLevelClassifications = dD_Class.SetSecondLevelClassifications();
            var randomList = new SortedDictionary<string, string>();

            //add the correct kvp to the dictionary
            randomList.Add(kvp.Key, kvp.Value);
            //generate a random index number
            var rnd = RandomInt(secondLevelClassifications.Count);

            //loop while the list is not yet count of 4
            while (randomList.Count != count)
            {
                //get a random kvp at an index
                var val = secondLevelClassifications.ElementAt(rnd);

                //try catch to prevent duplicate entry
                try
                {
                    randomList.Add(val.Key, val.Value);
                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine("GetRandomSecondLevel() ERROR: DUPLICATE VALUE");
                }
                //regenerate a random index number
                rnd = RandomInt(secondLevelClassifications.Count);
                //i++;
            }

            return randomList;
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// GET THE CORRECT FIRST LEVEL OF THE CALL NUMBERS
        /// </summary>
        /// <param name="firstLevelClassifications"></param>
        /// <param name="thirdLevelKvp"></param>
        /// <returns></returns>
        public KeyValuePair<string, string> GetCorrectFirstLevel(string val)
        {
            SortedDictionary<string, string> firstLevelClassifications = dD_Class.SetFirstLevelClassifications();
            //get the key of the third level selected. Get the first value
            var key = val.Substring(0, 1);
            KeyValuePair<string, string> kvp = new KeyValuePair<string, string>();


            //loop through the first classification to find the matching value key pair
            foreach (var item in firstLevelClassifications)
            {
                //get the kvp of the current index
                //var item = firstLevelClassifications.ElementAt(index);

                //check if the current key is within the class of the third class selected
                if (item.Key.Substring(0, 1).Equals(key))
                {
                    kvp = item;
                }
            }

            return kvp;
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

       /* public bool CheckFirstLevelAnswer(string key)
        {

        }*/
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// GET RANDOM LIST OF FIRST LEVEL ANSWERS INCLUDING CORRECT ANSWER 
        /// </summary>
        /// <param name="count"></param>
        /// <param name="kvp"></param>
        /// <returns></returns>
        public SortedDictionary<string, string> GetRandomFirstLevel(int count, KeyValuePair<string, string> kvp)
        {
            SortedDictionary<string, string> firstLevelClassifications = dD_Class.SetFirstLevelClassifications();
            var randomList = new SortedDictionary<string, string>();

            //add the correct kvp to the dictionary
            randomList.Add(kvp.Key, kvp.Value);
            //generate a random index number
            var rnd = RandomInt(firstLevelClassifications.Count);

            //loop while the list is not yet count of 4
            while (randomList.Count != count)
            {
                //get a random kvp at an index
                var val = firstLevelClassifications.ElementAt(rnd);

                //try catch to prevent duplicate entry
                try
                {
                    randomList.Add(val.Key, val.Value);
                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine("GetRandomFirstLevel() ERROR: DUPLICATE VALUE");
                }
                //regenerate a random index number
                rnd = RandomInt(firstLevelClassifications.Count);
                //i++;
            }

            return randomList;
        }
        //--------------------------------------------------------------------------------------00oo END OF FILE oo00-----------------------------------------------------------------------------------------//

    }
}