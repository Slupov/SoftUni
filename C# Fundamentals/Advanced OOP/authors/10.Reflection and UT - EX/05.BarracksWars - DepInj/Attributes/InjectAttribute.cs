using System;

namespace _05.BarracksWars___Return_of_the_Dependencies.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    public class InjectAttribute : Attribute
    {
    }
}
