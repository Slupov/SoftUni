using System.Collections.Generic;
using System.Linq;

namespace _08.Military_Elite
{
    public class SoldierFactory
    {
        public static List<Soldier> soldiers = new List<Soldier>();

        public static Soldier ProduceSoldier(string[] input)
        {


            switch (input[0])
            {
                case "Private":
                    Private priv = new Private(input[1], input[2], input[3], double.Parse(input[4]));
                    soldiers.Add(priv);
                    return priv;
                case "LeutenantGeneral":
                    var currPrivates = ExtractPrivates(soldiers,input.Skip(5).ToList());
                    LeutenantGeneral general= new LeutenantGeneral(input[1], input[2], input[3], double.Parse(input[4]),
                        currPrivates);
                    soldiers.Add(general);
                    return general;
                case "Engineer":
                    Engineer eng = new Engineer(input[1], input[2], input[3], double.Parse(input[4]), input[5], Repairs(input));
                    soldiers.Add(eng);
                    return eng;
                case "Commando":
                    Commando comm = new Commando(input[1], input[2], input[3], double.Parse(input[4]), input[5],
                        Missions(input));
                    soldiers.Add(comm);
                    return comm;
                case "Spy":
                    Spy spy = new Spy(input[1], input[2], input[3], int.Parse(input[4]));
                    soldiers.Add(spy);
                    return spy;
                default:
                    return null;
            }
        }

        private static List<Repair> Repairs(string[] input)
        {
            List<Repair> repairs = new List<Repair>();
            string[] holder = input.Skip(6).Take(input.Length - 6).ToArray();
            for (int i = 0; i < holder.Length - 1; i += 2)
            {
                Repair repair = new Repair(holder[i], int.Parse(holder[i + 1]));
                repairs.Add(repair);
            }

            return repairs;
        }

        private static List<Mission> Missions(string[] input)
        {
            List<Mission> missions = new List<Mission>();

            string[] holder = input.Skip(6).Take(input.Length - 6).ToArray();
            if (holder.Length > 0)
            {
                for (int i = 0; i < holder.Length - 1; i += 2)
                {
                    if (holder[i + 1] == "inProgress" || holder[i + 1] == "Finished")
                    {
                        Mission mission = new Mission(holder[i], holder[i + 1]);
                        missions.Add(mission);
                    }
                    
                }

            }

            return missions;
        }
        private static List<Soldier> ExtractPrivates(List<Soldier> soldiers, List<string> ids)
        {
            var list = new List<Soldier>();

            foreach (var id in ids)
            {
                foreach (var soldier in soldiers)
                {
                    if (soldier.Id == id)
                    {
                        list.Add(soldier);
                    }
                    
                }
                
            }

            return list;
        }
    }
}
