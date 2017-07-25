using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Border_Control
{
   public class BirthdayChecker : IBirthdate
    {
        
        public string Birthdate { get; protected set; }

        public bool CheckBirthdate(string birthday, string birthYear)
        {          
            if (birthday.Substring(birthday.Length-birthYear.Length) == birthYear)
            {
                return true;
            }
            return false;
        }
    }
}
