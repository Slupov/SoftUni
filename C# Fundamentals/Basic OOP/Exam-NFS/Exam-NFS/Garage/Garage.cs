using System.Collections.Generic;

public class Garage
{
    public Garage()
    {
        ParkedCars = new List<Car>();
    }
    private List<Car> parkedCars;

    public List<Car> ParkedCars
    {
        get { return parkedCars; }
        set { parkedCars = value; }
    }
}