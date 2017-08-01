using System.Text;

public class AirBender : Bender
{
    public AirBender(string name, int power,double secondary) : base(name,power)
    {
        AerialIntegrity = secondary;
    }

    private double aerialIntegrity;

    public double AerialIntegrity
    {
        get { return aerialIntegrity; }
        set { aerialIntegrity = value; }
    }

    public override double TotalPower
    {
        get { return Power * AerialIntegrity; }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append($"Air Bender: {this.Name}, Power: {this.Power}, Aerial Integrity: {this.AerialIntegrity:F2}");

        return sb.ToString();
    }
}