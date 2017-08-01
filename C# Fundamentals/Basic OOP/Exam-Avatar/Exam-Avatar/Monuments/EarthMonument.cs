using System.Text;

public class EarthMonument : Monument
{
    public EarthMonument(string name, int affinity) : base(name, affinity)
    {
    }

    private int earthAffinity;

    public int EarthAffinity
    {
        get { return earthAffinity; }
        set { earthAffinity = value; }
    }

    public override int Affinity
    {
        get { return EarthAffinity; }
        set { EarthAffinity = value; }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append($"Earth Monument: {this.Name}, Earth Affinity: {this.EarthAffinity}");

        return sb.ToString();
    }


}