using System.Collections.Generic;
using System.Linq;

class FireNation
{
    private List<FireBender> benders;

    public List<FireBender> Benders
    {
        get { return benders; }
        set { benders = value; }
    }

    private List<FireMonument> monuments;

    public List<FireMonument> Monuments
    {
        get { return monuments; }
        set { monuments = value; }
    }

    private double totalPower;

    public double TotalPower
    {
        get
        {
            var monumentsPercantage = 0.0d;
            foreach (var mon in monuments)
            {
                monumentsPercantage += mon.FireAffinity;
            }

            monumentsPercantage /= 100;

            return Benders.Sum(b => b.TotalPower) + Benders.Sum(b => b.TotalPower) * monumentsPercantage;
        }
    }
}