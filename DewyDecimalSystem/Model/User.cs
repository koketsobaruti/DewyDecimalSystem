using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DewyDecimalSystem.Classes
{
    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Score { get; set; }

        public User() { }
        public User(string _name, string _surname, int _score)
        {
            this.Name = _name;
            this.Surname = _surname;
            this.Score = _score;
        }
    }

}