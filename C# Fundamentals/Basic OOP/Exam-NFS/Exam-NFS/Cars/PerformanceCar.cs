using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PerformanceCar : Car
{
    public PerformanceCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration,
        int suspension, int durability) : base(brand, model, yearOfProduction, horsepower, acceleration, suspension,
        durability)
    {
        AddOns = new List<string>();
        Horsepower += (int) (Horsepower * 0.5);
        Suspension -= (int) (Suspension * 0.25);
    }

    private List<string> addOns;

    public List<string> AddOns
    {
        get { return addOns; }
        set { addOns = value; }
    }

    public void InsertAddOn(string addOn)
    {
        this.AddOns.Add(addOn);
    }

    public override void Update(int index, string addOn)
    {
        base.Update(index, addOn);
        InsertAddOn(addOn);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.Brand} {this.Model} {this.YearOfProduction}");
        sb.AppendLine($"{this.Horsepower} HP, 100 m/h in {this.Acceleration} s");
        sb.AppendLine($"{this.Suspension} Suspension force, {this.Durability} Durability");

        string addOnsString = AddOns.Count > 0 ? string.Join(", ", AddOns) : "None";
        sb.AppendLine($"Add-ons: {addOnsString}");

        return sb.ToString().Trim();
    }
}