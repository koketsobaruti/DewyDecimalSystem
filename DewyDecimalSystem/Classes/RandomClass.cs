using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace DewyDecimalSystem.Classes
{
    public class RandomClass
    {
        private Random _rnd = new Random();

        ///RANDOMLY GENERATES A NUMBER BETWEEN 0 AND 920
        public int RandomInt()
        {
            return _rnd.Next(1, 999);
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        ///  GENERATES A RANDOM 3 CHAR LONG UPPER CASE STRING
        /// </summary>
        /// <param name="lowerCase"></param>
        /// <returns></returns>
       
        public string RandomString(bool lowerCase = false)
        {
            //create a string builder suitable for 3 char's
            var builder = new StringBuilder(3);

            //determine the formatting of the char 
            char offset = lowerCase ? 'a' : 'A';

            //assign a character limit 
            const int lettersOffset = 26;

            //loop to generate a new string of random characters
            for (var i = 0; i < 3; i++)
            {
                var @char = (char)_rnd.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }

            //return the newly generated string
            return lowerCase ? builder.ToString().ToLower() : builder.ToString();

        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// METHOD USED TO GENERATE THE NUMERICAL PART OF THE ENTIRE CALL NUMBER
        /// </summary>
        /// <returns></returns>
         
        public string NumberGenerator()
        {
            //retrieve randomly generated numbers
            var integer = RandomInt();
            //var intStr;
            var newNumber = "";
            var dbl = RandomInt();

            //add extra 00's is the number is less than 100/10 to formulate a whole call number double value
            if (integer < 10)
            {
                var intStr = "00" + integer.ToString();
                newNumber = intStr + "." + dbl.ToString();
            }
            else if(integer < 100)
            {
                var intStr = "0" + integer.ToString();
                newNumber = intStr  + "." + dbl.ToString();
            }
            else
            {
                newNumber = integer.ToString() + "." + dbl.ToString();
            }


            //create a new number for the call number
            
            return newNumber;

        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------//
            
        /// <summary>
        /// GENERATE A TOP CALL NUMBER  
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public string TopLevelNumber(int val)
        {
            var rndInt = RandomInt();
            var intStr = "";

            if (val < 10)
            {
                intStr = "00" + val.ToString();

            }
            else if (val < 100)
            {
                intStr = "0" + val.ToString();

            }
            else
            {
                intStr = val.ToString();
            }

            return intStr;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// METHOD USED TO GENERATE A WHOLE SINGLE CALL NUMBER 
        /// </summary>
        /// <returns></returns>
        public string SingleCallNumberGenerator()
        {

            //GENERATE A RANDOM DECIMAL NUMBER
            var numb = NumberGenerator();
            //GENERATE A RANDOM AUTHOR 3 CHAR VALUE
            var str = RandomString();

            //create the call number
            string callNumber = numb.ToString() + " " + str;
            return callNumber;

        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------// 
        /// <summary>
        /// GENERATE 10 RANDOM CALL NUMEBRS
        /// </summary>
        /// <returns></returns>
        public List<string> CallNumberListGenerator()
        {
            var callList = new List<string>();

            //generate a new call number
            var val = SingleCallNumberGenerator();

            for (int i = 0; i < 10; i++)
            {
                //add generated call number to list
                callList.Add(val);
                //generate a new call number
                val = SingleCallNumberGenerator();
            }

            return callList;
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// INSERTION SORT ALGORITHM TO ORDER THE CALL NUMBERS NUMERICALLY
        /// </summary>
        /// <param name="unorderedList"></param>
        /// <returns></returns>
        public List<string> NumberSortingAlgorithim(List<string> unorderedList)
        {
            //throw an exception when there is an error sorting the numbers
            try
            {

                for (int i = 1; i < unorderedList.Count; i++)
            {
                var x = unorderedList[i];
                var count = i - 1;

                //get the first 3 numbers of the call number
                //var current = x.Substring(0, 3);
                
                
                //get the numerical part of the entire call number-before the author's intials
                var whiteSpaceIndex = FindWhiteSpace(x);
                var whiteSpaceIndex2 = FindWhiteSpace(unorderedList[count]);

                //compare the current call number with the next
                while ((count >= 0) && 
                   // (unorderedList[count].Substring(0, 3).CompareTo(current) > 0) &&
                   //GET THE WHOLE CALL NUMBER EXCLUDING THE CHAR AND COMPARE
                    (unorderedList[count].Substring(0,whiteSpaceIndex2-1).CompareTo(x.Substring(0,whiteSpaceIndex-1)) > 0))
                {
                    unorderedList[count + 1] = unorderedList[count];
                    count--;
                }

                unorderedList[count + 1] = x;
            }
            }
            catch (Exception ex)
            {
                //show error message in debug console
                System.Diagnostics.Debug.WriteLine("NumberSortingAlgorithim() ERROR: " + ex.Message);
            }

            return unorderedList;
        }


        //-------------------------------------------------------------------------------------------------------------------------------------------------------------// 
        /// <summary>
        /// SORT THE CALL NUMBERS ALPHABETICALLY, WHILE STILL KEEPING THE NUMEMRICAL ORDER
        /// </summary>
        /// <param name="unorderedList"></param>
        /// <returns></returns>
        public List<string> StringSortingAlgorithim(List<string> unorderedList)
        {
            //throws an exeption when there is an error when sorting the string values
            try
            {
                for (int i = 1; i < unorderedList.Count; i++)
                {
                    //get the second value in the list to compare later
                    var current = unorderedList[i];
                    var count = i - 1;
                    //get the letters from the position of the whitespace
                    var whiteSpaceIndex = FindWhiteSpace(current);

                    //get a substring from the after the whitespace position to the last char
                    // var current = x.Substring(whiteSpaceIndex);
                    var whiteSpaceIndex2 = FindWhiteSpace(unorderedList[count]);

                    while ((count >= 0) &&
                        //check whether the char values that represent the author are in order
                        (unorderedList[count].Substring(whiteSpaceIndex2).CompareTo(current.Substring(whiteSpaceIndex)) > 0)

                        //then check whether the numerical values are in the right order before sorting them alphabetically
                        && (unorderedList[count].Substring(0, 2).CompareTo(current) > 0))
                    {

                        unorderedList[count + 1] = unorderedList[count];
                        count--;

                    }

                    unorderedList[count + 1] = current;
                }
            }
            catch (Exception ex)
            {
                //show error message in debug console
                System.Diagnostics.Debug.WriteLine("StringSortingAlgorithim() ERROR: " + ex.Message);
            }
            

            return unorderedList;
        }


        //-------------------------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// METHOD USED TO LOCATE THE WHITESPACE WITHIN THE CALL NUMBER
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public int FindWhiteSpace(string str)
        {
            var whitespace = false;
            var whitespaceIndex = 0;
            var length = str.Length;
            var count = 1;

            //find the index of the whitespace in a string
            while (count < length && !whitespace)
            {
                //check if the current position is a whitespace
                    whitespace = Char.IsWhiteSpace(str, count);

                //if there is a whitespace, assign the index to the variable
                if (whitespace)
                    whitespaceIndex = count;
                
                count++;
            }

            return whitespaceIndex;
        }


        //-------------------------------------------------------------------------------------------------------------------------------------------------------------// 
        /// <summary>
        /// METHOD USED TO LOCATE THE FULLSTOP WITHIN THE CALL NUMBER
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public int FindFullStop(string str)
        {
           
            var fullstopIndex = str.IndexOf(".");

            return fullstopIndex;
        }


        //-------------------------------------------------------------------------------------------------------------------------------------------------------------// 
        /// <summary>
        /// METHOD USED TO SORT THE GENERATED CALL NUMBERS NUMERICALLY AND THEN ALPHABETICALLY
        /// </summary>
        /// <param name="unorderedList"></param>
        /// <returns></returns>
        public List<string> CallingNumberSortingAlgorithm(List<string> unorderedList)
        {
            List<string> orderedList = new List<string>();

            //ORDER CALL NUMBERS NUMERICALLY FIRST

            orderedList = NumberSortingAlgorithim(unorderedList);

            //ORDER THEM ALPHABETICALLY

            orderedList = StringSortingAlgorithim(orderedList);

            return orderedList;

        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------// 
        /// <summary>
        /// FIND OUT HOW MANY THE USER GOT CORRECT
        /// </summary>
        /// <param name="answers"></param>
        /// <param name="orderedList"></param>
        /// <returns></returns>
        public int CorrectAnswerCount(List<string> answers, List<string> orderedList)
        {
            var correctCount = 0;
            var x = 0;

            //loop through the list
            foreach(var item in answers)
            {
                //if the answer matches the value of the call number at index x
                if (item.Equals(orderedList[x]))
                {
                    //increment value of correct input
                    correctCount++;
                }
                x++;
            }

            return correctCount;
        }


        //-------------------------------------------------------------------------------------------------------------------------------------------------------------//

        #region MISCALLANEOUS CODE 
        /// <summary>
        /// RANDOMLY GENERATES A DECIMAL NUMBER TO AT MOST 4 DECIMAL PLACES
        /// </summary>

        public double RandomDouble()
        {
            var num = _rnd.NextDouble();
            double rounded = Math.Round(num, 4);
            return rounded;
        }
        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

       
        /// <summary>
        /// METHOD TO SORT THE NUMBERS
        /// </summary>
        /// <param name="unorderedList"></param>
        /// <returns></returns>

        public List<int> NumberSortingAlgorithim1(List<int> unorderedList)
        {
            for (int i = 1; i < unorderedList.Count; i++)
            {
                var current = unorderedList[i];
                var count = i - 1;


                while (count >= 0 && unorderedList[count] > current)
                {
                    unorderedList[count + 1] = unorderedList[count];
                    count--;
                }
                unorderedList[count + 1] = current;
            }
            return unorderedList;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// METHOD TO SORT LETTERS
        /// </summary>
        /// <param name="unorderedList"></param>
        /// <returns></returns>
        public List<string> StringSortingAlgorithim2(List<string> unorderedList)
        {

            for (int i = 1; i < unorderedList.Count; i++)
            {
                var current = unorderedList[i];
                var count = i - 1;

                while ((count >= 0) && (unorderedList[count].CompareTo(current) > 0))
                {
                    unorderedList[count + 1] = unorderedList[count];
                    count--;
                }

                unorderedList[count + 1] = current;
            }

            return unorderedList;
        }

        #endregion
    }
    /*--------------------------------------------------------------------------------------00oo END OF FILE oo00-------------------------------------------------------------------------------------------------*/
   
}