using System;
using System.Collections.Generic;

public class CoffeeMachine
{
    private List<CoffeeType> coffeeSold = new List<CoffeeType>();
    private int coins;

    public IEnumerable<CoffeeType> CoffeesSold => this.coffeeSold;

    public void BuyCoffee(string size, string type)
    {
        CoffeeType coffeeType = (CoffeeType)Enum.Parse(typeof(CoffeeType), type);
        CoffeePrice coffeePrice = (CoffeePrice)Enum.Parse(typeof(CoffeePrice), size);

        if (this.coins >= (int)coffeePrice)
        {
            this.coffeeSold.Add(coffeeType);
            this.coins = 0;
        }
    }

    public void InsertCoin(string coin)
    {
        Coin rem = (Coin)Enum.Parse(typeof(Coin), coin);
        this.coins += (int)rem;
    }




}

