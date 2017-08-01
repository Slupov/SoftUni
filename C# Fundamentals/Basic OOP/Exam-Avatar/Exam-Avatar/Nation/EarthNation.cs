using System.Collections.Generic;
using System.Linq;

class EarthNation
{
    private List<EarthBender> benders;

    public List<EarthBender> Benders
    {
        get { return benders; }
        set { benders = value; }
    }

    private List<EarthMonument> monuments;

    public List<EarthMonument> Monuments
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
                monumentsPercantage += mon.EarthAffinity;
            }

            monumentsPercantage /= 100;

            return Benders.Sum(b => b.TotalPower) + Benders.Sum(b => b.TotalPower) * monumentsPercantage;
        }
    }
}