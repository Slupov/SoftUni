﻿namespace _05.BarracksWars___Return_of_the_Dependencies.Contracts
{
    public interface IUnitFactory
    {
        IUnit CreateUnit(string unitType);
    }
}