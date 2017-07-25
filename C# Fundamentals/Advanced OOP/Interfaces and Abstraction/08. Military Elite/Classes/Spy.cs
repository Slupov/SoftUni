
using System;
using System.Text;

namespace _08.Military_Elite
{
   public class Spy : Soldier,ISpy
    {

        public Spy(string id, string firstName, string lastName, int codeNumber) : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; protected set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Environment.NewLine);
            sb.Append($"Code Number: {this.CodeNumber}");

            return base.ToString()+sb.ToString() ;
        }
    }
}
