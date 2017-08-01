using System.Text;

public class WaterMonument : Monument
{
    public WaterMonument(string name, int affinity) : base(name, affinity)
    {
    }

    private int waterAffinity;

    public int WaterAffinity
    {
        get { return waterAffinity; }
        set { waterAffinity = value; }
    }

    public override int Affinity
    {
        get { return WaterAffinity; }
        set { WaterAffinity = value; }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append($"Water Monument: {this.Name}, Water Affinity: {this.WaterAffinity}");

        return sb.ToString();
    }
}