using System.Text;

public class WaterBender : Bender
{
    public WaterBender(string name, int power, double secondary) : base(name, power)
    {
        WaterClarity = secondary;
    }

    private double waterClarity;

    public double WaterClarity
    {
        get { return waterClarity; }
        set { waterClarity = value; }
    }

    public override double TotalPower
    {
        get { return Power * WaterClarity; }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append($"Water Bender: {this.Name}, Power: {this.Power}, Water Clarity: {this.WaterClarity:F2}");

        return sb.ToString();
    }
}