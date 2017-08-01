using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    #region fields

    private double energyStored;

    public double EnergyStored
    {
        get { return energyStored; }
        set { energyStored = value; }
    }

    private double dayMinedOre;

    private double DayMinedOre
    {
        get { return dayMinedOre; }
        set { dayMinedOre = value; }
    }

    private double dayEnergyStored;

    private double DayEnergyStored
    {
        get { return dayEnergyStored; }
        set { dayEnergyStored = value; }
    }

    private string currentMode;

    public string CurrentMode
    {
        get { return currentMode; }
        set { currentMode = value; }
    }

    private List<Harvester> harvesters;

    public List<Harvester> Harvesters
    {
        get { return harvesters; }
        set { harvesters = value; }
    }

    private List<Provider> providers;

    public List<Provider> Providers
    {
        get { return providers; }
        set { providers = value; }
    }

    private double totalEnergyStored;

    public double TotalEnergyStored
    {
        get { return totalEnergyStored; }
        set { totalEnergyStored = value; }
    }

    private double totalMinedOre;

    public double TotalMinedOre
    {
        get { return totalMinedOre; }
        set { totalMinedOre = value; }
    }

    #endregion

    public DraftManager()
    {
        Harvesters = new List<Harvester>();
        Providers = new List<Provider>();
        CurrentMode = "Full";

        TotalEnergyStored = 0;
        DayEnergyStored = 0;
        EnergyStored = 0;

        TotalMinedOre = 0;
        DayMinedOre = 0;
    }

    public string RegisterHarvester(List<string> arguments)
    {
        Harvester harvester;
        var type = arguments[0];
        var id = arguments[1];
        var oreOutput = double.Parse(arguments[2]);
        var energyRequirement = double.Parse(arguments[3]);

        if (CheckIdUniqueness("harvester", id))
        {
            if (type == "Sonic")
            {
                var sonicFactor = int.Parse(arguments[4]);
                try
                {
                    harvester = HarvesterFactory.CreateSonic(id, oreOutput, energyRequirement, sonicFactor);
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
            else
            {
                try
                {
                    harvester = HarvesterFactory.CreateHammer(id, oreOutput, energyRequirement);
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
            Harvesters.Add(harvester);
            return $"Successfully registered {type} Harvester - {id}";
        }
        return "Harvester is not registered, because of it's id";
    }

    public bool CheckIdUniqueness(string type, string id)
    {
        switch (type)
        {
            case "harvester":
                foreach (var harvester in Harvesters)
                {
                    if (harvester.Id == id)
                    {
                        return false;
                    }
                }
                return true;
            case "provider":
                foreach (var provider in Providers)
                {
                    if (provider.Id == id)
                    {
                        return false;
                    }
                }
                return true;
        }

        return true;
    }

    public string RegisterProvider(List<string> arguments)
    {
        Provider provider;
        var type = arguments[0];
        var id = arguments[1];
        var energyOutput = double.Parse(arguments[2]);

        if (CheckIdUniqueness("harvester", id))
        {
            if (type == "Pressure")
            {
                try
                {
                    provider = ProviderFactory.CreatePressure(id, energyOutput);
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
            else
            {
                try
                {
                    provider = ProviderFactory.CreateSolar(id, energyOutput);
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }

            Providers.Add(provider);
            return $"Successfully registered {type} Provider - {id}";
        }

        return $"Provider is not registered, because of it's id";
    }

    #region DayUtilities
    private double CalculateDayEnergyRequired()
    {
        var energyRequired = 0.0d;

        switch (CurrentMode)
        {
            case "Full":
                foreach (var harvester in Harvesters)
                {
                    energyRequired += harvester.EnergyRequirement;
                }
                return energyRequired;
            case "Half":
                foreach (var harvester in Harvesters)
                {
                    energyRequired += harvester.EnergyRequirement * 0.6;
                }
                return energyRequired;
            case "Energy":
                return 0.0d;
        }
        return 0.0d;
    }

    private double CalculateDayOreMined()
    {
        var oreMined = 0.0d;

        switch (CurrentMode)
        {
            case "Full":
                foreach (var harvester in Harvesters)
                {
                    oreMined += harvester.OreOutput;
                }
                return oreMined;
            case "Half":
                foreach (var harvester in Harvesters)
                {
                    oreMined += harvester.OreOutput * 0.5;
                }
                return oreMined;
            case "Energy":
                return 0.0d;
        }
        return 0.0d;
    }

    /// <summary>
    /// Returns the providers' energy given
    /// </summary>
    private double CalculateDayProvidedEnergy()
    {
        return Providers.Sum(p => p.EnergyOutput);
    }
    #endregion

    public string Day()
    {
        var providedEnergy = CalculateDayProvidedEnergy();
        var requiredEnergy = CalculateDayEnergyRequired();

        TotalEnergyStored += providedEnergy;
        EnergyStored += providedEnergy; // providers - used

        if (EnergyStored < requiredEnergy)
        {
            StringBuilder sb1 = new StringBuilder();
            sb1.AppendLine("A day has passed.");
            sb1.AppendLine($"Energy Provided: {providedEnergy}");
            sb1.AppendLine($"Plumbus Ore Mined: {DayMinedOre}");

            return sb1.ToString().Trim();
        }

        //if there is enough energy
        EnergyStored -= requiredEnergy;
        DayMinedOre = CalculateDayOreMined();
        TotalMinedOre += DayMinedOre;
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("A day has passed.");
        sb.AppendLine($"Energy Provided: {providedEnergy}");
        sb.AppendLine($"Plumbus Ore Mined: {DayMinedOre}");

        //reset daily variables
        DayMinedOre = 0;
        DayEnergyStored = 0;

        return sb.ToString().Trim();
    }

    public string Mode(List<string> arguments)
    {
        var mode = arguments[0];
        if (mode == "Full" || mode == "Energy" || mode == "Half")
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Successfully changed working mode to {mode} Mode");
            CurrentMode = mode;

            return sb.ToString().Trim();
        }

        throw new ArgumentException("Invalid mode type.");
    }

    public string Check(List<string> arguments)
    {
        var id = arguments[0];
        var harvester = Harvesters.FirstOrDefault(h => h.Id == id);
        var provider = Providers.FirstOrDefault(p => p.Id == id);

        if (harvester != null)
        {
            return harvester.ToString();
        }
        else if (provider != null)
        {
            return provider.ToString();
        }

        return $"No element found with id - {id}";
    }

    public string ShutDown()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("System Shutdown");
        sb.AppendLine($"Total Energy Stored: {EnergyStored}");
        sb.AppendLine($"Total Mined Plumbus Ore: {TotalMinedOre}");
        return sb.ToString().Trim();
    }
}