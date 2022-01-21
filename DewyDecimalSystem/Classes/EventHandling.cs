using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xceed.Wpf.Toolkit;

namespace DewyDecimalSystem.Classes
{
    public class EventHandling
    {
        //declare event
        public event EventHandler<bool> ProcessCompleted;
        public EventHandler PlaySound;
        public EventHandler PauseSound;

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// ACTIVATES THE SOUND 
        /// </summary>
        public void ActivateSound()
        {
            OnSoundPlay();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// STOPS THE SOUND 
        /// </summary>

        public void StopSound()
        {
            OnSoundPause();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// METHOD USED TO COMPARE USER'S ANSWER WITH THE CORRECT ANSWER
        /// </summary>
        /// <param name="userInput"></param>
        /// <param name="generatedList"></param>
        /// <returns></returns>

        public bool EntryValidation(List<string> userInput, List<string> generatedList)
        {
            var valid = false;

            var randomClass = new RandomClass();
            List<string> correctList = new List<string>();

            correctList = randomClass.CallingNumberSortingAlgorithm(generatedList);

            //compare the user's input with the sorted list
            if (userInput.SequenceEqual(correctList))
            {
                valid = true;
            }
                

            //OnProcessCompleted(valid);
            return valid;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// METHOD TO CHECK FOR DUPLICATES IN THE LIST
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns></returns>
        public bool FindDuplicates(List<string> userInput)
        {
            var duplicates = false;

            IEnumerable<string> d = userInput.GroupBy(x => x)
                                        .SelectMany(g => g.Skip(1));
            var count = d.Count();

            if (count > 0)
            {
                duplicates = true;
            }

            return duplicates;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        protected virtual void OnProcessCompleted(bool IsSuccessful)
        {
            ProcessCompleted?.Invoke(this, IsSuccessful);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// EVENT LISTENER TO MAKE THE SOUND GO OFF WHEN THE TIME RUNS OUT
        /// </summary>

        protected virtual void OnSoundPlay()
        {
            PlaySound?.Invoke(this, EventArgs.Empty);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        /// <summary>
        /// EVENT LISTENER TO STOP THE THE SOUND
        /// </summary>
        protected virtual void OnSoundPause()
        {
            PauseSound?.Invoke(this, EventArgs.Empty);
        }


    }

    
    /*--------------------------------------------------------------------------------------00oo END OF FILE oo00-------------------------------------------------------------------------------------------------*/
   
}