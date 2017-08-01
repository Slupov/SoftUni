using System.Text;

public class AirMonument : Monument
{
    public AirMonument(string name, int affinity) : base(name, affinity)
    {
    }

    private int airAffinity;

    public int AirAffinity
    {
        get { return airAffinity; }
        set { airAffinity = value; }
    }

    public override int Affinity
    {
        get { return AirAffinity; }
        set { AirAffinity = value; }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append($"Air Monument: {this.Name}, Air Affinity: {this.AirAffinity}");

        return sb.ToString();
    }
}