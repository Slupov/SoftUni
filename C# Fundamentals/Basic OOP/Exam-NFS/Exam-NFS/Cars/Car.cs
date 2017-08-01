using System;

public abstract class Car
{
    protected Car(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension,
        int durability)
    {
        Brand = brand;
        Model = model;
        YearOfProduction = yearOfProduction;
        Horsepower = horsepower;
        Acceleration = acceleration;
        Suspension = suspension;
        Durability = durability;
    }

    private int id;

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    private string brand;

    public string Brand
    {
        get { return brand; }
        set { brand = value; }
    }

    private string model;

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    private int yearOfProduction;

    protected int YearOfProduction
    {
        get { return yearOfProduction; }
        set { yearOfProduction = value; }
    }

    private int horsepower;

    protected int Horsepower
    {
        get { return horsepower; }
        set { horsepower = value; }
    }

    private int acceleration;

    protected int Acceleration
    {
        get { return acceleration; }
        set { acceleration = value; }
    }

    private int suspension;

    protected int Suspension
    {
        get { return suspension; }
        set { suspension = value; }
    }

    private int durability;

    protected int Durability
    {
        get { return durability; }
        set { durability = value; }
    }

    public int OverallPerformance
    {
        get { return Horsepower / Acceleration + Suspension + Durability; }
    }

    public int EnginePerformance
    {
        get { return Horsepower / Acceleration; }
    }

    public int SuspensionPerformance
    {
        get { return Suspension + Durability; }
    }

    public int PerformancePoints { get; set; }

    public virtual void Update(int index, string addOn)
    {
        Horsepower += index;
        Suspension += index / 2;
    }
}