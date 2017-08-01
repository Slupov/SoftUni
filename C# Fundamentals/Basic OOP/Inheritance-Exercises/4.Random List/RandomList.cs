using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class RandomList : ArrayList
    {
        public string RandomString()
        {
            Random r = new Random();
            string str = this[r.Next(0, this.Count)].ToString();
            return str;
        }
    }
