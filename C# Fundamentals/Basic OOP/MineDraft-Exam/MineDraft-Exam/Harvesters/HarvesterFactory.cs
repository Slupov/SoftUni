public abstract class HarvesterFactory
{
    public static Harvester CreateHammer(string id, double oreOutput, double energyRequirement)
    {
        return new HammerHarvester(id, oreOutput, energyRequirement);
    }

    public static Harvester CreateSonic(string id, double oreOutput, double energyRequirement, int sonicFactor)
    {
        return new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor);
    }
}