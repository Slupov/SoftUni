using System;
using System.Text;

public abstract class Harvester
{
    protected Harvester(string id, double oreOutput, double energyRequirement)
    {
        Id = id;
        OreOutput = oreOutput;
        EnergyRequirement = energyRequirement;
    }

    private string id;

    public string Id
    {
        get { return id; }
        protected set { id = value; }
    }

    private double oreOutput;

    public double OreOutput
    {
        get { return oreOutput; }
        protected set
        {
            if (value >= 0)
            {
                oreOutput = value;
            }
            else
            {
                throw new ArgumentException("Harvester is not registered, because of it's OreOutput");
            }
        }
    }

    private double energyRequirement;

    public double EnergyRequirement
    {
        get { return energyRequirement; }
        protected set
        {
            if (value >= 0 && value <= 20000)
            {
                energyRequirement = value;
            }
            else
            {
                throw new ArgumentException("Harvester is not registered, because of it's EnergyRequirement");
            }
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        var endNameIndex = this.GetType().Name.IndexOf("Harvester");
        var typeName = this.GetType().Name.Substring(0,endNameIndex);

        sb.AppendLine($"{typeName} Harvester - {id}");
        sb.AppendLine($"Ore Output: {OreOutput}");
        sb.AppendLine($"Energy Requirement: {EnergyRequirement}");

        return sb.ToString().Trim();
    }
}