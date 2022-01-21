using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DD_ClassLibrary
{
    public class ReadFileClass
    {

        /// <summary>
        /// DECLARATION FOR THE DICTIONARY OF THE MAIN CLASSES OF DEWY DECIMAL VALUES AND THEIR SUB CATEGORIES
        /// DECLARATION OF FILE NAME
        /// </summary>
        public SortedDictionary<string, string> _firstLevelClassifications = new SortedDictionary<string, string>();
        public SortedDictionary<string, string> _secondlevelClassifications = new SortedDictionary<string, string>();
        public SortedDictionary<string, string> _thirdlevelClassifications = new SortedDictionary<string, string>();
        private string fileName = @"C:\Users\koket\source\repos\DD_ClassLibrary\dd_classification.txt";
        //private string fileName = @"C:\Users\koket\OneDrive\Documents\SEMESTER 2\PROGRAMMING\TASK 3\dd_classification.txt";

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// METHOD TO GET MAIN CLASSIFICATIONS FROM THE FILE
        /// </summary>
        /// <returns></returns>
        public SortedDictionary<string, string> GetFirstLevelClassifications()
        {
            //try reading from the file. Throws an exeption when an error is found
            try
            {
                //read from the text file 
                string[] lines = System.IO.File.ReadAllLines(fileName);

                foreach (var item in lines)
                {
                    //get the call number and description from the line
                    var number = item.Substring(0, 3);
                    var length = item.Length;
                    var description = item.Substring(4, length - 4);

                    //check if the value is the top class
                    var firstLevel = IsFirstLevel(number);

                    //add the values of the first classes into a dictionary
                    if (firstLevel)
                        _firstLevelClassifications.Add(number, description);

                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("GetFirstLevelClassifications() ERROR MESSAGE: " + ex);
            }

            return _firstLevelClassifications;

        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// METHOD TO GET THE SECOND LEVEL OF CLASSES FROM THE FILE
        /// </summary>
        /// <returns></returns>
        public SortedDictionary<string, string> GetSecondLevelClassifications()
        {
            //try reading from the file. Throws an exeption when an error is found
            try
            {
                //read from the text file 
                string[] lines = System.IO.File.ReadAllLines(fileName);

                foreach (var item in lines)
                {
                    //get the call number and description from the line
                    var number = item.Substring(0, 3);
                    var length = item.Length;
                    var description = item.Substring(4, length - 4);

                    //check if the value is the first class or second class
                    var firstLevel = IsFirstLevel(number);
                    var secondLevel = IsSecondLevel(number);

                    //add the values of the second classes into a dictionary
                    if (!firstLevel && secondLevel)
                        _secondlevelClassifications.Add(number, description);

                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("GetSecondLevelClassifications() ERROR MESSAGE: " + ex);
            }
            return _secondlevelClassifications;

        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// METHOD TO GET THE THIRD LEVEL CLASSES FROM THE FILE
        /// </summary>
        /// <returns></returns>
        public SortedDictionary<string, string> GetThirdLevelClassifications()
        {
            //try reading from the file. Throws an exeption when an error is found
            try
            {
                //read from the text file 
                string[] lines = System.IO.File.ReadAllLines(fileName);

                foreach (var item in lines)
                {
                    //get the call number and description from the line
                    var number = item.Substring(0, 3);
                    var length = item.Length;
                    var description = item.Substring(4, length - 4);
                    //check if the value is the first class or second class
                    var firstLevel = IsFirstLevel(number);
                    var secondLevel = IsSecondLevel(number);

                    //add the values of the third classes into a dictionary
                    if (!firstLevel && !secondLevel)
                    {
                        _thirdlevelClassifications.Add(number, description);
                    }



                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("GetThirdLevelClassifications() ERROR MESSAGE: " + ex);
            }

            return _thirdlevelClassifications;

        }

        /// <summary>
        /// METHOD TO CHECK WHeTHER A VALUE IS FIRST LEVEL OR THIRD LEVEL
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool IsFirstLevel(string number)
        {
            //var firstLevel = false;

            //convert value to int
            var val = Double.Parse(number) / 100.00;

            //check if the value is a whole number
            //e.g. returns true if it is 500 false if it is 530 or 533
            var firstLevel = (val % 1) == 0;

            return firstLevel;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        /// <summary>
        /// METHOD TO CHECK WHETHER THE CALL NUMBER IS THIRD LEVEL OR SECOND LEVEL
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool IsSecondLevel(string number)
        {
            //var secondLevel = false;

            //convert value to int
            var val = Double.Parse(number) / 10.00;

            //check if the value is second level or third level
            //e.g. returns true if it is 530 false if it is 533
            var secondLevel = (val % 1) == 0;

            return secondLevel;
        }


        //---------------------------------------------------------------------------------00oo END OF FILE oo00-------------------------------------------------------------------------------//


    }
}
