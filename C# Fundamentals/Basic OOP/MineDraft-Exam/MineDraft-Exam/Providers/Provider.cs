using System;
using System.Text;

public abstract class Provider
{
    protected Provider(string id, double energyOutput)
    {
        Id = id;
        EnergyOutput = energyOutput;
    }

    private string id;

    public string Id
    {
        get { return id; }
        protected set { id = value; }
    }

    private double energyOutput;

    public double EnergyOutput
    {
        get { return energyOutput; }
        protected set
        {
            if (value >= 0 && value < 10000)
            {
                energyOutput = value;
            }
            else
            {
                throw new ArgumentException("Provider is not registered, because of it's EnergyOutput");
            }
        }
    }

    public override string ToString()
    {
        var endNameIndex = this.GetType().Name.IndexOf("Provider");
        var typeName = this.GetType().Name.Substring(0, endNameIndex);

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{typeName} Provider - {id}");
        sb.AppendLine($"Energy Output: {EnergyOutput}");

        return sb.ToString().Trim();
    }
}