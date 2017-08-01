public abstract class Bender
{
    protected Bender(string name, int power)
    {
        Name = name;
        Power = power;
    }
    private string name;
    protected string Name
    {
        get { return name; }
        set { name = value; }
    }

    private int power;
    protected int Power
    {
        get { return power; }
        set { power = value; }
    }

    public virtual double TotalPower
    {
        get { return Power; }
    }
}