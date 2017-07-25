using System;
using System.Collections.Generic;
using System.Text;
using _08.Military_Elite.Interfaces;

namespace _08.Military_Elite
{
    public class Commando : SpecialisedSoldier, ICommando
    {
      

        public Commando(string id, string firstName, string lastName, double salary, string corps, List<Mission> missions) : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = missions;
        }

       
        public List<Mission> Missions { get; set; }

        public void CompleteMission()
        {          
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Environment.NewLine);
            sb.Append($"Missions:");
            foreach (var mission in this.Missions)
            {
                sb.Append(Environment.NewLine);
                sb.Append($"  {mission.ToString()}");
            }

            return base.ToString() + sb.ToString();
        }


    }
}
