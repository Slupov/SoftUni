using System;
using System.Collections.Generic;

namespace _08.Military_Elite
{
    public class Engine
    {
        private List<Soldier> soldiers = new List<Soldier>();

        public void Run()
        {
            string[] input = Console.ReadLine().Split();

            while (input[0] != "End")
            {
                try
                {
                    soldiers.Add(SoldierFactory.ProduceSoldier(input));
                }
                catch (Exception)
                {
                    
                }        
                
                input = Console.ReadLine().Split();
            }
            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier.ToString());   
            }
        }
    }
}
