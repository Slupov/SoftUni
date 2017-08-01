public class SonicHarvester : Harvester
{
    public SonicHarvester(string id, double oreOutput, double energyRequirement,int sonicFactor) : base(id, oreOutput,
        energyRequirement)
    {
        EnergyRequirement = EnergyRequirement / sonicFactor;
        SonicFactor = sonicFactor;
    }

    private int sonicFactor;

    public int SonicFactor
    {
        get => sonicFactor;
        set => sonicFactor = value;
    }
}