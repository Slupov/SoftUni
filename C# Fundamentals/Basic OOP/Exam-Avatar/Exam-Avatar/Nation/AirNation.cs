using System.Collections.Generic;
using System.Linq;

class AirNation
{
    private List<AirBender> benders;

    public List<AirBender> Benders
    {
        get { return benders; }
        set { benders = value; }
    }

    private List<AirMonument> monuments;

    public List<AirMonument> Monuments
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
            foreach (var airMonument in Monuments)
            {
                monumentsPercantage += airMonument.AirAffinity;
            }

            monumentsPercantage /= 100;

            return Benders.Sum(b => b.TotalPower) + Benders.Sum(b => b.TotalPower) * monumentsPercantage;
        }
    }
}