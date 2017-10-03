using System;
using _05.BarracksWars___Return_of_the_Dependencies.Contracts;

namespace _05.BarracksWars___Return_of_the_Dependencies.Core.Factories
{
    public class UnitFactory : IUnitFactory
    {
        private const string UnitNameSpace = "_03BarracksFactory.Models.Units.";
        public IUnit CreateUnit(string unitType)
        {
            Type typeUnit = Type.GetType(UnitNameSpace + unitType);
            IUnit unitInstance = (IUnit)Activator.CreateInstance(typeUnit);
            return unitInstance;
        }
    }
}
