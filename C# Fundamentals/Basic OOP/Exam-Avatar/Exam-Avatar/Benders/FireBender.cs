using System.Text;

public class FireBender : Bender
{
    public FireBender(string name, int power, double secondary) : base(name, power)
    {
        HeatAggression = secondary;
    }

    private double heatAggression;

    public double HeatAggression
    {
        get { return heatAggression; }
        set { heatAggression = value; }
    }

    public override double TotalPower
    {
        get { return Power * HeatAggression; }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append($"Fire Bender: {this.Name}, Power: {this.Power}, Heat Aggression: {this.HeatAggression:F2}");

        return sb.ToString();
    }
}