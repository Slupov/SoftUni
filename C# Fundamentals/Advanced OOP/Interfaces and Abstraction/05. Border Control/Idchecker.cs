using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Border_Control
{
   public class Idchecker : IId
    {
        
        public string Id { get; protected set; }

        public bool CheckId(string id, string fakeDetector)
        {          
            if (id.Substring(id.Length-fakeDetector.Length) == fakeDetector)
            {
                return true;
            }
            return false;
        }
    }
}
