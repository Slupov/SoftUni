public abstract class Monument
{
    protected Monument(string name, int affinity)
    {
        Name = name;
        Affinity = affinity;
    }

    private string name;
    protected string Name
    {
        get { return name; }
        set { name = value; }
    }

    private int affinity;
    public virtual int Affinity
    {
        get { return affinity; }
        set { affinity = value; }
    }
}