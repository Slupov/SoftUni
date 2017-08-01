using System;
using System.Text;

public class ShowCar : Car
{
    public ShowCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension,
        int durability) : base(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability)
    {
        Stars = 0;
    }

    private int stars;

    public int Stars
    {
        get { return stars; }
        private set { stars = value; }
    }

    public override void Update(int index, string addOn)
    {
        base.Update(index, addOn);
        Stars += index;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.Brand} {this.Model} {this.YearOfProduction}");
        sb.AppendLine($"{this.Horsepower} HP, 100 m/h in {this.Acceleration} s");
        sb.AppendLine($"{this.Suspension} Suspension force, {this.Durability} Durability");
        sb.AppendLine($"{this.Stars} *");

        return sb.ToString().Trim();
    }
}