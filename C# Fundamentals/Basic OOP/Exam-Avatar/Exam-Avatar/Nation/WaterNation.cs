using System.Collections.Generic;
using System.Linq;

class WaterNation
{
    private List<WaterBender> benders;

    public List<WaterBender> Benders
    {
        get { return benders; }
        set { benders = value; }
    }

    private List<WaterMonument> monuments;

    public List<WaterMonument> Monuments
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
                monumentsPercantage += mon.WaterAffinity;
            }

            monumentsPercantage /= 100;

            return Benders.Sum(b => b.TotalPower) + Benders.Sum(b => b.TotalPower) * monumentsPercantage;
        }
    }
}