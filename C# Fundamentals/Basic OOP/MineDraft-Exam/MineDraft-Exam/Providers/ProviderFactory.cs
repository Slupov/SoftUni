using System.Collections.Generic;

public static class ProviderFactory
{
    public static Provider CreatePressure(string id, double energyOutput)
    {
        return new PressureProvider(id, energyOutput);
    }

    public static Provider CreateSolar(string id, double energyOutput)
    {
        return new SolarProvider(id, energyOutput);
    }
}