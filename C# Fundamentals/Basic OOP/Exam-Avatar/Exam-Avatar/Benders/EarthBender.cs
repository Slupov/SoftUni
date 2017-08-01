using System.Text;

public class EarthBender : Bender
{
    public EarthBender(string name, int power, double secondary) : base(name, power)
    {
        GroundSaturation = secondary;
    }

    private double groundSaturation;

    public double GroundSaturation
    {
        get { return groundSaturation; }
        set { groundSaturation = value; }
    }

    public override double TotalPower
    {
        get { return Power * GroundSaturation; }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append($"Earth Bender: {this.Name}, Power: {this.Power}, Ground Saturation: {this.GroundSaturation:F2}");

        return sb.ToString();
    }
}