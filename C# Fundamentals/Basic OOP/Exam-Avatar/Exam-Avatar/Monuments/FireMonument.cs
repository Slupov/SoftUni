using System.Text;

public class FireMonument : Monument
{
    public FireMonument(string name, int affinity) : base(name, affinity)
    {
    }

    private int fireAffinity;

    public int FireAffinity
    {
        get { return fireAffinity; }
        set { fireAffinity = value; }
    }

    public override int Affinity
    {
        get { return FireAffinity; }
        set { FireAffinity = value; }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append($"Fire Monument: {this.Name}, Fire Affinity: {this.FireAffinity}");

        return sb.ToString();
    }
}