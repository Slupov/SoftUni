using InfernoInfinity.Models.Gems;
using InfernoInfinity.Models.Weapons;

namespace _11.InfernoInfinity.Models.Weapons
{
    public class Axe : Weapon
    {
        public Axe(string weaponType, string rarity, string name) : base(weaponType, rarity, name)
        {
            this.MinDamage = 5;
            this.MaxDamage = 10;
            this.Sockets = new BaseGem[4];
            AddRarityBonuses();
        }
    }
}