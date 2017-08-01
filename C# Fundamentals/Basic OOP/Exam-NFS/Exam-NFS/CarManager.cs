using System;
using System.Collections.Generic;
using System.Linq;

internal class CarManager
{
    private List<Car> unparkedCars;

    public List<Car> UnparkedCars
    {
        get => unparkedCars;
        set => unparkedCars = value;
    }


    private Garage garage;

    public Garage Garage
    {
        get => garage;
        set => garage = value;
    }

    private List<Race> races;

    public List<Race> Races
    {
        get => races;
        set => races = value;
    }

    public CarManager()
    {
        Garage = new Garage();
        UnparkedCars = new List<Car>();
        Races = new List<Race>();
    }

    public void Register(int id, string type, string brand, string model, int yearOfProduction, int horsepower,
        int acceleration, int suspension, int durability)
    {
        Car car;

        switch (type)
        {
            case "Performance":
                car = new PerformanceCar(brand, model, yearOfProduction, horsepower, acceleration, suspension,
                    durability);
                break;
            case "Show":
                car = new ShowCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
                break;
            default:
                throw new ArgumentException("No such car exists");
        }
        car.Id = id;
        this.UnparkedCars.Add(car);
    }

    public string Check(int id)
    {
        var firstOrDefault = UnparkedCars.FirstOrDefault(c => c.Id == id);
        if (firstOrDefault != null)
            return firstOrDefault.ToString();
        else
        {
            firstOrDefault = Garage.ParkedCars.FirstOrDefault(c => c.Id == id);
            if (firstOrDefault != null)
            {
                return firstOrDefault.ToString();
            }
        }

        return "No such car";
    }

    /// <summary>
    /// Opens a race of some given type
    /// </summary>
    public void Open(int id, string type, int length, string route, int prizePool)
    {
        Race race;
        switch (type)
        {
            case "Casual":
                race = new CasualRace(length, route, prizePool, new List<Car>());
                break;
            case "Drag":
                race = new DragRace(length, route, prizePool, new List<Car>());
                break;
            case "Drift":
                race = new DriftRace(length, route, prizePool, new List<Car>());
                break;
            default:
                throw new ArgumentException("No such race type exists");
        }
        race.Id = id;
        Races.Add(race);
    }

    public void Participate(int carId, int raceId)
    {
        if (Garage.ParkedCars.FirstOrDefault(c => c.Id == carId) != null)
        {
            //A car, which has been PARKED in the garage, CANNOT participate in a race
            return;
        }

        var car = UnparkedCars.FirstOrDefault(c => c.Id == carId);
        var race = Races.FirstOrDefault(r => r.Id == raceId);

        if (race != null) race.Participants.Add(car);
    }

    public string Start(int id)
    {
        Race race = Races.FirstOrDefault(r => r.Id == id);
        if (race.IsClosed)
        {
            return string.Empty;
        }

        if (!race.Participants.Any())
        {
            return "Cannot start the race with zero participants.";
        }

        race.RankParticipants();
        race.IsClosed = true;
        return race.ToString();
    }

    public void Park(int id)
    {
        var car = UnparkedCars.FirstOrDefault(c => c.Id == id);
        if (IsCarRacing(car))
        {
            return;
        }
        Garage.ParkedCars.Add(car);
        UnparkedCars.Remove(car);
    }

    public void Unpark(int id)
    {
        var car = Garage.ParkedCars.FirstOrDefault(c => c.Id == id);
        UnparkedCars.Add(car);
        Garage.ParkedCars.Remove(car);
    }

    public void Tune(int tuneIndex, string addOn)
    {
        if (!Garage.ParkedCars.Any())
        {
            return;
        }

        foreach (var car in Garage.ParkedCars)
            car.Update(tuneIndex, addOn);
    }

    private bool IsCarRacing(Car car)
    {
        foreach (var race in Races)
        {
            if (race.Participants.Contains(car))
            {
                return true;
            }
        }

        return false;
    }
}