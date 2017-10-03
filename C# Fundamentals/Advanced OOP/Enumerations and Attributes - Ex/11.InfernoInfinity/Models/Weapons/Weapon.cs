using System;
using System.Linq;
using InfernoInfinity.Interfaces;
using InfernoInfinity.Models.Attributes;
using InfernoInfinity.Models.Enums;

namespace InfernoInfinity.Models.Weapons
{
    [Weapon("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
    public abstract class Weapon : IWeapon
    {
        protected Weapon(string weaponType, string rarity, string name)
        {
            this.WeaponType = (WeaponType) Enum.Parse(typeof(WeaponType), weaponType);
            this.Rarity = (Rarity) Enum.Parse(typeof(Rarity), rarity);
            this.WeaponName = name;
        }

        public int Agility { get; protected set; }
        public int MaxDamage { get; protected set; }
        public int MinDamage { get; protected set; }
        public Rarity Rarity { get; protected set; }
        public IBaseGem[] Sockets { get; protected set; }
        public int Strength { get; protected set; }
        public int Vitality { get; protected set; }
        public string WeaponName { get; protected set; }
        public WeaponType WeaponType { get; protected set; }

        public void AddGem(int socketIndex, IBaseGem gem)
        {
            if (SocketExists(socketIndex))
                this.Sockets[socketIndex] = gem;
        }

        public void AddRarityBonuses()
        {
            this.MinDamage = (int) this.Rarity * this.MinDamage;
            this.MaxDamage = (int) this.Rarity * this.MaxDamage;
        }

        public void RemoveGem(int socketIndex)
        {
            if (SocketExists(socketIndex))
                if (!SocketIsFree(socketIndex))
                    this.Sockets[socketIndex] = null;
        }

        public override string ToString()
        {
            var minDamage = this.MinDamage;
            var maxDamage = this.MaxDamage;
            var strBonus = 0;
            var agiBonus = 0;
            var vitBonus = 0;

            foreach (var gem in this.Sockets.Where(s => s != null))
            {
                var bonus = gem.CalculateDamageBoost();
                minDamage += bonus.MinDamageBoost;
                maxDamage += bonus.MaxDamageBoost;
                strBonus += gem.StrengthBonus;
                agiBonus += gem.AgilityBonus;
                vitBonus += gem.VitalityBonus;
            }

            return
                $"{this.WeaponName}: {minDamage}-{maxDamage} Damage, +{strBonus} Strength, +{agiBonus} Agility, +{vitBonus} Vitality";
        }

        private bool SocketExists(int socketIndex)
        {
            if (socketIndex < 0 || socketIndex > this.Sockets.Length - 1)
                return false;
            return true;
        }

        private bool SocketIsFree(int socketIndex)
        {
            return this.Sockets[socketIndex] is null;
        }
    }
}