using System;

namespace _08.Military_Elite
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private string corps;

        public SpecialisedSoldier(string id, string firstName, string lastName, double salary, string corps) : base(id,
            firstName, lastName, salary)
        {
            this.Corps = corps;
        }

        public string Corps
        {
            get
            {
                return this.corps;
            }
            protected set
            {
                if (value == "Airforces" || value == "Marines")
                {
                    this.corps = value;
                }
                else
                {
                    throw new ArgumentException($"");
                }

            }
        }

        public override string ToString()
        {
            return $"{base.ToString()}" + Environment.NewLine + $"Corps: {this.Corps}";
        }
    }
}
